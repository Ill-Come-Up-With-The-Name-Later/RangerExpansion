using Terraria;
using Terraria.ModLoader;
using UltimateRangerExpansion.Content.Projectiles.Rocks.Stone;

namespace UltimateRangerExpansion.Content.Projectiles.Rocks.Ceramic
{
    class CeramicBallProjectile : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.CloneDefaults(ModContent.ProjectileType<RockProjectile>());

            Projectile.width = 16;
            Projectile.height = 16;
        }

        public override void AI()
        {
            Player owner = Main.player[Projectile.owner];

            if (!(Main.myPlayer == owner.whoAmI)) // Prevent some potential odd behavior
            {
                Projectile.Kill();
                return;
            }

            Projectile.velocity.Y += 0.075f;
            Projectile.rotation += 2;
        }
    }
}
