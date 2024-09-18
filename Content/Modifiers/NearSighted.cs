using Terraria;
using Terraria.ModLoader;
using UltimateRangerExpansion.Content.DamageClasses;

namespace UltimateRangerExpansion.Content.Modifiers
{
    class NearSighted : ModPrefix
    {
        public override PrefixCategory Category => PrefixCategory.Ranged;

        public override float RollChance(Item item)
        {
            return 5f;
        }

        public override bool CanRoll(Item item)
        {
            return item.DamageType == ModContent.GetInstance<SlingshotRanger>();
        }

        public override void SetStats(ref float damageMult, ref float knockbackMult, ref float useTimeMult, ref float scaleMult, ref float shootSpeedMult, ref float manaMult, ref int critBonus)
        {
            useTimeMult *= 0.75f;
            shootSpeedMult *= 0.66f;
            critBonus = 7;
            damageMult = 1.1f;
        }

        public override void ModifyValue(ref float valueMult)
        {
            valueMult *= 1.1f;
        }
    }
}
