using Terraria.ModLoader;
using Terraria;
using System.Collections.Generic;
using Terraria.Localization;

namespace UltimateRangerExpansion.Content.Modifiers.Ranged
{
    class Piercing : ModPrefix
    {
        public override PrefixCategory Category => PrefixCategory.Ranged;
        public static LocalizedText ArmorPiercingTooltip { get; private set; }

        private readonly int armorPenetration = 5;

        public override void SetStaticDefaults()
        {
            ArmorPiercingTooltip = Mod.GetLocalization($"{LocalizationCategory}.{nameof(ArmorPiercingTooltip)}");
        }

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
            damageMult *= 0.95f;
            shootSpeedMult *= 1.15f;
            useTimeMult *= 1.1f;
        }

        public override void Apply(Item item)
        {
            item.ArmorPenetration += armorPenetration;
        }

        public override IEnumerable<TooltipLine> GetTooltipLines(Item item)
        {
            yield return new TooltipLine(Mod, "ArmorPenetration", ArmorPiercingTooltip.Format(armorPenetration)) { IsModifier = true };
        }

        public override void ModifyValue(ref float valueMult)
        {
            valueMult *= 1.2f;
        }
    }
}
