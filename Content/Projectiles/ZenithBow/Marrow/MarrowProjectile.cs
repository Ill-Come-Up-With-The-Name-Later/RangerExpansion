using Terraria;
using Terraria.ModLoader;
using UltimateRangerExpansion.Content.Projectiles.ZenithBow.CopperBow;
using Microsoft.Xna.Framework;

namespace UltimateRangerExpansion.Content.Projectiles.ZenithBow.Marrow
{
    class MarrowProjectile : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.CloneDefaults(ModContent.ProjectileType<CopperBowProjectile>());

            Projectile.width = 22;
            Projectile.height = 36;
        }

        public override void AI()
        {
            if (Main.myPlayer != Projectile.owner)
            {
                Projectile.Kill();
                return;
            }

            Projectile.alpha += 255 / CopperBowProjectile.lifeSpan;

            Projectile.velocity = Vector2.Zero;
        }
    }
}
