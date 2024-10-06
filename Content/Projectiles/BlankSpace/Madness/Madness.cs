using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace UltimateRangerExpansion.Content.Projectiles.BlankSpace.Madness
{
    class Madness : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.width = 16;
            Projectile.height = 16;
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
            Dust.NewDust(Projectile.position, 1, 1, DustID.TintableDustLighted, 0, 0, newColor: Color.Red);
        }
    }
}
