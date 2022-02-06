class Settings
{
    public static bool ESP = false, Snaplines = false, HealthBar = false, Aimbot = false, Aimbot_RecoilHelper = false, Aimbot_DrawFOV = false, BunnyHop = false;
    public static BoxType ESPType = BoxType.Rectangle;
    public static int AimbotFOV = 90;
    public enum BoxType
    {
        Rectangle,
        Corner
    }
}