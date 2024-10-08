using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using UltimateRangerExpansion.Content.Projectiles.AirStrikePlane;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;

namespace UltimateRangerExpansion.Content.Items.MiscWeapons.AirStrikeCaller
{
    class StrikeCaller : ModItem
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
            Item.rare = ItemRarityID.Cyan;

            // Use Properties
            Item.useTime = 180;
            Item.useAnimation = 180;
            Item.useStyle = ItemUseStyleID.HoldUp;
            Item.autoReuse = true;

            // Weapon Properties
            Item.DamageType = DamageClass.Ranged;
            Item.damage = 500;
            Item.noMelee = true;
            Item.crit = 7;

            // Gun Properties
            Item.shoot = ModContent.ProjectileType<StrikePlane>();
            Item.shootSpeed = 15;

            Item.value = Item.buyPrice(0, 25, 0, 0);
        }

        public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
        {
            position = Main.screenPosition;
            position.X -= 100;
            position.Y -= 50;

            velocity = new Vector2(Item.shootSpeed, 0);
        }

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            return true;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.PDA)
                .AddIngredient(ItemID.FlareGun)
                .AddIngredient(ItemID.SoulofFlight, 10)
                .AddTile(TileID.MythrilAnvil)
                .Register();
        }
    }
}
