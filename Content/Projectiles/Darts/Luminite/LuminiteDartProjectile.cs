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
            Projectile.extraUpdates = 1;
            Projectile.penetrate = 10;;
        }

        public override void AI()
        {
            Player owner = Main.player[Projectile.owner];

            if(Projectile.timeLeft % 80 == 0) // Spawns two vortex beater rocket ten times over projectile lifespan
            {
                Projectile.NewProjectile(owner.GetSource_FromThis(), Projectile.position, new Vector2(Projectile.velocity.X / 2, -8),
                    ProjectileID.VortexBeaterRocket, Projectile.damage, Projectile.knockBack);
                Projectile.NewProjectile(owner.GetSource_FromThis(), Projectile.position, new Vector2(Projectile.velocity.X / 2, 8),
                    ProjectileID.VortexBeaterRocket, Projectile.damage, Projectile.knockBack);
            }
        }
    }
}
