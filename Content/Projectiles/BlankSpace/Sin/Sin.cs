using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace UltimateRangerExpansion.Content.Projectiles.BlankSpace.Sin
{
    class Sin : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.width = 18;
            Projectile.height = 20;
            Projectile.aiStyle = 1;
            Projectile.friendly = true;
            Projectile.hostile = false;
            Projectile.DamageType = DamageClass.Ranged;
            Projectile.timeLeft = 600;
            Projectile.light = 0.5f;
            Projectile.ignoreWater = false;
            Projectile.tileCollide = true;

            AIType = ProjectileID.Bullet;
        }

        public override void AI()
        {
            Dust.NewDust(Projectile.position, 1, 1, DustID.FlameBurst, 0, 0);
        }
    }
}
