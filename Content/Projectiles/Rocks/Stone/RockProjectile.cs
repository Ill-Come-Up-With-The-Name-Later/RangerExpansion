using Terraria;
using Terraria.ModLoader;

namespace UltimateRangerExpansion.Content.Projectiles.Rocks.Stone
{
    class RockProjectile : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.width = 16;
            Projectile.height = 14;
            Projectile.aiStyle = 1;
            Projectile.friendly = true;
            Projectile.hostile = false;
            Projectile.DamageType = DamageClass.Ranged;
            Projectile.timeLeft = 400;
            Projectile.alpha = 0;
            Projectile.ignoreWater = false;
            Projectile.tileCollide = true;
        }

        public override void AI()
        {
            Player owner = Main.player[Projectile.owner];

            if (!(Main.myPlayer == owner.whoAmI)) // Prevent some potential odd behavior
            {
                Projectile.Kill();
                return;
            }

            Projectile.velocity.Y -= 0.02f;
            Projectile.rotation += 2;
        }
    }
}
