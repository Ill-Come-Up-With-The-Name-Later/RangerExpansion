using Terraria.ModLoader;
using UltimateRangerExpansion.Content.Rarities;
using UltimateRangerExpansion.Content.Tiles.Paintings.Danger;
using Terraria;

namespace UltimateRangerExpansion.Content.Items.Paintings.Danger
{
    class DangerPainting : ModItem
    {
        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 1;
        }

        public override void SetDefaults()
        {
            Item.DefaultToPlaceableTile(ModContent.TileType<DangerPaintingTile>(), 0);

            Item.width = 48;
            Item.height = 32;
            Item.maxStack = 9999;
            Item.rare = ModContent.RarityType<DeveloperRarity>();

            Item.value = Item.buyPrice(1, 0, 0, 0);
        }
    }
}
