using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using UltimateRangerExpansion.Utils;

namespace UltimateRangerExpansion.Content.Projectiles.Arrows.HomingArrow
{
    class HomingArrowProjectile : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.CloneDefaults(ProjectileID.WoodenArrowFriendly);
            Projectile.timeLeft = 2400;
        }

        public override void AI()
        {
            Projectile.rotation += MathHelper.Pi;

            NPC npc = Utilities.ClosestNPC(Projectile.position, 900);

            if (Projectile.timeLeft % 5 == 0)
                for(int i = 0; i < 9; i++)
                    Dust.NewDust(Projectile.position, 1, 1, DustID.Blood);

            if (npc != null)
            {
                Vector2 npcPos = npc.position;
                Vector2 velocity = npcPos - Projectile.position;
                velocity.Normalize();
                velocity *= 15;

                Projectile.velocity = velocity;
            }
        }
    }
}
