using Terraria.ModLoader;

namespace UltimateRangerExpansion
{
    public class UltimateRangerExpansion : Mod
    {
        // Base path to mod sounds
        public const string SoundPath = $"{nameof(UltimateRangerExpansion)}/Assets/Sounds/";

        // Calamity mod
        public static readonly Mod Calamity = ModLoader.GetMod("CalamityMod");
    }
}