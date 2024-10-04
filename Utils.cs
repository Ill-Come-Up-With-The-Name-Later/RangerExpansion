using Microsoft.Xna.Framework;
using System;
using Terraria;

namespace UltimateRangerExpansion
{
    public static class Utils
    {
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
        public static float DistanceBetween(Vector2 v1, Vector2 v2) => (float)Math.Sqrt(Math.Pow(v2.X - v1.X, 2) + Math.Pow(v2.Y - v1.Y, 2));

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
        public static float LaunchAngle(Vector2 start, Vector2 end, float vel, float gravity, float scaling = 1f)
        {
            if (start.X == end.X)
                if (end.Y < start.Y)
                    return (float)((3 * Math.PI) / 2);
                else if (end.Y > start.Y)
                    return (float)(Math.PI / 2);
                else
                    return 0;

            float x = (float)((start.X - end.X) * -1 * scaling);
            float y = (float)((start.Y - end.Y) * -1 * scaling);

            vel *= scaling;
            gravity *= scaling;

            float discriminant = (float)(Math.Pow(vel, 4) - gravity * ((gravity * x * x) + (2 * y * vel * vel)));

            if (discriminant < 0)
                return 0;

            float root = (float)Math.Sqrt(discriminant);
            float angle = (float)Math.Atan(((vel * vel) - root) / (gravity * x));

            // Adjust angle 1
            if (angle < 0)
                angle += 2 * (float)Math.PI;

            if (end.X < start.X)
                angle += (float)Math.PI;

            if (angle > 2 * Math.PI)
                angle -= 2 * (float)Math.PI;

            return angle;
        }

        /// <summary>
        /// Draws a line of dust from point A to B
        /// </summary>
        /// <param name="pointA">
        /// Starting point
        /// </param>
        /// <param name="pointB">
        /// Ending point
        /// </param>
        /// <param name="dustType">
        /// The kind of dust to use
        /// </param>
        /// <param name="color">
        /// The color of the dust
        /// </param>
        /// <param name="dustScale">
        /// Size of the dust
        /// </param>
        /// <param name="dustAmount">
        /// Amount of dusts to spawn at each interval
        /// </param>
        public static void DrawDustLine(Vector2 pointA, Vector2 pointB, int dustType, Color color, float dustScale = 0.66f, int dustAmount = 50)
        {
            Vector2 direction = pointB - pointA;

            float distance = direction.Length();
            Vector2 step = direction / distance;

            for (int i = 0; i <= dustAmount; i++)
            {
                Vector2 dustPosition = pointA + step * (distance * (i / (float)dustAmount));

                int tileX = (int)(dustPosition.X / 16f);
                int tileY = (int)(dustPosition.Y / 16f);

                if (!WorldGen.TileEmpty(tileX, tileY))
                    break;

                Dust dust = Dust.NewDustPerfect(dustPosition, dustType, newColor: color);
                dust.noGravity = true;
                dust.scale = dustScale;
                dust.velocity *= 0.1f;
                dust.noLight = false;
                dust.alpha = 0;

                Lighting.AddLight(dust.position, new Vector3(color.R / 255, color.G / 255, color.B / 255));
            }
        }
    }
}
