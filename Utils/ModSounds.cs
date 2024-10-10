using Terraria.Audio;

namespace UltimateRangerExpansion.Utils
{
    /// <summary>
    /// All mod sounds as well as music tracks
    /// </summary>
    public static class ModSounds
    {
        public static readonly SoundStyle MP5 = new($"{UltimateRangerExpansion.SoundPath}/Guns/MP5", SoundType.Sound);
        public static readonly SoundStyle AWP = new($"{UltimateRangerExpansion.SoundPath}/Guns/AWP", SoundType.Sound);
    }
}
