#pragma once

#define DLL_EXPORT extern "C" __declspec(dllexport)

#include <vxLib/types.h>

DLL_EXPORT void initialize();
DLL_EXPORT void shutdown();

DLL_EXPORT void run(u32 oldDist, f32 spread, f32 maxSpread, f32 spreadInc, f32 range,
	f32 aimX, f32 aimY, f32 recoilX, f32 recoilY,
	u32 iterations, u32 burstLength,
	f32* outBody, f32* outHead, u32* outSumBody, u32* outSumHead);
