using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using Microsoft.Xna.Framework;

namespace RangerExpansion.Content.Projectiles.Darts.Luminite
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
            Projectile.timeLeft = 800;
            Projectile.alpha = 255;
            Projectile.ignoreWater = true;
            Projectile.tileCollide = true;
            Projectile.penetrate = 10;
            Projectile.light = 0.2f;

            AIType = ProjectileID.CrystalDart;
        }

        public override void AI()
        {
            if(Projectile.timeLeft % 3 == 0)
            {
                Dust.NewDust(Projectile.position, 2, 2, DustID.Vortex);
            }
        }

        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            Player owner = Main.player[Projectile.owner];
            Vector2 velocity = target.position - owner.position;

            Projectile.NewProjectile(owner.GetSource_FromThis(), owner.position, velocity, ModContent.ProjectileType<LuminiteDartProjectile>(), 
                Projectile.damage, Projectile.knockBack);
        }
    }
}
