using Terraria.ModLoader;
using Terraria;
using Terraria.ID;

namespace UltimateRangerExpansion.Content.Modifiers.Gun
{
    class Crippling : ModPrefix
    {
        public override PrefixCategory Category => PrefixCategory.Ranged;

        public override float RollChance(Item item)
        {
            return 2f;
        }

        public override bool CanRoll(Item item)
        {
            if(item.useAmmo == AmmoID.Bullet)
                return true;

            return false;
        }

        public override void SetStats(ref float damageMult, ref float knockbackMult, ref float useTimeMult, ref float scaleMult, ref float shootSpeedMult, ref float manaMult, ref int critBonus)
        {
            damageMult = 2.2f;
            critBonus += 30;
            shootSpeedMult *= 5;
            useTimeMult *= 1.45f;
        }

        public override void ModifyValue(ref float valueMult)
        {
            valueMult *= 1.36f;
        }
    }
}
