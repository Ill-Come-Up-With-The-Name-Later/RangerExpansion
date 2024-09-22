using System;
using Terraria.ID;
using Terraria;
using Terraria.ModLoader;
using UltimateRangerExpansion.Content.Projectiles.ZenithBow.CopperBow;
using Microsoft.Xna.Framework;

namespace UltimateRangerExpansion.Content.Projectiles.ZenithBow.Tsunami
{
    class TsunamiProjectile : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.CloneDefaults(ModContent.ProjectileType<CopperBowProjectile>());

            Projectile.width = 28;
            Projectile.height = 58;
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

            Projectile.velocity = Vector2.Zero;

            // Rotate projectile to face the mouse
            Vector2 mousePos = Main.MouseWorld;
            Vector2 direction = mousePos - Projectile.position;

            Projectile.rotation = direction.ToRotation();
        }
    }
}
