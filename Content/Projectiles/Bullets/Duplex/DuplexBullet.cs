using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace RangerExpansion.Content.Projectiles.Bullets.Duplex
{
    class DuplexBullet : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            ProjectileID.Sets.TrailCacheLength[Projectile.type] = 5; 
            ProjectileID.Sets.TrailingMode[Projectile.type] = 0; 
        }

        public override void SetDefaults()
        {
            Projectile.width = 8; 
            Projectile.height = 8;
            Projectile.aiStyle = 1; 
            Projectile.friendly = true; 
            Projectile.hostile = false; 
            Projectile.DamageType = DamageClass.Ranged; 
            Projectile.timeLeft = 600;
            Projectile.alpha = 255; 
            Projectile.light = 0.5f; 
            Projectile.ignoreWater = false;
            Projectile.tileCollide = true; 
            Projectile.extraUpdates = 1; 

            AIType = ProjectileID.Bullet;
        }

        public override void AI()
        {
            Player owner = Main.player[Projectile.owner]; 

            if(Projectile.timeLeft == 599)
            {
                Projectile.NewProjectile(owner.GetSource_FromThis(), Projectile.position + new Vector2(0, 8),
                    Projectile.velocity, ProjectileID.Bullet, Projectile.damage, Projectile.knockBack);
            }
        }
    }
}
