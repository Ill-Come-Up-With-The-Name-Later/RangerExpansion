using Terraria;
using Terraria.ModLoader;
using UltimateRangerExpansion.Content.Projectiles.ZenithBow.CopperBow;
using Microsoft.Xna.Framework;

namespace UltimateRangerExpansion.Content.Projectiles.ZenithBow.Pinnacle
{
    class PinnacleProjectile : ModProjectile
    {
        public override string Texture => $"{nameof(UltimateRangerExpansion)}/Content/Items/Bows/Pinnacle/PinnacleBow";

        public override void SetDefaults()
        {
            Projectile.CloneDefaults(ModContent.ProjectileType<CopperBowProjectile>());

            Projectile.width = 28;
            Projectile.height = 46;
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
