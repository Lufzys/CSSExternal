using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSSExternal.Classes.SDK
{
    class Offsets
    {
        public static int dwClientState = 0x05AAAA4;
        public static int dwClientState_ViewMatrix = 0x2D4;
        public static int dwForceJump = 0x4F5D24; // client.dll
        public static int dwLocalPlayerOnAir = 0x3D36DC; // engine.dll

        public static int dwLocalPlayer = 0x04C88E8;
        public static int dwEntityList = 0x04D5AF4;

        public static int m_iHealth = 0x94;
        public static int m_iTeamNum = 0x9C;
        public static int m_bDormant = 0x17C;
        public static int m_vecOrigin = 0x260;
        public static int m_fVelocity = 0x5D4;
        public static int m_fFlags = 0x350;
        public static int m_iAirState = 0x5DC;
    }
}
