using Terraria;
using Terraria.ModLoader;

namespace UltimateRangerExpansion.Content.Modifiers.Ranged
{
    class Maiming : ModPrefix
    {
        public override PrefixCategory Category => PrefixCategory.Ranged;

        public override float RollChance(Item item)
        {
            return 3f;
        }

        public override bool CanRoll(Item item)
        {
            return true;
        }

        public override void SetStats(ref float damageMult, ref float knockbackMult, ref float useTimeMult, ref float scaleMult, ref float shootSpeedMult, ref float manaMult, ref int critBonus)
        {
            damageMult = 1.5f;
            critBonus += 20;
            shootSpeedMult *= 3;
            useTimeMult *= 1.33f;
        }

        public override void ModifyValue(ref float valueMult)
        {
            valueMult *= 1.44f;
        }
    }
}
