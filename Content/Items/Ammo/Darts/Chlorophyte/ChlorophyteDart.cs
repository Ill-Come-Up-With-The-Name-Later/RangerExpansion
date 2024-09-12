using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using RangerExpansion.Content.Projectiles.Darts.Chlorophyte;

namespace RangerExpansion.Content.Items.Ammo.Darts.Chlorophyte
{
    class ChlorophyteDart : ModItem
    {
        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 99;
        }

        public override void SetDefaults()
        {
            Item.damage = 13;
            Item.DamageType = DamageClass.Ranged;
            Item.width = 14;
            Item.height = 24;
            Item.maxStack = 9999;
            Item.knockBack = 3;
            Item.consumable = true;
            Item.value = Item.buyPrice(0, 0, 4, 40);
            Item.rare = ItemRarityID.Lime;
            Item.shoot = ModContent.ProjectileType<ChlorophyteDartProjectile>();
            Item.shootSpeed = 4;
            Item.ammo = AmmoID.Dart;
        }

        public override void AddRecipes()
        {
            CreateRecipe(50)
                .AddIngredient(ItemID.ChlorophyteBar, 1)
                .AddTile(TileID.MythrilAnvil)
                .Register();
        }
    }
}
