using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace UltimateRangerExpansion
{
    public class UltimateRangerExpansion : Mod
    {
        // Base path to mod sounds
        public const string SoundPath = $"{nameof(UltimateRangerExpansion)}/Assets/Sounds/";

        // Calamity mod
        public static readonly Mod Calamity = ModLoader.GetMod("CalamityMod");

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

        /// <summary>
        /// Finds the NPC closest to a position
        /// </summary>
        /// <param name="position">
        /// The center position
        /// </param>
        /// <param name="searchDist">
        /// The maximum distance from position to search
        /// </param>
        /// <returns>
        /// Closest NPC within searchDist or null if
        /// none exist
        /// </returns>
        public static NPC? ClosestNPC(Vector2 position, float searchDist)
        {
            NPC? closest = null;
            float maxDist = searchDist;

            foreach (NPC npc in Main.ActiveNPCs)
            {
                if (npc.CanBeChasedBy())
                {
                    float dist = DistanceBetween(position, npc.position);

                    if (dist < maxDist)
                    {
                        closest = npc;
                        maxDist = dist;
                    }
                }
            }

            return closest;
        }
    }
}