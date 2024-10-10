using Terraria.ID;
using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using UltimateRangerExpansion.Utils;

namespace UltimateRangerExpansion.Content.Items.Guns.AWP
{
    class Awp : ModItem
    {
        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 1;
        }

        public override void SetDefaults()
        {
            // Common Properties
            Item.width = 62;
            Item.height = 24;
            Item.rare = ItemRarityID.Red;

            // Use Properties
            Item.useTime = 45;
            Item.useAnimation = 45;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.autoReuse = true;
            Item.UseSound = ModSounds.AWP;

            // Weapon Properties
            Item.DamageType = DamageClass.Ranged;
            Item.damage = 350;
            Item.knockBack = 7f;
            Item.noMelee = true;
            Item.crit = 10;

            // Gun Properties
            Item.shoot = ProjectileID.PurificationPowder;
            Item.shootSpeed = 30f;
            Item.useAmmo = AmmoID.Bullet;

            Item.value = Item.buyPrice(0, 25, 10, 50);
        }

        public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
        {
            if (type == ProjectileID.Bullet)
            {
                type = ProjectileID.BulletHighVelocity;
            }
        }

        public override void UpdateInventory(Player player)
        {
            player.scope = true;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.SniperRifle)
                .AddIngredient(ItemID.LunarBar, 5)
                .AddIngredient(ItemID.FragmentVortex, 10)
                .AddTile(TileID.LunarCraftingStation)
                .Register();
        }
    }
}
