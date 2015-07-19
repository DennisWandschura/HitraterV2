#pragma once

class Task;
struct InputData;

#include <vxLib/Allocator/StackAllocator.h>
#include <thread>

class Application
{
	Task* m_tasks;
	std::thread* m_threads;
	vx::StackAllocator m_allocator;
	u32 m_threadCount;

public:
	Application();
	~Application();

	void initialize();
	void shutdown();

	void run(u32 oldDist, const InputData &inputData, f32* outBody, f32* outHead, u32* outSumBody, u32* outSumHead);
};