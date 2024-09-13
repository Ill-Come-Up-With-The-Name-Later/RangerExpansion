using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace RangerExpansion.Content.Projectiles.Bullets.Tracker
{
    class TrackerBulletProjectile : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            ProjectileID.Sets.TrailCacheLength[Projectile.type] = 1;
            ProjectileID.Sets.TrailingMode[Projectile.type] = 0;
        }

        public override void SetDefaults()
        {
            Projectile.width = 20;
            Projectile.height = 2;
            Projectile.aiStyle = 1;
            Projectile.friendly = true;
            Projectile.hostile = false;
            Projectile.DamageType = DamageClass.Ranged;
            Projectile.timeLeft = 1200;
            Projectile.alpha = 255;
            Projectile.light = 0.5f;
            Projectile.ignoreWater = false;
            Projectile.tileCollide = true;
            Projectile.scale = 0.1f;

            AIType = ProjectileID.ChlorophyteBullet;
        }

        public override void AI()
        {
            // Bullets seek out the cursor
            Vector2 cursorPos = Main.MouseWorld;
            Vector2 velocity = cursorPos - Projectile.position;

            velocity.Normalize();
            velocity *= RangerExpansion.DistanceBetween(cursorPos, Projectile.position);

            Projectile.velocity = velocity;
            Lighting.AddLight(Projectile.position, 0.0f, 0.45f, 0.45f);
        }
    }
}
