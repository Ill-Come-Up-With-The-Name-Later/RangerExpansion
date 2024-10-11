using Terraria.ID;
using Terraria.ModLoader;
using UltimateRangerExpansion.Content.Projectiles.Arrows.HomingArrow;

namespace UltimateRangerExpansion.Content.Items.Ammo.Arrows.HomingArrow
{
    class HomingArrrow : ModItem
    {
        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 99;
        }

        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.WoodenArrow);

            Item.damage = 8;
            Item.crit = 3;

            Item.rare = ItemRarityID.LightPurple;

            Item.shoot = ModContent.ProjectileType<HomingArrowProjectile>();
        }

        public override void AddRecipes()
        {
            CreateRecipe(150)
                .AddIngredient(ItemID.WoodenArrow, 150)
                .AddIngredient(ItemID.SoulofSight, 5)
                .AddTile(TileID.MythrilAnvil)
                .Register();
        }
    }
}
