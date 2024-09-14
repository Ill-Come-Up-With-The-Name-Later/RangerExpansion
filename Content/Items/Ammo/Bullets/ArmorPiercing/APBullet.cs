using Terraria.ID;
using Terraria.ModLoader;
using UltimateRangerExpansion.Content.Projectiles.Bullets.ArmorPiercing;

namespace UltimateRangerExpansion.Content.Items.Ammo.Bullets.ArmorPiercing
{
    class APBullet : ModItem
    {
        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 99;
        }

        public override void SetDefaults()
        {
            Item.damage = 10;
            Item.DamageType = DamageClass.Ranged;
            Item.width = 10;
            Item.height = 22;
            Item.maxStack = 9999;
            Item.knockBack = 3;
            Item.consumable = true;
            Item.value = 10;
            Item.rare = ItemRarityID.LightRed;
            Item.shoot = ModContent.ProjectileType<APBulletProjectile>();
            Item.shootSpeed = 22f;
            Item.ammo = AmmoID.Bullet;
            Item.ArmorPenetration = 15;
        }

        public override void AddRecipes()
        {
            CreateRecipe(100)
                .AddIngredient(ItemID.IronBar, 10)
                .AddIngredient(ItemID.EmptyBullet)
                .AddIngredient(ItemID.SoulofMight)
                .AddTile(TileID.Anvils);
        }
    }
}
