using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace RangerExpansion.Content.Projectiles.Darts.Chlorophyte
{
    class ChlorophyteDartProjectile : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.width = 14;
            Projectile.height = 24;
            Projectile.aiStyle = 1;
            Projectile.friendly = true;
            Projectile.hostile = false;
            Projectile.DamageType = DamageClass.Ranged;
            Projectile.timeLeft = 800;
            Projectile.alpha = 255;
            Projectile.ignoreWater = false;
            Projectile.tileCollide = true;
            Projectile.light = 0.2f;
            Projectile.penetrate = 6;

            AIType = ProjectileID.CrystalDart;
        }

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            Projectile.penetrate -= 1;
           
            if(Projectile.penetrate <= 0)
            {
                Projectile.Kill();
            }

            Projectile.velocity *= -1;

            return false;
        }
    }
}
