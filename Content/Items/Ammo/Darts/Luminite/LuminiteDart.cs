using RangerExpansion.Content.Projectiles.Darts.Luminite;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace RangerExpansion.Content.Items.Ammo.Darts.Luminite
{
    class LuminiteDart : ModItem
    {
        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 99;
        }

        public override void SetDefaults()
        {
            Item.damage = 16;
            Item.DamageType = DamageClass.Ranged;
            Item.width = 14;
            Item.height = 28;
            Item.maxStack = 9999;
            Item.knockBack = 2;
            Item.consumable = true;
            Item.value = Item.buyPrice(0, 0, 7, 40);
            Item.rare = ItemRarityID.Cyan;
            Item.shoot = ModContent.ProjectileType<LuminiteDartProjectile>();
            Item.shootSpeed = 14;
            Item.ammo = AmmoID.Dart;
        }

        public override void AddRecipes()
        {
            CreateRecipe(200)
                .AddIngredient(ItemID.LunarBar, 1)
                .AddIngredient(ItemID.FragmentVortex)
                .AddTile(TileID.LunarCraftingStation)
                .Register();
        }
    }
}
