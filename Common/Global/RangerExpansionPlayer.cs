using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using UltimateRangerExpansion.Content.Buffs.Innacurate;

namespace UltimateRangerExpansion.Common.Global
{
    class RangerExpansionPlayer : ModPlayer
    {
        public bool reticle;
        private int spread = 8;

        public override void ResetEffects()
        {
            reticle = false;
        }

        public override void ModifyShootStats(Item item, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
        {
            if (item.DamageType == DamageClass.Ranged)
            {
                if (Player.HasBuff<Innacurate>())
                    spread += 4;

                if (!reticle || Player.HasBuff<Innacurate>())
                {
                    if (item.ammo == AmmoID.Arrow)
                    {
                        float rotation = MathHelper.ToRadians(spread / 2);
                        velocity = velocity.RotatedByRandom(MathHelper.Lerp(-rotation, rotation, 1));
                    }
                    else
                    {
                        float rotation = MathHelper.ToRadians(spread);
                        velocity = velocity.RotatedByRandom(MathHelper.Lerp(-rotation, rotation, 1));
                    }
                }
            }
        }
    }
}
