using System;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;

namespace UltimateRangerExpansion
{
    public class UltimateRangerExpansion : Mod
    {
        // Base path to mod sounds
        public const string SoundPath = $"{nameof(UltimateRangerExpansion)}/Assets/Sounds/";

        /// <summary>
        /// Distance between two points
        /// </summary>
        /// <param name="v1">
        /// A position
        /// </param>
        /// <param name="v2">
        /// A position
        /// </param>
        /// <returns>
        /// The distance between v1 and v2
        /// </returns>
        public static float DistanceBetween(Vector2 v1, Vector2 v2) => (float) Math.Sqrt(Math.Pow(v2.X - v1.X, 2) + Math.Pow(v2.Y - v1.Y, 2));
    }
}