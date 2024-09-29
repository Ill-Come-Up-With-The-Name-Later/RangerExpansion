using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;
using UltimateRangerExpansion.Content.Items.Slingshots.Wooden;

namespace UltimateRangerExpansion.Content.Items.Slingshots.Gold
{
    class GoldSlingshot : ModItem, ISlingShot
    {
        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 1;
        }

        public override void SetDefaults()
        {
            Item.CloneDefaults(ModContent.ItemType<WoodSlingshot>());

            Item.damage = 9;

            Item.useTime -= 12;
            Item.useAnimation -= 12;
            Item.shootSpeed += 8;

            Item.crit += 5;

            Item.value += 2000;
        }

        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-12, 0);
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.GoldBar, 5)
                .AddIngredient(ItemID.Silk)
                .AddTile(TileID.Anvils)
                .Register();
        }
    }
}
