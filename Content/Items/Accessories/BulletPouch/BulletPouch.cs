using Terraria.ID;
using Terraria.ModLoader;
using Terraria;

namespace UltimateRangerExpansion.Content.Items.Accessories.BulletPouch
{
    class BulletPouch : ModItem
    {
        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 26;
            Item.height = 34;

            Item.accessory = true;
            Item.rare = ItemRarityID.LightRed;
            Item.value = Item.buyPrice(0, 7, 0, 0);
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.ammoCost75 = true;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.EndlessMusketPouch)
                .AddTile(TileID.TinkerersWorkbench)
                .Register();
        }
    }
}
