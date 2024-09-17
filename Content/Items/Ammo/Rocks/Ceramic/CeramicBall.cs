using Terraria.ID;
using Terraria.ModLoader;
using UltimateRangerExpansion.Content.Items.Ammo.Rocks.Stone;
using UltimateRangerExpansion.Content.Projectiles.Rocks.Ceramic;

namespace UltimateRangerExpansion.Content.Items.Ammo.Rocks.Ceramic
{
    class CeramicBall : ModItem
    {
        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 99;
        }

        public override void SetDefaults()
        {
            Item.CloneDefaults(ModContent.ItemType<Rock>());

            Item.width = 16;
            Item.height = 16;

            Item.damage = 5;
            Item.knockBack = 2;
            Item.shootSpeed += 2;

            Item.shoot = ModContent.ProjectileType<CeramicBallProjectile>();
        }

        public override void AddRecipes()
        {
            CreateRecipe(4)
                .AddIngredient(ItemID.ClayBlock)
                .AddTile(TileID.Furnaces)
                .Register();
        }
    }
}
