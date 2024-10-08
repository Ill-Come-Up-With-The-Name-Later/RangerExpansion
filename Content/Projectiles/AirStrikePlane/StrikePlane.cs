using Terraria.ID;
using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace UltimateRangerExpansion.Content.Projectiles.AirStrikePlane
{
    class StrikePlane : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            Main.projFrames[Projectile.type] = 2;
        }

        public override void SetDefaults()
        {
            Projectile.width = 58;
            Projectile.height = 26;

            Projectile.timeLeft = 180;
        }

        public override void AI()
        {
            Projectile.rotation = Projectile.velocity.ToRotation();

            if (Projectile.timeLeft % 30 == 0)
            {
                if (Projectile.owner == Main.myPlayer)
                {
                    Vector2 velocity = new(Projectile.velocity.X / 10, 2);

                    Projectile proj = Main.projectile[Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center,
                            velocity, ProjectileID.RocketI, 200, 3, Main.myPlayer)];

                    proj.netUpdate = true;
                    proj.usesLocalNPCImmunity = true;
                }

                int frameSpeed = 5;
                Projectile.frameCounter++;

                if (Projectile.frameCounter >= frameSpeed)
                {
                    Projectile.frameCounter = 0;
                    Projectile.frame++;

                    if (Projectile.frame >= Main.projFrames[Projectile.type])
                    {
                        Projectile.frame = 0;
                    }
                }
            }
        }
    }
}
