#pragma once

#include <vxLib/math/Vector.h>

struct AABB
{
	vx::float2a min;
	vx::float2a max;

	AABB() :min(), max(){}

	AABB(const vx::float2a &vmin, const vx::float2a &vmax) :min(vmin), max(vmax) {}

	bool contains(const vx::float2a &p) const
	{
		auto vmin = this->min;
		auto vmax = this->max;

		if (p.x < vmin.x || p.x > vmax.x)
			return false;

		if (p.y < vmin.y || p.y > vmax.y)
			return false;

		return true;
	}
};