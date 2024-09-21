using Terraria.ID;
using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using System;

namespace UltimateRangerExpansion.Content.Projectiles.ZenithBow.CopperBow
{
    class CopperBowProjectile : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.width = 16;
            Projectile.height = 32;

            Projectile.aiStyle = 0;
            Projectile.friendly = false;
            Projectile.hostile = false;
            Projectile.DamageType = DamageClass.Ranged;
            Projectile.timeLeft = 90;
            Projectile.alpha = 0;
            Projectile.light = 0.6f;
            Projectile.ignoreWater = true;
            Projectile.tileCollide = false;
        }

        public override void AI()
        {
            Player player = Main.player[Projectile.owner];

            if (Main.myPlayer != Projectile.owner)
            {
                Projectile.Kill();
                return;
            }

            // Hide other projectiles of the same type
            if(Projectile.timeLeft == 89)
            {
                for (int i = 0; i < Main.projectile.Length; i++)
                {
                    Projectile projectile = Main.projectile[i];

                    if (projectile.type == Type && projectile.whoAmI != Projectile.whoAmI && projectile.owner == Projectile.owner
                        && projectile.timeLeft < 88)
                    {
                        projectile.hide = true;
                    }
                }
            }

            // Spawn dust particles
            if(Projectile.timeLeft % 3 == 0)
            {
                Dust.NewDust(Projectile.position, 1, 1, DustID.TintableDustLighted, -Projectile.velocity.X / 3, -Projectile.velocity.Y / 3,
                        newColor: new Color(new Random().Next(0, 255), new Random().Next(0, 255), new Random().Next(0, 255)));
            }
            
            Projectile.velocity = player.velocity; // Keep projectile near player

            // Rotate projectile to face the mouse
            Vector2 mousePos = Main.MouseWorld;
            Vector2 direction = mousePos - Projectile.position;

            Projectile.rotation = direction.ToRotation();

            if (Projectile.timeLeft % 30 == 0) // Shoot every 30 ticks
            {
                // Shoot at the cursor
                Vector2 velocity = mousePos - Projectile.Center;

                Projectile projectile = Main.projectile[Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center, velocity, 
                    ProjectileID.WoodenArrowFriendly, Projectile.damage, Projectile.knockBack, 
                    player.whoAmI)]; // Change the projectile type depending on the bow

                projectile.tileCollide = false;
            }
        }
    }
}
