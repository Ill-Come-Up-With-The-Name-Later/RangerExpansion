using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace UltimateRangerExpansion.Common.Global
{
    class GrenadeAmmo : GlobalItem
    {
        public override void SetDefaults(Item entity)
        {
            switch (entity.type)
            {
                case ItemID.Grenade:
                    entity.ammo = ItemID.Grenade;
                    break;
                case ItemID.BouncyGrenade:
                    entity.ammo = ItemID.Grenade;
                    break;
                case ItemID.PartyGirlGrenade:
                    entity.ammo = ItemID.Grenade;
                    break;
                case ItemID.Beenade:
                    entity.ammo = ItemID.Grenade;
                    break;
            }
        }
    }
}
