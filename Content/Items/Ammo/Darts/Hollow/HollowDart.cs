using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using UltimateRangerExpansion.Content.Projectiles.Darts.Hollow;

namespace UltimateRangerExpansion.Content.Items.Ammo.Darts.Hollow
{
    class HollowDart : ModItem
    {
        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 99;
        }

        public override void SetDefaults()
        {
            Item.damage = 15;
            Item.DamageType = DamageClass.Ranged;
            Item.width = 14;
            Item.height = 24;
            Item.maxStack = 9999;
            Item.knockBack = 4f;
            Item.consumable = true;
            Item.value = Item.buyPrice(0, 0, 6, 40);
            Item.rare = ItemRarityID.LightPurple;
            Item.shoot = ModContent.ProjectileType<HollowDartProjectile>();
            Item.shootSpeed = 18;
            Item.ammo = AmmoID.Dart;
        }

        public override void AddRecipes()
        {
            CreateRecipe(333)
                .AddIngredient(ItemID.HallowedBar, 3)
                .AddTile(TileID.MythrilAnvil)
                .Register();
        }
    }
}
