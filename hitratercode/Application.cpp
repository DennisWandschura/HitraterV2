#include "Application.h"
#include "Task.h"
#include "InputData.h"
#include "OutputData.h"

namespace ApplicationCpp
{
	const u32 g_maxBurstCount = 200u;
	const u32 g_maxThreadCount = 7;

	void taskFun(Task* task, u32 from, u32 to, InputData inputData, OutputData* outputData)
	{
		task->run(from, to, inputData, outputData);
	}
};

Application::Application()
	:m_tasks(nullptr),
	m_threads(nullptr),
	m_allocator(),
	m_threadCount(0)
{

}

Application::~Application()
{
	shutdown();
}

void Application::initialize()
{
	const auto tmpMemorySize = sizeof(Task) * ApplicationCpp::g_maxThreadCount + sizeof(u32) * ApplicationCpp::g_maxBurstCount * 2 + sizeof(Task*) * ApplicationCpp::g_maxThreadCount + sizeof(OutputData) * ApplicationCpp::g_maxThreadCount;
	const auto memorySize = 64 KBYTE;
	static_assert(memorySize >= tmpMemorySize, "");

	auto threadCount = std::min(std::thread::hardware_concurrency(), ApplicationCpp::g_maxThreadCount);
	auto taskCount = threadCount + 1;

	auto memory = (u8*)_aligned_malloc(memorySize, 64);
	VX_ASSERT(memory);

	m_allocator = vx::StackAllocator(memory, memorySize);
	m_threadCount = threadCount;

	m_threads = (std::thread*)m_allocator.allocate(sizeof(std::thread) * threadCount, __alignof(std::thread));
	VX_ASSERT(m_threads);

	for (u32 i = 0; i < threadCount; ++i)
	{
		new (&m_threads[i]) std::thread{};
	}

	m_tasks = (Task*)m_allocator.allocate(sizeof(Task) * taskCount, __alignof(Task));
	VX_ASSERT(m_tasks);

	for (u32 i = 0; i < taskCount; ++i)
	{
		new (&m_tasks[i]) Task(0);
	}
}

void Application::shutdown()
{
	auto p = m_allocator.release();
	if (p)
	{
		_aligned_free(p);

		m_tasks = nullptr;
		m_threadCount = 0;
	}
}

void Application::run(u32 oldDist, const InputData &inputData, f32* outBody, f32* outHead, u32* outSumBody, u32* outSumHead)
{
	auto burstLength = std::min(inputData.m_burstLength, ApplicationCpp::g_maxBurstCount);
	auto threadCount = m_threadCount;
	auto taskCount = threadCount + 1;

	auto marker = m_allocator.getMarker();

	auto iterations = inputData.m_iterations;
	iterations = std::max(iterations, taskCount);

	for (u32 i = 0; i < taskCount; ++i)
	{
		m_tasks[i].initialize(oldDist, burstLength, &m_allocator);
	}

	OutputData* outputData = (OutputData*)m_allocator.allocate(sizeof(OutputData) * threadCount);
	VX_ASSERT(outputData);

	u32 i = 0;
	for (; i < threadCount; ++i)
	{
		auto &task = m_tasks[i];
		auto &thread = m_threads[i];

		const u32 from = (i * iterations) / taskCount;
		const u32 to = ((i + 1) * iterations) / taskCount;
		thread = std::thread(ApplicationCpp::taskFun, &task, from, to, inputData, &outputData[i]);
	}

	auto &task = m_tasks[i];
	const u32 from = (i * iterations) / taskCount;
	const u32 to = ((i + 1) * iterations) / taskCount;

	m_tasks[i].run(from, to, inputData, &outputData[i]);

	for (i = 0; i < threadCount; ++i)
	{
		auto &thread = m_threads[i];
		if (thread.joinable())
			thread.join();
	}

	for (i = 0; i < taskCount; ++i)
	{
		for (u32 j = 0; j < burstLength; ++j)
		{
			outBody[j] += (f32)outputData[i].bodyshotCount[j];
			outHead[j] += (f32)outputData[i].headshotCount[j];
		}
	}

	for (u32 j = 0; j < burstLength; ++j)
	{
		outSumBody[j] = outBody[j];
		outSumHead[j] = outHead[j];

		outBody[j] /= iterations;
		outHead[j] /= iterations;
	}

	m_allocator.clear(marker);
}