using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;
using UltimateRangerExpansion.Content.Items.Slingshots.Wooden;

namespace UltimateRangerExpansion.Content.Items.Slingshots.Pearlwood
{
    class PearlwoodSlingshot : ModItem, ISlingShot
    {
        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 1;
        }

        public override void SetDefaults()
        {
            Item.CloneDefaults(ModContent.ItemType<WoodSlingshot>());

            Item.damage = 30;

            Item.useTime -= 20;
            Item.useAnimation -= 20;
            Item.shootSpeed += 14;

            Item.crit += 9;

            Item.value += 1000;
        }

        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-12, 0);
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.Pearlwood, 5)
                .AddIngredient(ItemID.Silk)
                .AddTile(TileID.Anvils)
                .Register();
        }
    }
}
