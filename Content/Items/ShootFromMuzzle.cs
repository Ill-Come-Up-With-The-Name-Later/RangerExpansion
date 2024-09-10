using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace RangerExpansion.Content.Items
{
    class ShootFromMuzzle : GlobalItem
    {
        public override void ModifyShootStats(Item item, Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
        {
            if(item.DamageType == DamageClass.Ranged)
            {
                // Make projectiles come from muzzle
                Vector2 muzzleOffset = Vector2.Normalize(velocity) * item.width; // multiply normal velocity by gun length

                if (Collision.CanHit(position, 0, 0, position + muzzleOffset, 0, 0))
                {
                    position += muzzleOffset;
                }
            }
        }
    }
}
