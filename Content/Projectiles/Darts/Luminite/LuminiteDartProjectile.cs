using Terraria.ID;
using Terraria.ModLoader;
using Terraria;

namespace UltimateRangerExpansion.Content.Projectiles.Darts.Luminite
{
    class LuminiteDartProjectile : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.width = 14;
            Projectile.height = 28;
            Projectile.aiStyle = 1;
            Projectile.friendly = true;
            Projectile.hostile = false;
            Projectile.DamageType = DamageClass.Ranged;
            Projectile.timeLeft = 400;
            Projectile.alpha = 255;
            Projectile.ignoreWater = true;
            Projectile.tileCollide = false;
            Projectile.penetrate = 10;
            Projectile.light = 0.2f;

            AIType = ProjectileID.CrystalDart;
        }

        public override void AI()
        {
            Player owner = Main.player[Projectile.owner];

            if (!(Main.myPlayer == owner.whoAmI)) // Prevent some potential odd behavior
            {
                Projectile.Kill();
                return;
            }

            Projectile.velocity *= 1.025f;

            if (Projectile.timeLeft % 15 == 0)
            {
                Projectile.damage += 1;
            }

            if (Projectile.timeLeft % 3 == 0)
            {
                Dust.NewDust(Projectile.position, 2, 2, DustID.Vortex);
            }
        }
    }
}
