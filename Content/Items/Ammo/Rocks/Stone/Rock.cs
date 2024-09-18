using Terraria.ID;
using Terraria.ModLoader;
using UltimateRangerExpansion.Content.DamageClasses;
using UltimateRangerExpansion.Content.Projectiles.Rocks.Stone;

namespace UltimateRangerExpansion.Content.Items.Ammo.Rocks.Stone
{
    class Rock : ModItem
    {
        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 99;
        }

        public override void SetDefaults()
        {
            Item.damage = 1;
            Item.DamageType = ModContent.GetInstance<SlingshotRanger>();
            Item.width = 16;
            Item.height = 14;
            Item.maxStack = 9999;
            Item.knockBack = 1;
            Item.consumable = true;
            Item.value = 10;
            Item.rare = ItemRarityID.White;
            Item.shoot = ModContent.ProjectileType<RockProjectile>();
            Item.shootSpeed = 3f;
            Item.ammo = ModContent.ItemType<Rock>();
        }

        public override void AddRecipes()
        {
            CreateRecipe(4)
                .AddIngredient(ItemID.StoneBlock)
                .AddTile(TileID.WorkBenches)
                .Register();
        }
    }
}
