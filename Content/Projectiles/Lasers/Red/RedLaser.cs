using Microsoft.Xna.Framework;
using Terraria.ModLoader;

namespace RangerExpansion.Content.Projectiles.Lasers.Red
{
    internal class RedLaser : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.width = 2;
            Projectile.height = 500;
            Projectile.aiStyle = 0;
            Projectile.friendly = true;
            Projectile.hostile = false;
            Projectile.DamageType = DamageClass.Ranged;
            Projectile.timeLeft = 600;
            Projectile.alpha = 255;
            Projectile.light = 0.2f;
            Projectile.ignoreWater = false;
            Projectile.tileCollide = true;
            Projectile.extraUpdates = 1;
            Projectile.damage = 0;
        }

        public override void AI()
        {
            Projectile.velocity = new Vector2(0, 0);
        }
    }
}
