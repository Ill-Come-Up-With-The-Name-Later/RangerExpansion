using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;

namespace UltimateRangerExpansion.Content.Items.Guns.VortexScattergun
{
    class VortexScattergun : ModItem
    {
        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 1;
        }

        public override void SetDefaults()
        {
            // Common Properties
            Item.width = 66;
            Item.height = 28;
            Item.rare = ItemRarityID.Red;

            // Use Properties
            Item.useTime = 20;
            Item.useAnimation = 20;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.autoReuse = true;
            Item.consumeAmmoOnLastShotOnly = true;

            // Weapon Properties
            Item.DamageType = DamageClass.Ranged;
            Item.damage = 100;
            Item.knockBack = 4.7f;
            Item.noMelee = true;
            Item.crit = 9;

            // Gun Properties
            Item.shoot = ProjectileID.PurificationPowder;
            Item.shootSpeed = 22f;
            Item.useAmmo = AmmoID.Bullet;

            Item.UseSound = SoundID.Item11;

            Item.value = Item.buyPrice(0, 36, 60, 40);
        }

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            float numberProjectiles = 9;
            float rotation = MathHelper.ToRadians(8);

            position += Vector2.Normalize(velocity) * 15f;
            velocity *= 0.2f;

            for (int i = 0; i < numberProjectiles; i++) // Fire off random spread
            {
                Vector2 perturbedSpeed = velocity.RotatedByRandom(MathHelper.Lerp(-rotation, rotation, 1));
                Projectile.NewProjectile(source, position, perturbedSpeed, type, damage, knockback, player.whoAmI);
            }

            return false;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.Shotgun)
                .AddIngredient(ItemID.FragmentVortex, 18)
                .AddIngredient(ItemID.IllegalGunParts)
                .AddTile(TileID.LunarCraftingStation)
                .Register();
        }
    }
}
