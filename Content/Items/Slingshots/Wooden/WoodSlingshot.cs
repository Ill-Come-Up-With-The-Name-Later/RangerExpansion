using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using UltimateRangerExpansion.Content.Projectiles.Rocks.Stone;
using UltimateRangerExpansion.Content.Items.Ammo.Rocks.Stone;
using Microsoft.Xna.Framework;

namespace UltimateRangerExpansion.Content.Items.Slingshots.Wooden
{
    class WoodSlingshot : ModItem
    {
        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 1;
        }

        public override void SetDefaults()
        {
            // Common Properties
            Item.width = 32;
            Item.height = 32;
            Item.rare = ItemRarityID.White;

            // Use Properties
            Item.useTime = 40;
            Item.useAnimation = 40;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.autoReuse = true;

            // Weapon Properties
            Item.DamageType = DamageClass.Ranged;
            Item.damage = 3;
            Item.knockBack = 3.2f;
            Item.noMelee = true;

            // Slingshot Properties
            Item.shootSpeed = 9f;
            Item.useAmmo = ModContent.ItemType<Rock>();
            Item.shoot = ModContent.ProjectileType<RockProjectile>();

            Item.value = Item.buyPrice(0, 0, 0, 10);

            Item.UseSound = SoundID.Item5;
        }

        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-12, 0);
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.Wood, 5)
                .AddIngredient(ItemID.Silk)
                .AddTile(TileID.WorkBenches)
                .Register();
        }
    }
}
