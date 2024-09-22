using Terraria.ID;
using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using System;

namespace UltimateRangerExpansion.Content.Projectiles.ZenithBow.CopperBow
{
    class CopperBowProjectile : ModProjectile
    {
        public static readonly int lifeSpan = 240;

        public override void SetDefaults()
        {
            Projectile.width = 16;
            Projectile.height = 32;

            Projectile.aiStyle = 0;
            Projectile.friendly = false;
            Projectile.hostile = false;
            Projectile.DamageType = DamageClass.Ranged;
            Projectile.timeLeft = lifeSpan;
            Projectile.alpha = 0;
            Projectile.light = 0.6f;
            Projectile.ignoreWater = true;
            Projectile.tileCollide = false;
            Projectile.penetrate = 1;
            Projectile.extraUpdates = 6;

            Projectile.damage = 50;
        }

        public override void AI()
        {
            Player player = Main.player[Projectile.owner];

            if (Main.myPlayer != Projectile.owner)
            {
                Projectile.Kill();
                return;
            }

            Projectile.alpha += 255 / lifeSpan;

            // Spawn dust particles
            if (Projectile.timeLeft % 3 == 0)
            {
                Dust.NewDust(Projectile.position, 1, 1, DustID.TintableDustLighted, -Projectile.velocity.X / 3, -Projectile.velocity.Y / 3,
                        newColor: new Color(new Random().Next(0, 255), new Random().Next(0, 255), new Random().Next(0, 255)));
            }

            Projectile.velocity = player.velocity; // Keep projectile near player

            // Rotate projectile to face the mouse
            Vector2 mousePos = Main.MouseWorld;
            Vector2 direction = mousePos - Projectile.position;

            Projectile.rotation = direction.ToRotation();
        }
    }
}
