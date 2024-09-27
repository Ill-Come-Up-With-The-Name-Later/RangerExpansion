using Terraria.ID;
using Terraria.ModLoader;
using Terraria;

namespace UltimateRangerExpansion.Content.Items.Guns.UpgradedStarShooter
{
    class StellarBlaster : ModItem
    {
        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 1;
        }

        public override void SetDefaults()
        {
            // Common Properties
            Item.width = 56;
            Item.height = 22;
            Item.rare = ItemRarityID.Red;

            // Use Properties
            Item.useTime = 45;
            Item.useAnimation = 45;
            Item.reuseDelay = 45;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.autoReuse = true;
            Item.consumeAmmoOnLastShotOnly = true;

            // Weapon Properties
            Item.DamageType = DamageClass.Ranged;
            Item.damage = 750;
            Item.knockBack = 6f;
            Item.noMelee = true;

            // Gun Properties
            Item.shoot = ProjectileID.SuperStar;
            Item.shootSpeed = 18f;
            Item.useAmmo = AmmoID.FallenStar;

            Item.value = Item.buyPrice(0, 45, 20, 50);
        }
    }
}
