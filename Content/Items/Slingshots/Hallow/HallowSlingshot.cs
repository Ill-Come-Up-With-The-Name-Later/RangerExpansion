using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;
using UltimateRangerExpansion.Content.Items.Slingshots.Wooden;

namespace UltimateRangerExpansion.Content.Items.Slingshots.Hallow
{
    internal class HallowSlingshot : ModItem
    {
        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 1;
        }

        public override void SetDefaults()
        {
            Item.CloneDefaults(ModContent.ItemType<WoodSlingshot>());

            Item.damage = 40;

            Item.useTime -= 22;
            Item.useAnimation -= 22;
            Item.shootSpeed += 16;

            Item.crit += 10;

            Item.rare = ItemRarityID.LightPurple;

            Item.value += 100000;
        }

        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-12, 0);
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.HallowedBar, 5)
                .AddIngredient(ItemID.Silk)
                .AddTile(TileID.Anvils)
                .Register();
        }
    }
}
