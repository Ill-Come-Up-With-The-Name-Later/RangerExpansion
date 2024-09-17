using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;
using UltimateRangerExpansion.Content.Items.Slingshots.Tungsten;

namespace UltimateRangerExpansion.Content.Items.Slingshots.Silver
{
    class SilverSlingshot : ModItem
    {
        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 1;
        }

        public override void SetDefaults()
        {
            Item.CloneDefaults(ModContent.ItemType<TungstenSlingshot>());
        }

        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-12, 0);
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.SilverBar, 5)
                .AddIngredient(ItemID.Silk)
                .AddTile(TileID.Anvils)
                .Register();
        }
    }
}
