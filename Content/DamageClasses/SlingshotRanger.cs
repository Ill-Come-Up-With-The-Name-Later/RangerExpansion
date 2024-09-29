using Terraria.ModLoader;

namespace UltimateRangerExpansion.Content.DamageClasses
{
    class SlingshotRanger : DamageClass
    {
        public override bool UseStandardCritCalcs => true;

        public override StatInheritanceData GetModifierInheritance(DamageClass damageClass)
        {
            if(damageClass == DamageClass.Ranged || damageClass == DamageClass.Generic)
            {
                return StatInheritanceData.Full;
            }

            return StatInheritanceData.None;
        }

        public override bool GetEffectInheritance(DamageClass damageClass)
        {
            return damageClass == DamageClass.Ranged;
        }
    }
}
