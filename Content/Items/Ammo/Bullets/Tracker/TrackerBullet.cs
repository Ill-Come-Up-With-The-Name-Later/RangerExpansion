using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using UltimateRangerExpansion.Content.Projectiles.Bullets.Tracker;

namespace UltimateRangerExpansion.Content.Items.Ammo.Bullets.Tracker
{
    class TrackerBullet : ModItem
    {
        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 99;
        }

        public override void SetDefaults()
        {
            Item.damage = 9;
            Item.DamageType = DamageClass.Ranged;
            Item.width = 12;
            Item.height = 12;
            Item.maxStack = 9999;
            Item.knockBack = 4.5f;
            Item.consumable = true;
            Item.value = Item.buyPrice(0, 0, 20, 5);
            Item.rare = ItemRarityID.Lime;
            Item.shoot = ModContent.ProjectileType<TrackerBulletProjectile>();
            Item.shootSpeed = 25f;
            Item.ammo = AmmoID.Bullet;
        }

        public override void AddRecipes()
        {
            CreateRecipe(50)
                .AddIngredient(ItemID.ChlorophyteBullet, 50)
                .AddIngredient(ItemID.HallowedBar, 1)
                .AddTile(TileID.MythrilAnvil)
                .Register();
        }
    }
}
