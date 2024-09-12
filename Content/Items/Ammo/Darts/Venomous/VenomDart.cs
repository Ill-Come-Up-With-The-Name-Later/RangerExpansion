using RangerExpansion.Content.Projectiles.Darts.Venomous;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace RangerExpansion.Content.Items.Ammo.Darts.Venomous
{
    class VenomDart : ModItem
    {
        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 99;
        }

        public override void SetDefaults()
        {
            Item.damage = 11;
            Item.DamageType = DamageClass.Ranged;
            Item.width = 14;
            Item.height = 24;
            Item.maxStack = 9999;
            Item.knockBack = 2;
            Item.consumable = true;
            Item.value = Item.buyPrice(0, 0, 1, 40);
            Item.rare = ItemRarityID.LightRed;
            Item.shoot = ModContent.ProjectileType<VenomousDartProjectile>();
            Item.shootSpeed = 3;
            Item.ammo = AmmoID.Dart;
        }

        public override void AddRecipes()
        {
            CreateRecipe(100)
                .AddIngredient(ItemID.SpiderFang, 1)
                .Register();
        }
    }
}
