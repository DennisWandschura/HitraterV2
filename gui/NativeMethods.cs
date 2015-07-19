using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace Gui
{
    static class HitraterNativeMethods
    {
#if _DEBUG
         const string m_dllName = "Hitrater_d.dll";
#else
        const string m_dllName = "Hitrater.dll";
#endif

        [DllImport(m_dllName, CallingConvention = CallingConvention.Cdecl)]
        public unsafe static extern void initialize();

        [DllImport(m_dllName, CallingConvention = CallingConvention.Cdecl)]
        public unsafe static extern void shutdown();

        [DllImport(m_dllName, CallingConvention = CallingConvention.Cdecl)]
        public unsafe static extern void run(uint oldDist, float spread, float maxSpread, float spreadInc, float range, float aimX, float aimY, float recoilX, float recoilY, uint iterations, uint burstLength, 
            float[] outBody, float[] outHead, uint[] outSumBody, uint[] outSumHead);
    }
}
