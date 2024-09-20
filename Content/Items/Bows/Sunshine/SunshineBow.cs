using Terraria.ID;
using Terraria.ModLoader;
using Terraria;

namespace UltimateRangerExpansion.Content.Items.Bows.Sunshine
{
    class SunshineBow : ModItem
    {
        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 1;
        }

        public override void SetDefaults()
        {
            // Common Properties
            Item.width = 22;
            Item.height = 42;
            Item.rare = ItemRarityID.Red;

            // Use Properties
            Item.useTime = 12;
            Item.useAnimation = 12;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.autoReuse = true;

            // Weapon Properties
            Item.DamageType = DamageClass.Ranged;
            Item.damage = 54;
            Item.knockBack = 5f;
            Item.noMelee = true;

            // Bow Properties
            Item.shootSpeed = 20f;
            Item.useAmmo = AmmoID.Arrow;
            Item.shoot = ProjectileID.WoodenArrowFriendly;

            Item.value = Item.buyPrice(0, 40, 20, 50);

            Item.UseSound = SoundID.Item5;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
               .AddIngredient(ItemID.SoulofFlight, 5)
               .AddIngredient(ItemID.FragmentSolar, 10)
               .AddIngredient(ItemID.Phantasm)
               .AddTile(TileID.LunarCraftingStation)
               .Register();
        }
    }
}
