#pragma once

namespace vx
{
	class StackAllocator;
}

#include <vxlib/math/Vector.h>
#include <random>
#include <memory>
#include "AABB.h"
#include "OutputData.h"

struct InputData;

class VX_ALIGN(64) Task
{
	const static AABB s_head;
	const static AABB s_body;

	std::mt19937_64 m_rng;
	u32* m_headshots;
	u32* m_bodyshots;

	void burstSIMD
		(
		const InputData &inputData,
		const std::uniform_real_distribution<f32> &distAngle,
		const std::uniform_real_distribution<f32> &distRecoil
		);

	// this function calculates recoil of a burst
	void burst
		(
		const InputData &inputData,
		const std::uniform_real_distribution<f32> &distAngle,
		const std::uniform_real_distribution<f32> &distRecoil
		);

public:
	Task(u32 seed);
	Task(const Task&) = delete;
	Task(Task &&rhs) = delete;
	~Task();

	void initialize(u32 oldDist, u32 burstlength, vx::StackAllocator* allocator);

	//Task& operator=(const Task&);
	//Task& operator=(Task &&rhs);

	void run(u32 sliceStart, u32 sliceEnd, const InputData &settings, OutputData* outputData);
};