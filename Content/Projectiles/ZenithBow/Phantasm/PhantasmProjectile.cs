using Terraria;
using Terraria.ModLoader;
using UltimateRangerExpansion.Content.Projectiles.ZenithBow.CopperBow;
using Microsoft.Xna.Framework;

namespace UltimateRangerExpansion.Content.Projectiles.ZenithBow.Phantasm
{
    class PhantasmProjectile : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.CloneDefaults(ModContent.ProjectileType<CopperBowProjectile>());

            Projectile.width = 32;
            Projectile.height = 54;
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
