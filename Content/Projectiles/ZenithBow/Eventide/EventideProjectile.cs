using System;
using Terraria.ID;
using Terraria;
using Terraria.ModLoader;
using UltimateRangerExpansion.Content.Projectiles.ZenithBow.CopperBow;
using Microsoft.Xna.Framework;

namespace UltimateRangerExpansion.Content.Projectiles.ZenithBow.Eventide
{
    class EventideProjectile : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.CloneDefaults(ModContent.ProjectileType<CopperBowProjectile>());

            Projectile.width = 28;
            Projectile.height = 70;
        }

        public override void AI()
        {
            Player player = Main.player[Projectile.owner];

            if (Main.myPlayer != Projectile.owner)
            {
                Projectile.Kill();
                return;
            }

            // Hide other projectiles of the same type
            if (Projectile.timeLeft == 17)
            {
                for (int i = 0; i < Main.projectile.Length; i++)
                {
                    Projectile projectile = Main.projectile[i];

                    if (projectile.type == Type && projectile.whoAmI != Projectile.whoAmI && projectile.owner == Projectile.owner
                        && projectile.timeLeft < 16)
                    {
                        projectile.hide = true;
                    }
                }
            }

            // Spawn dust particles
            if (Projectile.timeLeft % 3 == 0)
            {
                Dust.NewDust(Projectile.position, 1, 1, DustID.TintableDustLighted, -Projectile.velocity.X / 3, -Projectile.velocity.Y / 3,
                        newColor: new Color(new Random().Next(0, 255), new Random().Next(0, 255), new Random().Next(0, 255)));
            }

            Projectile.velocity = player.velocity; // Keep projectile near player

            // Rotate projectile to face the mouse
            Vector2 mousePos = Main.MouseWorld;
            Vector2 direction = mousePos - Projectile.position;

            Projectile.rotation = direction.ToRotation();

            if (Projectile.timeLeft % 6 == 0) // Shoot every 6 ticks
            {
                // Shoot at the cursor
                Vector2 velocity = mousePos - Projectile.Center;
                velocity.Normalize();
                velocity *= 17;

                for (int i = -2; i <= 2; i++)
                {
                    Projectile projectile = Main.projectile[Projectile.NewProjectile(Projectile.GetSource_FromThis(),
                        Projectile.Center - new Vector2(0, i * 5), velocity,
                    ProjectileID.FairyQueenRangedItemShot, Projectile.damage, Projectile.knockBack,
                    player.whoAmI)]; // Change the projectile type depending on the bow

                    projectile.usesLocalNPCImmunity = true;
                }
            }
        }
    }
}
