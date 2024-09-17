using Terraria.ID;
using Terraria.ModLoader;
using UltimateRangerExpansion.Content.Items.Ammo.Rocks.Iron;
using UltimateRangerExpansion.Content.Projectiles.Rocks.Lead;

namespace UltimateRangerExpansion.Content.Items.Ammo.Rocks.Lead
{
    class LeadBall : ModItem
    {
        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 99;
        }

        public override void SetDefaults()
        {
            Item.CloneDefaults(ModContent.ItemType<IronBall>());

            Item.shoot = ModContent.ProjectileType<LeadBallProjectile>();
        }

        public override void AddRecipes()
        {
            CreateRecipe(4)
                .AddIngredient(ItemID.LeadOre)
                .AddTile(TileID.Furnaces)
                .Register();
        }
    }
}
