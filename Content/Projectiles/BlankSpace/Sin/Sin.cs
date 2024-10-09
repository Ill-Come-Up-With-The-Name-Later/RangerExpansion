using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using UltimateRangerExpansion.Utils;

namespace UltimateRangerExpansion.Content.Projectiles.BlankSpace.Sin
{
    class Sin : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            ProjectileID.Sets.TrailCacheLength[Projectile.type] = 5;
            ProjectileID.Sets.TrailingMode[Projectile.type] = 0;
        }

        public override void SetDefaults()
        {
            Projectile.width = 18;
            Projectile.height = 20;
            Projectile.aiStyle = 1;
            Projectile.friendly = true;
            Projectile.hostile = false;
            Projectile.DamageType = DamageClass.Ranged;
            Projectile.timeLeft = 600;
            Projectile.light = 0.5f;
            Projectile.ignoreWater = false;
            Projectile.tileCollide = true;

            Projectile.usesLocalNPCImmunity = true;

            AIType = ProjectileID.Bullet;
        }

        public override void AI()
        {
            if(Projectile.timeLeft % 10 == 0)
                Dust.NewDust(Projectile.position, 1, 1, DustID.FlameBurst, Projectile.velocity.X / 2, Projectile.velocity.Y / 2);

            NPC npc = Utilities.ClosestNPC(Projectile.position, 600);

            if (npc != null)
            {
                Vector2 npcPos = npc.position;
                Vector2 velocity = npcPos - Projectile.position;
                velocity.Normalize();
                velocity *= 25;

                Projectile.velocity = velocity;
            }
        }
    }
}
