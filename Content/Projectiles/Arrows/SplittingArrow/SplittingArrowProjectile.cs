using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace UltimateRangerExpansion.Content.Projectiles.Arrows.SplittingArrow
{
    class SplittingArrowProjectile : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.CloneDefaults(ProjectileID.WoodenArrowFriendly);
            Projectile.timeLeft = 2400;
        }

        public override void AI()
        {
            Player owner = Main.player[Projectile.owner];

            Projectile.rotation += MathHelper.Pi;

            if(Projectile.timeLeft == 2399)
            {
                for (int i = 0; i < 2; i++)
                {
                    float rotation = MathHelper.ToRadians(5);
                    Vector2 velocity = Projectile.velocity.RotatedByRandom(MathHelper.Lerp(-rotation, rotation, 1));

                    Projectile.NewProjectile(owner.GetSource_FromThis(), Projectile.position,
                        velocity, ProjectileID.WoodenArrowFriendly, Projectile.damage, Projectile.knockBack);
                }
            }
        }
    }
}
