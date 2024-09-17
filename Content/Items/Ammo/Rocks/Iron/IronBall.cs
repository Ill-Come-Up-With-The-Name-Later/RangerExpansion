using Terraria.ID;
using Terraria.ModLoader;
using UltimateRangerExpansion.Content.Items.Ammo.Rocks.Stone;
using UltimateRangerExpansion.Content.Projectiles.Rocks.Iron;

namespace UltimateRangerExpansion.Content.Items.Ammo.Rocks.Iron
{
    class IronBall : ModItem
    {
        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 99;
        }

        public override void SetDefaults()
        {
            Item.CloneDefaults(ModContent.ItemType<Rock>());

            Item.width = 16;
            Item.height = 14;

            Item.damage = 7;
            Item.knockBack = 2;

            Item.shoot = ModContent.ProjectileType<IronBallProjectile>();
        }

        public override void AddRecipes()
        {
            CreateRecipe(4)
                .AddIngredient(ItemID.IronOre)
                .AddTile(TileID.Furnaces)
                .Register();
        }
    }
}
