﻿using Terraria;
using Terraria.ModLoader;

namespace UltimateRangerExpansion.Content.Modifiers.Ranged
{
    class Focused : ModPrefix
    {
        public override PrefixCategory Category => PrefixCategory.Ranged;

        public override float RollChance(Item item)
        {
            return 4f;
        }

        public override bool CanRoll(Item item)
        {
            return true;
        }

        public override void SetStats(ref float damageMult, ref float knockbackMult, ref float useTimeMult, ref float scaleMult, ref float shootSpeedMult, ref float manaMult, ref int critBonus)
        {
            damageMult *= 1.15f;
            useTimeMult *= 1.1f;
        }

        public override void ModifyValue(ref float valueMult)
        {
            valueMult *= 1.2f;
        }
    }
}
