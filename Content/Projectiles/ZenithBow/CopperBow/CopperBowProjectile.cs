using Terraria.ID;
using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using System;

namespace UltimateRangerExpansion.Content.Projectiles.ZenithBow.CopperBow
{
    class CopperBowProjectile : ModProjectile
    {
        public static readonly int lifeSpan = 300;

        public override void SetDefaults()
        {
            Projectile.width = 16;
            Projectile.height = 32;

            Projectile.aiStyle = 0;
            Projectile.friendly = true;
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

            Projectile.velocity = Vector2.Zero;

            // Rotate projectile to face the mouse
            Vector2 mousePos = Main.MouseWorld;
            Vector2 direction = mousePos - Projectile.position;

            Projectile.rotation = direction.ToRotation();
        }
    }
}
