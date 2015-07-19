#pragma once

#include <vxlib/math/Vector.h>

struct InputData
{
	f32 m_spread;
	f32 m_maxSpread;
	f32 m_spreadInc;
	f32 m_range;
	vx::float2 m_aim;
	vx::float2 m_recoil;
	u32 m_iterations;
	u32 m_burstLength;
};