using Terraria.ID;
using Terraria.ModLoader;
using Terraria;

namespace UltimateRangerExpansion.Content.Items.MiscWeapons.GrenadeLauncher
{
    class GrenadeLauncher : ModItem
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
            Item.rare = ItemRarityID.LightRed;

            // Use Properties
            Item.useTime = 30;
            Item.useAnimation = 30;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.autoReuse = true;
            Item.UseSound = SoundID.Item61;

            // Weapon Properties
            Item.DamageType = DamageClass.Ranged;
            Item.damage = 45;
            Item.knockBack = 3.8f;
            Item.noMelee = true;
            Item.crit = 6;

            // Gun Properties
            Item.shoot = ProjectileID.Grenade;
            Item.shootSpeed = 12f;
            Item.useAmmo = ItemID.Grenade;

            Item.value = Item.buyPrice(0, 15, 10, 50);
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.HallowedBar, 15)
                .AddIngredient(ItemID.SoulofMight, 5)
                .AddIngredient(ItemID.SoulofFright, 5)
                .AddTile(TileID.MythrilAnvil)
                .Register();
        }
    }
}
