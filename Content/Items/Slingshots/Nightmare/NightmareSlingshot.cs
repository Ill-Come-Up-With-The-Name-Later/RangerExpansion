using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using UltimateRangerExpansion.Content.Items.Slingshots.Wooden;
using Microsoft.Xna.Framework;

namespace UltimateRangerExpansion.Content.Items.Slingshots.Nightmare
{
    class NightmareSlingshot : ModItem
    {
        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 1;
        }

        public override void SetDefaults()
        {
            Item.CloneDefaults(ModContent.ItemType<WoodSlingshot>());

            Item.damage = 15;

            Item.useTime -= 15;
            Item.useAnimation -= 15;
            Item.shootSpeed += 10;

            Item.crit += 10;

            Item.rare = ItemRarityID.Blue;

            Item.value += 3000;
        }

        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-12, 0);
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.DemoniteBar, 5)
                .AddIngredient(ItemID.Silk)
                .AddTile(TileID.Anvils)
                .Register();
        }
    }
}
