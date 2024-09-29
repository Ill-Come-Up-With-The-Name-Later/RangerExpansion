using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using Terraria.DataStructures;
using Microsoft.Xna.Framework;
using Terraria.Audio;

namespace UltimateRangerExpansion.Content.Items.Guns.Strikemaster
{
    class Strikemaster : ModItem
    {
        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 1;
        }

        public override void SetDefaults()
        {
            // Common Properties
            Item.width = 40;
            Item.height = 16;
            Item.rare = ItemRarityID.Red;

            // Use Properties
            Item.useTime = 10;
            Item.useAnimation = 20;
            Item.reuseDelay = 20;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.autoReuse = true;
            Item.consumeAmmoOnLastShotOnly = true;

            // Weapon Properties
            Item.DamageType = DamageClass.Ranged;
            Item.damage = 70;
            Item.knockBack = 4.5f;
            Item.noMelee = true;
            Item.crit = 9;

            // Gun Properties
            Item.shoot = ProjectileID.PurificationPowder;
            Item.shootSpeed = 24f;
            Item.useAmmo = AmmoID.Bullet;

            Item.value = Item.buyPrice(0, 32, 20, 50);
        }

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            float numberProjectiles = 5;
            float rotation = MathHelper.ToRadians(14);

            position += Vector2.Normalize(velocity) * 15f;
            velocity *= 0.2f;

            for (int i = 0; i < numberProjectiles; i++) // Fire off random spread
            {
                Vector2 perturbedSpeed = velocity.RotatedByRandom(MathHelper.Lerp(-rotation, rotation, 1));
                Projectile.NewProjectile(source, position, perturbedSpeed, type, damage, knockback, player.whoAmI);
            }

            SoundEngine.PlaySound(SoundID.Item11, position); // Play sound every shot
            return false;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.TacticalShotgun)
                .AddIngredient(ItemID.LunarBar, 6)
                .AddTile(TileID.LunarCraftingStation)
                .Register();
        }
    }
}
