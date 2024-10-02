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

        /// <summary>
        /// Calculates angle to launch a projectile
        /// along a parabolic curve form start to end
        /// <br>
        /// Scaling is applied to ensure no
        /// overflows
        /// </summary>
        /// <param name="start">
        /// The launch point
        /// </param>
        /// <param name="end">
        /// The target end point
        /// </param>
        /// <param name="vel">
        /// The initial velocity of the projectile
        /// </param>
        /// <param name="gravity">
        /// The amount of gravity on the projectile
        /// </param>
        /// <param name="scaling">
        /// The amount to scale x, y, gravity, and velocity by
        /// </param>
        /// <returns>
        /// The angle (in radians) required to launch the projectile
        /// from start to end
        /// </returns>
        public static float LaunchAngle(Vector2 start, Vector2 end, float vel, float gravity, float scaling = 0.1f)
        {
            if (start.X == end.X)
                if (end.Y < start.Y)
                    return (float)((3 * Math.PI) / 2);
                else
                    return (float)(Math.PI / 2);

            float x = (float)((start.X - end.X) * -1 * scaling);
            float y = (float)((start.Y - end.Y) * -1 * scaling);

            vel *= scaling;
            gravity *= scaling;

            float discriminant = (float)(Math.Pow(vel, 4) - (gravity * ((gravity * x * x) + (2 * y * vel * vel))));

            if(discriminant < 0)
                return 0;

            float root = (float)Math.Sqrt(discriminant);
            float angle = (float)Math.Atan(((vel * vel) - root) / (gravity * x));

            if (angle < 0)
                angle += 2 * (float)Math.PI;

            if (end.X < start.X)
                angle += (float)Math.PI;

            if (angle > 2 * Math.PI)
                angle -= 2 * (float)Math.PI;

            return angle;
        }
    }
}