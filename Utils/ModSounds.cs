using Terraria.Audio;

namespace UltimateRangerExpansion.Utils
{
    /// <summary>
    /// All mod sounds as well as music tracks
    /// </summary>
    public static class ModSounds
    {
        public static readonly SoundStyle MP5 = new($"{UltimateRangerExpansion.SoundPath}/Guns/MP5", 2, 2, SoundType.Sound);
        public static readonly SoundStyle AWP = new($"{UltimateRangerExpansion.SoundPath}/Guns/AWP", 2, 2, SoundType.Sound);
    }
}
