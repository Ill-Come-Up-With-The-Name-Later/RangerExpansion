using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;

namespace UltimateRangerExpansion.Content.Items.Bows.Storm
{
    class TheStorm : ModItem
    {
        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 1;
        }

        public override void SetDefaults()
        {
            // Common Properties
            Item.width = 30;
            Item.height = 62;
            Item.rare = ItemRarityID.Yellow;

            // Use Properties
            Item.useTime = 16;
            Item.useAnimation = 16;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.autoReuse = true;

            // Weapon Properties
            Item.DamageType = DamageClass.Ranged;
            Item.damage = 60;
            Item.knockBack = 5f;
            Item.noMelee = true;

            // Bow Properties
            Item.shootSpeed = 13f;
            Item.useAmmo = AmmoID.Arrow;
            Item.shoot = ProjectileID.WoodenArrowFriendly;

            Item.value = Item.buyPrice(0, 25, 20, 50);

            Item.UseSound = SoundID.Item5;
        }

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            Vector2 center;
            Vector2 val = Main.screenPosition + new Vector2(Main.mouseX, Main.mouseY);

            float num2 = val.Y;
            if (num2 > player.Center.Y - 200f)
            {
                num2 = player.Center.Y - 200f;
            }

            for (int j = 0; j < 5; j++)
            {
                position = player.Center + new Vector2((0f - Main.rand.Next(0, 250)) * player.direction, -600f);
                position.Y -= 100 * j;
                Vector2 val2 = val - position;

                if (val2.Y < 0f)
                {
                    val2.Y *= -1f;
                }
                if (val2.Y < 20f)
                {
                    val2.Y = 20f;
                }

                val2.Normalize();
                Vector2 val3 = val2;
                center = new Vector2(velocity.X, velocity.Y);
                val2 = val3 * center.Length();
                velocity.X = val2.X;
                velocity.Y = val2.Y + Main.rand.Next(-40, 41) * 0.01f;
                Projectile.NewProjectile(source, position, velocity, type, damage, knockback, player.whoAmI, 0f, num2);
            }

            return false;
        }

        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-3, 0);
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.DaedalusStormbow)
                .AddIngredient(ItemID.Tsunami)
                .AddTile(TileID.MythrilAnvil)
                .Register();
        }
    }
}
