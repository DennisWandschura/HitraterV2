#include "Task.h"
#include <assert.h>
#include <algorithm>
#include "InputData.h"
#include <vxLib/Allocator/StackAllocator.h>

#include <DirectXMath.h>

// x, y, w, h
// head { -0.08f, 0.46f, 0.16f, 0.28f }
// body { -0.27f, -0.46f, 0.54f, 0.92f }

typedef f32(*DistFun)(f32 currentSpread, f32 maxSpread, std::mt19937_64 &gen, std::uniform_real_distribution<f32>* distSpread);

namespace TaskCpp
{
	const vx::float2a g_headBottomLeft = { -0.08f, 0.46f };
	const vx::float2a g_headDim = { 0.16f, 0.28f };

	const vx::float2a g_bodyBottomLeft = { -0.27f, -0.46f };
	const vx::float2a g_bodyDim = { 0.54f, 0.92f };

	DistFun g_funPtr{nullptr};

	inline __m128 __vectorcall VectorSplatX
		(
			__m128 V
			)
	{
		return VX_PERMUTE_PS(V, _MM_SHUFFLE(0, 0, 0, 0));
	}

	inline __m128 __vectorcall VectorSplatY
		(
			__m128 V
			)
	{
		return VX_PERMUTE_PS(V, _MM_SHUFFLE(1, 1, 1, 1));
	}

	inline __m128 __vectorcall VectorSplatZ
		(
			__m128 V
			)
	{
		return VX_PERMUTE_PS(V, _MM_SHUFFLE(2, 2, 2, 2));
	}

	inline __m128 __vectorcall VectorSplatW
		(
			__m128 V
			)
	{
		return VX_PERMUTE_PS(V, _MM_SHUFFLE(3, 3, 3, 3));
	}


	inline __m128 __vectorcall VectorRound
		(
			__m128 V
			)
	{
		__m128 sign = _mm_and_ps(V, vx::g_VXNegativeZero);

		__m128 sMagic = _mm_or_ps(vx::g_VXNoFraction, sign);

		__m128 R1 = _mm_add_ps(V, sMagic);
		R1 = _mm_sub_ps(R1, sMagic);

		__m128 R2 = _mm_and_ps(V, vx::g_VXAbsMask);
		__m128 mask = _mm_cmple_ps(R2, vx::g_VXNoFraction);
		R2 = _mm_andnot_ps(mask, V);
		R1 = _mm_and_ps(R1, mask);

		__m128 vResult = _mm_xor_ps(R1, R2);
		return vResult;
	}

	inline __m128 __vectorcall VectorNegativeMultiplySubtract
		(
			__m128 V1,
			__m128 V2,
			__m128 V3
			)
	{
		auto R = _mm_mul_ps(V1, V2);
		return _mm_sub_ps(V3, R);
	}

	inline __m128 __vectorcall VectorInBounds
		(
			__m128 V,
			__m128 Bounds
			)
	{
		// Test if less than or equal
		auto vTemp1 = _mm_cmple_ps(V, Bounds);
		// Negate the bounds
		auto vTemp2 = _mm_mul_ps(Bounds, vx::g_VXNegativeOne);
		// Test if greater or equal (Reversed)
		vTemp2 = _mm_cmple_ps(vTemp2, V);
		// Blend answers
		vTemp1 = _mm_and_ps(vTemp1, vTemp2);
		return vTemp1;
	}

	inline __m128 __vectorcall VectorAndInt
		(
			__m128 V1,
			__m128 V2
			)
	{
		return _mm_and_ps(V1, V2);
	}

	inline __m128 __vectorcall VectorEqualInt
		(
			__m128 V1,
			__m128 V2
			)
	{
		__m128i V = _mm_cmpeq_epi32(_mm_castps_si128(V1), _mm_castps_si128(V2));
		return _mm_castsi128_ps(V);
	}

	inline __m128 __vectorcall tan(__m128 V)
	{
		static const __m128 TanCoefficients0 = { 1.0f, -4.667168334e-1f, 2.566383229e-2f, -3.118153191e-4f };
		static const __m128 TanCoefficients1 = { 4.981943399e-7f, -1.333835001e-1f, 3.424887824e-3f, -1.786170734e-5f };
		static const __m128 TanConstants = { 1.570796371f, 6.077100628e-11f, 0.000244140625f, 0.63661977228f /*2 / Pi*/ };
		static const vx::uvec4 Mask = { 0x1, 0x1, 0x1, 0x1 };
		__m128 TwoDivPi = VectorSplatW(TanConstants);

		__m128 Zero = _mm_setzero_ps();

		__m128 C0 = VectorSplatX(TanConstants);
		__m128 C1 = VectorSplatY(TanConstants);
		__m128 Epsilon = VectorSplatZ(TanConstants);

		__m128 VA = _mm_mul_ps(V, TwoDivPi);

		VA = VectorRound(VA);

		__m128 VC = VectorNegativeMultiplySubtract(VA, C0, V);

		__m128 VB = vx::abs(VA);

		VC = VectorNegativeMultiplySubtract(VA, C1, VC);

		reinterpret_cast<__m128i *>(&VB)[0] = _mm_cvttps_epi32(VB);

		__m128 VC2 = _mm_mul_ps(VC, VC);

		__m128 T7 = VectorSplatW(TanCoefficients1);
		__m128 T6 = VectorSplatZ(TanCoefficients1);
		__m128 T4 = VectorSplatX(TanCoefficients1);
		__m128 T3 = VectorSplatW(TanCoefficients0);
		__m128 T5 = VectorSplatY(TanCoefficients1);
		__m128 T2 = VectorSplatZ(TanCoefficients0);
		__m128 T1 = VectorSplatY(TanCoefficients0);
		__m128 T0 = VectorSplatX(TanCoefficients0);

		__m128 VBIsEven = VectorAndInt(VB, Mask.v);
		VBIsEven = VectorEqualInt(VBIsEven, Zero);

		__m128 N = vx::fma(VC2, T7, T6);
		__m128 D = vx::fma(VC2, T4, T3);
		N = vx::fma(VC2, N, T5);
		D = vx::fma(VC2, D, T2);
		N = _mm_mul_ps(VC2, N);
		D = vx::fma(VC2, D, T1);
		N = vx::fma(VC, N, VC);
		__m128 VCNearZero = VectorInBounds(VC, Epsilon);
		D = vx::fma(VC2, D, T0);

		N = vx::VectorSelect(N, VC, VCNearZero);
		D = vx::VectorSelect(D, vx::g_VXOne, VCNearZero);

		__m128 R0 = vx::negate(N);
		__m128 R1 = _mm_div_ps(N, D);
		R0 = _mm_div_ps(D, R0);

		__m128 VIsZero = _mm_cmpeq_ps(V, Zero);

		__m128 Result = vx::VectorSelect(R0, R1, VBIsEven);

		Result = vx::VectorSelect(Result, Zero, VIsZero);

		return Result;
	}
}

const AABB Task::s_head =
{
	{ TaskCpp::g_headBottomLeft },
	{ TaskCpp::g_headBottomLeft + TaskCpp::g_headDim }
};

const AABB Task::s_body =
{
	{ TaskCpp::g_bodyBottomLeft },
	{ TaskCpp::g_bodyBottomLeft + TaskCpp::g_bodyDim }
};

f32 distributionFunOld(f32 currentSpread, f32 maxSpread, std::mt19937_64 &gen, std::uniform_real_distribution<f32>* distSpread)
{
	*distSpread = std::uniform_real_distribution<f32>(0.0f, std::min(currentSpread, maxSpread));

	return (*distSpread)(gen);
}

f32 distributionFunNew(f32 currentSpread, f32 maxSpread, std::mt19937_64 &gen, std::uniform_real_distribution<f32>* distSpread)
{
	auto value = (*distSpread)(gen);

	return currentSpread * sqrt(value);
}

Task::Task(u32 seed)
	:m_rng(seed),
	m_headshots(nullptr),
	m_bodyshots(nullptr)
{
}

Task::~Task()
{

}

void Task::initialize(u32 oldDist, u32 burstlength, vx::StackAllocator* allocator)
{
	VX_ASSERT(burstlength != 0);

	const auto sizeInBytes = sizeof(u32) * burstlength;

	m_headshots = (u32*)allocator->allocate(sizeInBytes, 4);
	VX_ASSERT(m_headshots != nullptr);

	m_bodyshots = (u32*)allocator->allocate(sizeInBytes, 4);
	VX_ASSERT(m_bodyshots != nullptr);

	memset(m_headshots, 0, sizeInBytes);
	memset(m_bodyshots, 0, sizeInBytes);

	if (oldDist == 0)
	{
		TaskCpp::g_funPtr = distributionFunNew;
	}
	else
	{
		TaskCpp::g_funPtr = distributionFunOld;
	}
}

void Task::burstSIMD
(
	const InputData &inputData,
	const std::uniform_real_distribution<f32> &distAngle,
	const std::uniform_real_distribution<f32> &distRecoil
	)
{
	auto currentSpread0 = inputData.m_spread;
	auto maxSpread = inputData.m_maxSpread;
	auto spreadInc = inputData.m_spreadInc;
	const auto aim = inputData.m_aim;
	const auto range = inputData.m_range;

	std::uniform_real_distribution<f32> distSpread(0.0f, 1.0f);

	auto burstlength = inputData.m_burstLength / 2;

	auto recoil0 = 0.0f;
	auto recoil1 = distRecoil(m_rng);
	auto currentSpread1 = spreadInc;

	for (auto i = 0u; i < burstlength; ++i)
	{
		auto spreadRadius0 = currentSpread0 * sqrt(distSpread(m_rng));
		auto spreadRadius1 = currentSpread1 * sqrt(distSpread(m_rng));

		auto spreadAngle0 = distAngle(m_rng);
		auto spreadAngle1 = distAngle(m_rng);

		f32 cosVal0, sinVal0;
		vx::scalarSinCos(&sinVal0, &cosVal0, spreadAngle0);

		f32 cosVal1, sinVal1;
		vx::scalarSinCos(&sinVal1, &cosVal1, spreadAngle1);

		auto spreadX0 = spreadRadius0 * cosVal0;
		auto spreadY0 = spreadRadius0 * sinVal0;

		auto spreadX1 = spreadRadius1 * cosVal1;
		auto spreadY1 = spreadRadius1 * sinVal1;

		auto angleX0 = vx::degToRad(spreadX0 + recoil0);
		auto angleY0 = vx::degToRad(spreadY0);

		auto angleX1 = vx::degToRad(spreadX1 + recoil1);
		auto angleY1 = vx::degToRad(spreadY1);

		vx::float2a hitPos0;
		hitPos0.x = aim.x + range * tan(angleX0);
		hitPos0.y = aim.y + range * tan(angleY0);

		vx::float2a hitPos1;
		hitPos1.x = aim.x + range * tan(angleX1);
		hitPos1.y = aim.y + range * tan(angleY1);

		if (s_body.contains(hitPos0))
		{
			++m_bodyshots[i];
		}
		else if (s_head.contains(hitPos0))
		{
			++m_headshots[i];
		}

		if (s_body.contains(hitPos1))
		{
			++m_bodyshots[i];
		}
		else if (s_head.contains(hitPos1))
		{
			++m_headshots[i];
		}

		// increase spread
		currentSpread0 = currentSpread1;
		currentSpread1 += spreadInc;
		// get recoil value and add to current
		recoil0 = recoil1;
		recoil1 += distRecoil(m_rng);
	}
}

void Task::burst
(
	const InputData &inputData,
	const std::uniform_real_distribution<f32> &distAngle,
	const std::uniform_real_distribution<f32> &distRecoil
	)
{
	auto currentSpread = inputData.m_spread;
	auto maxSpread = inputData.m_maxSpread;
	auto spreadInc = inputData.m_spreadInc;
	const auto aim = inputData.m_aim;
	const auto range = inputData.m_range;

	__m128 vAim = { aim.x, aim.x, aim.y, aim.y };
	__m128 vRange = {range, range,range ,range };

	std::uniform_real_distribution<f32> distSpread(0.0f, 1.0f);

	auto burstlength = inputData.m_burstLength;
	auto recoil = 0.0f;
	for (auto i = 0u; i < burstlength; ++i)
	{
		currentSpread = std::min(currentSpread, maxSpread);
		// einzelne bursts
		//std::uniform_real_distribution<F32> distSpread(0.0f, std::min(spread + i * spreadInc, maxSpread));
		// use [0, spread]

		//auto spreadRadius = currentSpread * sqrt(distSpread(m_rng)); //distSpread(*m_pRng); //spread radius, d.h. winkel zwischen kugel und fadenkreuz (0...spread)
		auto spreadRadius = TaskCpp::g_funPtr(currentSpread, maxSpread, m_rng, &distSpread);
		auto spreadAngle = distAngle(m_rng); //richtung vom spread (0...2pi)

		//f32 cosVal, sinVal;
		//vx::scalarSinCos(&sinVal, &cosVal, spreadAngle);

		__m128 vSpreadAngle = _mm_load_ss(&spreadAngle);
		__m128 vCos, vSin;
		vx::VectorSinCos(&vSin, &vCos, vSpreadAngle);

		__m128 vSpreadRadius = _mm_load_ss(&spreadRadius);
		vSpreadRadius = VX_PERMUTE_PS(vSpreadRadius, _MM_SHUFFLE(0, 0, 0, 0));
		__m128 cosSin = _mm_shuffle_ps(vCos, vSin, _MM_SHUFFLE(0, 0, 0, 0));

		// x, x, y, y
		__m128 vSpread = _mm_mul_ps(vSpreadRadius, cosSin);
		vSpread = VX_PERMUTE_PS(vSpread, _MM_SHUFFLE(0, 0, 2, 0));
		__m128 vRecoil = _mm_load_ss(&recoil);
		//auto spreadX = spreadRadius * cosVal; //umrechnung polarkoordinaten zu kartesisch, spread horizontal
		//auto spreadY = spreadRadius * sinVal;

		__m128 angles = _mm_add_ps(vSpread, vRecoil);
		angles = vx::degToRad(angles);
		//auto angleX = vx::degToRad(spreadX + recoil);
		//auto angleY = vx::degToRad(spreadY);

		// x, 0, y, 0
		vx::uvec4 vHitPos;
		vHitPos.v = vx::fma(vRange, TaskCpp::tan(angles), vAim);
		//__m128 vHitPos = vx::fma(vRange, TaskCpp::tan(angles), vAim);
		//koordinaten vom treffer
		//vx::float2a hitPos;
		//hitPos.x = aim.x + range * tan(angleX);
		//hitPos.y = aim.y + range * tan(angleY);
		//hitPos.x = aim.x + range * tan((spreadX + recoil) * vx::VX_PI / 180.0f);
		//hitPos.y = aim.y + range * tan(spreadY* vx::VX_PI / 180.0f);
		vx::float2a hitPos;
		_mm_storel_epi64((__m128i*)&hitPos, vHitPos);

		// check if we hit something and if yes, increase count
		if (s_body.contains(hitPos))
		{
			++m_bodyshots[i];
		}
		else if (s_head.contains(hitPos))
		{
			++m_headshots[i];
		}

		// increase spread
		currentSpread += spreadInc;
		// get recoil value and add to current
		recoil += distRecoil(m_rng);
	}
}

void Task::run
(
	u32 sliceStart,
	u32 sliceEnd,
	const InputData &inputData,
	OutputData* outputData
	)
{
	std::uniform_real_distribution<f32> distAngle(0.0f, vx::VX_2PI);
	std::uniform_real_distribution<f32> recoilDist(inputData.m_recoil.x, inputData.m_recoil.y);

	auto iterations = inputData.m_iterations;

	//auto burstlength = inputData.m_burstLength;
	/*if (burstlength % 2 == 0)
	{
		for (u32 j = 0; j < iterations; ++j)
		{
			for (u32 i = sliceStart; i < sliceEnd; ++i)
			{
				burstSIMD(inputData, distAngle, recoilDist);
			}
		}
	}
	else*/
	//{
		//for (u32 j = 0; j < iterations; ++j)
		//{
	for (u32 i = sliceStart; i < sliceEnd; ++i)
	{
		burst(inputData, distAngle, recoilDist);
	}
	//}
//}

	outputData->bodyshotCount = m_bodyshots;
	outputData->headshotCount = m_headshots;
}