using Terraria.ID;
using Terraria.ModLoader;
using UltimateRangerExpansion.Content.Projectiles.Arrows.SplittingArrow;

namespace UltimateRangerExpansion.Content.Items.Ammo.Arrows.SplitterArrow
{
    class SplittingArrow : ModItem
    {
        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 99;
        }

        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.WoodenArrow);

            Item.damage = 3;

            Item.rare = ItemRarityID.LightRed;

            Item.shoot = ModContent.ProjectileType<SplittingArrowProjectile>();
        }

        public override void AddRecipes()
        {
            CreateRecipe(40)
                .AddIngredient(ItemID.WoodenArrow, 120)
                .AddTile(TileID.CrystalBall)
                .Register();
        }
    }
}
