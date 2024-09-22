using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using Microsoft.Xna.Framework;
using System;
using Terraria.DataStructures;
using UltimateRangerExpansion.Content.Projectiles.ZenithBow.CopperBow;
using UltimateRangerExpansion.Content.Projectiles.ZenithBow.BeesKnees;
using UltimateRangerExpansion.Content.Projectiles.ZenithBow.MoltenFury;
using UltimateRangerExpansion.Content.Projectiles.ZenithBow.DemonBow;
using UltimateRangerExpansion.Content.Projectiles.ZenithBow.TendonBow;
using UltimateRangerExpansion.Content.Projectiles.ZenithBow.ShadowflameBow;
using UltimateRangerExpansion.Content.Projectiles.ZenithBow.DaedalusBow;
using UltimateRangerExpansion.Content.Projectiles.ZenithBow.Eventide;
using UltimateRangerExpansion.Content.Projectiles.ZenithBow.AerialBane;
using UltimateRangerExpansion.Content.Projectiles.ZenithBow.Tsunami;
using UltimateRangerExpansion.Content.Projectiles.ZenithBow.Phantasm;
using UltimateRangerExpansion.Content.Projectiles.ZenithBow.Pinnacle;

namespace UltimateRangerExpansion.Content.Items.Bows.Pinnacle
{
    class PinnacleBow : ModItem
    {
        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 1;
        }

        public override void SetDefaults()
        {
            // Common Properties
            Item.width = 28;
            Item.height = 46;
            Item.rare = ItemRarityID.Red;

            // Use Properties
            Item.useTime = 19;
            Item.useAnimation = 19;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.autoReuse = true;

            // Weapon Properties
            Item.DamageType = DamageClass.Ranged;
            Item.damage = 180;
            Item.knockBack = 5f;
            Item.noMelee = true;

            // Bow Properties
            Item.shootSpeed = 22;
            Item.useAmmo = AmmoID.Arrow;
            Item.shoot = ProjectileID.WoodenArrowFriendly;

            Item.crit = 10;

            Item.value = Item.buyPrice(1, 32, 25, 24);

            Item.UseSound = SoundID.Item5;
        }

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            Vector2 playerPos = player.Center;

            int[] BowProjectiles = [
                ModContent.ProjectileType<CopperBowProjectile>(),
                ModContent.ProjectileType<BeesKneesProjectile>(),
                ModContent.ProjectileType<MoltenFuryProjectile>(),
                ModContent.ProjectileType<DemonBowProjectile>(),
                ModContent.ProjectileType<TendonBowProjectile>(),
                ModContent.ProjectileType<ShadowflameBowProjectile>(),
                ModContent.ProjectileType<DaedalusBowProjectile>(),
                ModContent.ProjectileType<EventideProjectile>(),
                ModContent.ProjectileType<AerialBaneProjectile>(),
                ModContent.ProjectileType<TsunamiProjectile>(),
                ModContent.ProjectileType<PhantasmProjectile>(),
                ModContent.ProjectileType<PinnacleProjectile>(),
            ];

            for(int i = 0; i < 6; i++)
            {
                Vector2 shootPos = player.Center + new Vector2(new Random().Next(-650, 650), -new Random().Next(0, 350));
                int bowPojectile = Main.rand.Next(BowProjectiles);

                Projectile bow = Main.projectile[Projectile.NewProjectile(source, shootPos, velocity, 
                    bowPojectile, damage, knockback, Main.myPlayer)];

                Vector2 mousePos = Main.MouseWorld;
                Vector2 projVelocity = mousePos - bow.Center;
                projVelocity.Normalize();
                projVelocity *= Item.shootSpeed;

                Projectile portal = Main.projectile[Projectile.NewProjectile(source, bow.Center, new Vector2(0, 0), 
                    ProjectileID.MoonlordTurret, 0, 0, Main.myPlayer)];

                portal.alpha = 66;
                portal.aiStyle = 0;
                portal.timeLeft = Item.useTime * 2;
                portal.scale = 1.75f;

                Projectile.NewProjectile(source, bow.Center, projVelocity, type, damage, knockback, Main.myPlayer);
            }

            for (int i = -1; i <= 1; i++)
            {
                Projectile.NewProjectile(source, position - new Vector2(0, i * 9), velocity, type, damage, knockback, Main.myPlayer);
            }

            // Rain arrows from the sky
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

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.CopperBow)
                .AddIngredient(ItemID.BeesKnees)
                .AddIngredient(ItemID.MoltenFury)
                .AddIngredient(ItemID.TendonBow)
                .AddIngredient(ItemID.ShadowFlameBow)
                .AddIngredient(ItemID.DaedalusStormbow)
                .AddIngredient(ItemID.FairyQueenRangedItem)
                .AddIngredient(ItemID.DD2BetsyBow)
                .AddIngredient(ItemID.Tsunami)
                .AddIngredient(ItemID.Phantasm)
                .AddTile(TileID.MythrilAnvil)
                .Register();

            CreateRecipe()
                .AddIngredient(ItemID.CopperBow)
                .AddIngredient(ItemID.BeesKnees)
                .AddIngredient(ItemID.MoltenFury)
                .AddIngredient(ItemID.DemonBow)
                .AddIngredient(ItemID.ShadowFlameBow)
                .AddIngredient(ItemID.DaedalusStormbow)
                .AddIngredient(ItemID.FairyQueenRangedItem)
                .AddIngredient(ItemID.DD2BetsyBow)
                .AddIngredient(ItemID.Tsunami)
                .AddIngredient(ItemID.Phantasm)
                .AddTile(TileID.MythrilAnvil)
                .Register();
        }
    }
}
