using System;
using Terraria.ID;
using Terraria;
using Terraria.ModLoader;
using UltimateRangerExpansion.Content.Projectiles.ZenithBow.CopperBow;
using Microsoft.Xna.Framework;

namespace UltimateRangerExpansion.Content.Projectiles.ZenithBow.DaedalusBow
{
    class DaedalusBowProjectile : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.CloneDefaults(ModContent.ProjectileType<CopperBowProjectile>());

            Projectile.width = 30;
            Projectile.height = 62;
        }

        public override void AI()
        {
            Player player = Main.player[Projectile.owner];

            if (Main.myPlayer != Projectile.owner)
            {
                Projectile.Kill();
                return;
            }

            Projectile.alpha += 255 / CopperBowProjectile.lifeSpan;

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
        }
    }
}
