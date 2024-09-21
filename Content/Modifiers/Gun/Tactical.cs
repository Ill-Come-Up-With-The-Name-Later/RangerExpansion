using Terraria.ID;
using Terraria;
using Terraria.ModLoader;

namespace UltimateRangerExpansion.Content.Modifiers.Gun
{
    class Tactical : ModPrefix
    {
        public override PrefixCategory Category => PrefixCategory.Ranged;

        public override float RollChance(Item item)
        {
            return 3f;
        }

        public override bool CanRoll(Item item)
        {
            if (item.useAmmo == AmmoID.Bullet)
                return true;

            return false;
        }

        public override void SetStats(ref float damageMult, ref float knockbackMult, ref float useTimeMult, ref float scaleMult, ref float shootSpeedMult, ref float manaMult, ref int critBonus)
        {
            damageMult = 0.9f;
            critBonus = 10;
            shootSpeedMult = 1.15f;
        }

        public override void ModifyValue(ref float valueMult)
        {
            valueMult *= 1.1f;
        }
    }
}
