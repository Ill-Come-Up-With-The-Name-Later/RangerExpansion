using Terraria.ID;
using Terraria;
using Terraria.ModLoader;

namespace RangerExpansion.Content.Projectiles.Darts.Venomous
{
    class VenomousDartProjectile : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.width = 14;
            Projectile.height = 24;
            Projectile.aiStyle = 1;
            Projectile.friendly = true;
            Projectile.hostile = false;
            Projectile.DamageType = DamageClass.Ranged;
            Projectile.timeLeft = 800;
            Projectile.alpha = 255;
            Projectile.ignoreWater = false;
            Projectile.tileCollide = true;
            Projectile.light = 0.2f;

            AIType = ProjectileID.CrystalDart;
        }

        public override void AI()
        {
            if(Projectile.timeLeft % 3 == 0)
            {
                Dust.NewDust(Projectile.position, 2, 2, DustID.Venom);
            }
        }

        public override void ModifyHitNPC(NPC target, ref NPC.HitModifiers modifiers)
        {
            target.AddBuff(BuffID.Venom, 30 * 60);
        }
    }
}
