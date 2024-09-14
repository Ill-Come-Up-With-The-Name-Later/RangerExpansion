using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace UltimateRangerExpansion.Content.Projectiles.Bullets.Duplex
{
    class DuplexBulletProjectile : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            ProjectileID.Sets.TrailCacheLength[Projectile.type] = 5;
            ProjectileID.Sets.TrailingMode[Projectile.type] = 0;
        }

        public override void SetDefaults()
        {
            Projectile.width = 12;
            Projectile.height = 24;
            Projectile.aiStyle = 1;
            Projectile.friendly = true;
            Projectile.hostile = false;
            Projectile.DamageType = DamageClass.Ranged;
            Projectile.timeLeft = 600;
            Projectile.alpha = 255;
            Projectile.light = 0.5f;
            Projectile.ignoreWater = false;
            Projectile.tileCollide = true;

            AIType = ProjectileID.Bullet;
        }

        public override void AI()
        {
            Player owner = Main.player[Projectile.owner];

            if (!(Main.myPlayer == owner.whoAmI)) // Prevent some potential odd behavior
            {
                Projectile.Kill();
                return;
            }

            // Spawn second projectile with random rotation and rotate original projectile
            if (Projectile.timeLeft == 599)
            {
                Projectile.velocity *= 1.5f;

                float rotation = MathHelper.ToRadians(5);
                Vector2 velocity = Projectile.velocity.RotatedByRandom(MathHelper.Lerp(-rotation, rotation, 1));
                Vector2 velocity2 = Projectile.velocity.RotatedByRandom(MathHelper.Lerp(-rotation, rotation, 1));

                Projectile.velocity = velocity2;

                Projectile.NewProjectile(owner.GetSource_FromThis(), Projectile.position,
                    velocity * 0.45f, ProjectileID.Bullet, Projectile.damage, Projectile.knockBack);
            }
        }
    }
}
