#include "dllExport.h"
#include "Application.h"
#include "InputData.h"

#if NDEBUG

#if _MSC_VER >= 1900
#pragma comment (lib, "vs14/vxlib_s.lib")
#else
#pragma comment (lib, "vs12/vxlib_s.lib")
#endif

#else

#if _MSC_VER >= 1900
#pragma comment (lib, "vs14/vxlib_sd.lib")
#else
#pragma comment (lib, "vs12/vxlib_sd.lib")
#endif

#endif



Application* g_app{ nullptr };

void initialize()
{
	if (!g_app)
	{
		g_app = new Application();
		g_app->initialize();
	}
}

void shutdown()
{
	if (g_app)
	{
		g_app->shutdown();
		delete(g_app);
		g_app = nullptr;
	}
}

void run(u32 oldDist, f32 spread, f32 maxSpread, f32 spreadInc, f32 range,
	f32 aimX, f32 aimY, f32 recoilX, f32 recoilY,
	u32 iterations, u32 burstLength, f32* outBody, f32* outHead,
	u32* outSumBody, u32* outSumHead)
{
	/*
	f32 m_spread;
	f32 m_maxSpread;
	f32 m_spreadInc;
	f32 m_range;
	vx::float2 m_aim;
	vx::float2 m_recoil;
	u32 m_iterations;
	u32 m_burstLength;
	*/
	InputData inputData
	{
		spread,
		std::max(maxSpread, spread),
		spreadInc,
		range,
		{ aimX , aimY},
		{ recoilX , recoilY },
		iterations,
		burstLength
	};

	g_app->run(oldDist, inputData, outBody, outHead, outSumBody, outSumHead);
}