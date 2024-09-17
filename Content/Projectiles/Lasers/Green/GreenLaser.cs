using Terraria.ModLoader;
using Terraria;
using Microsoft.Xna.Framework;

namespace UltimateRangerExpansion.Content.Projectiles.Lasers.Green
{
    internal class GreenLaser : ModProjectile
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
            Projectile.alpha = 0;
            Projectile.light = 0.2f;
            Projectile.ignoreWater = false;
            Projectile.tileCollide = true;
            Projectile.extraUpdates = 1;
            Projectile.damage = 0;
        }

        public override void AI()
        {
            // Stay still
            Projectile.velocity = new Vector2(0, 0);
        }
    }
}
