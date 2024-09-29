using Microsoft.Xna.Framework;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria;
using Terraria.ModLoader;

namespace UltimateRangerExpansion.Content.Items.Guns.StarShotgun
{
    class StarShotgun : ModItem
    {
        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 1;
        }

        public override void SetDefaults()
        {
            // Common Properties
            Item.width = 54;
            Item.height = 28;
            Item.rare = ItemRarityID.LightRed;

            // Use Properties
            Item.useTime = 40;
            Item.useAnimation = 40;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.autoReuse = true;
            Item.consumeAmmoOnLastShotOnly = true;

            // Weapon Properties
            Item.DamageType = DamageClass.Ranged;
            Item.damage = 40;
            Item.knockBack = 3f;
            Item.noMelee = true;
            Item.crit = 2;

            // Gun Properties
            Item.shoot = ProjectileID.StarCannonStar;
            Item.shootSpeed = 25f;
            Item.useAmmo = AmmoID.FallenStar;

            Item.UseSound = SoundID.Item9;

            Item.value = Item.buyPrice(0, 22, 20, 50);
        }

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            float numberProjectiles = 5;
            float rotation = MathHelper.ToRadians(14);

            position += Vector2.Normalize(velocity) * 15f;
            velocity *= 0.66f;

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
                .AddIngredient(ItemID.StarCannon)
                .AddIngredient(ItemID.Shotgun)
                .AddIngredient(ItemID.IllegalGunParts)
                .AddTile(TileID.Anvils)
                .Register();
        }
    }
}
