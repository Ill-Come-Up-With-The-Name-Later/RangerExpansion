using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace UltimateRangerExpansion.Content.Modifiers.Ranged
{
    class Clockwork : ModPrefix
    {
        public override PrefixCategory Category => PrefixCategory.Ranged;

        public override float RollChance(Item item)
        {
            return 2f;
        }

        public override bool CanRoll(Item item)
        {
            if (item.useAnimation / 3 == item.useTime || item.consumeAmmoOnLastShotOnly)
                return false;

            if (item.type == ItemID.Phantasm)
                return false;

            return true;
        }

        public override void SetStats(ref float damageMult, ref float knockbackMult, ref float useTimeMult, ref float scaleMult, ref float shootSpeedMult, ref float manaMult, ref int critBonus)
        {
            useTimeMult *= 0.85f;
        }

        public override IEnumerable<TooltipLine> GetTooltipLines(Item item)
        {
            yield return new TooltipLine(Mod, "Clockwork", "Fires a burst of three shots.") { IsModifier = true };
        }

        public override void Apply(Item item)
        {
            item.useAnimation = item.useTime * 3;
            item.reuseDelay = item.useAnimation;
            item.consumeAmmoOnLastShotOnly = true;
        }

        public override void ModifyValue(ref float valueMult)
        {
            valueMult *= 1.25f;
        }
    }
}
