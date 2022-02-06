using Memorys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace CSSExternal.Classes.SDK.Classes
{
    class Entity
    {
        public int Address = -1;

        public Entity(int address)
        {
            Address = address;
        }

        public int Health => Memory.Read<int>(Address + Offsets.m_iHealth);
        public int TeamNum => Memory.Read<int>(Address + Offsets.m_iTeamNum);
        public Enums.Team Team => (Enums.Team)Memory.Read<int>(Address + Offsets.m_iTeamNum);
        public bool Dormant => Memory.Read<bool>(Address + Offsets.m_bDormant);
        public int Flags => Memory.Read<int>(Address + Offsets.m_fFlags);
        public float Velocity => Memory.Read<int>(Address + Offsets.m_fVelocity);
        public int AirState => Memory.Read<int>(Address + Offsets.m_iAirState);
        public Vector3 Origin => Memory.Read<Vector3>(Address + Offsets.m_vecOrigin);
        public Vector3 HeadLevel => Origin + new Vector3(0, 0, 70); // Easy Head Position KEKW https://youtu.be/bAQKLN2KCoA?t=4120
        public Vector3 EyeLevel => Origin + new Vector3(0, 0, 58);  // 65 Head - 
        public Vector3 CrouchHeadLevel => Origin + new Vector3(0, 0, 54);
        public Vector3 CrouchEyeLevel => Origin + new Vector3(0, 0, 40);
    }
}
