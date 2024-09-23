using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System;

namespace UltimateRangerExpansion.Content.Projectiles.Bullets.Tracker
{
    class TrackerBulletProjectile : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            ProjectileID.Sets.TrailCacheLength[Projectile.type] = 1;
            ProjectileID.Sets.TrailingMode[Projectile.type] = 0;
            Main.projFrames[Projectile.type] = 2;
        }

        public override void SetDefaults()
        {
            Projectile.width = 12;
            Projectile.height = 12;
            Projectile.aiStyle = 1;
            Projectile.friendly = true;
            Projectile.hostile = false;
            Projectile.DamageType = DamageClass.Ranged;
            Projectile.timeLeft = 200;
            Projectile.alpha = 0;
            Projectile.light = 0.35f;
            Projectile.ignoreWater = false;
            Projectile.tileCollide = true;
            Projectile.scale = 0.75f;

            AIType = ProjectileID.ChlorophyteBullet;
        }

        public override void AI()
        {
            Player owner = Main.player[Projectile.owner];

            if (!(Main.myPlayer == owner.whoAmI)) // Prevent some potential odd behavior
            {
                Projectile.Kill();
                return;
            }

            // Increment projectile frames and make sure that it doesn't go above
            // the number of frames in the projectile animation
            if(++Projectile.frame >= Main.projFrames[Projectile.type])
                Projectile.frame = 0;

            // Bullets seek out the cursor
            Vector2 cursorPos = Main.MouseWorld;
            Vector2 velocity = cursorPos - Projectile.position;

            // Normalize the velocity to a direction then multiply it and scale speed with distance
            velocity.Normalize();
            velocity *= (float)Math.Atan(UltimateRangerExpansion.DistanceBetween(cursorPos, Projectile.position)) * 10;

            Projectile.velocity = velocity;
            Lighting.AddLight(Projectile.position, 0.0f, 0.3f, 0.3f);

            Projectile.rotation += 2;
        }
    }
}
