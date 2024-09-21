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
            Item.width = 32;
            Item.height = 54;
            Item.rare = ItemRarityID.Red;

            // Use Properties
            Item.useTime = 12;
            Item.useAnimation = 12;
            Item.reuseDelay = 12;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.autoReuse = true;

            // Weapon Properties
            Item.DamageType = DamageClass.Ranged;
            Item.damage = 100;
            Item.knockBack = 5.5f;
            Item.noMelee = true;

            // Bow Properties
            Item.shootSpeed = 28f;
            Item.useAmmo = AmmoID.Arrow;
            Item.shoot = ProjectileID.WoodenArrowFriendly;

            Item.crit = 17;

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
            ];

            for (int i = 0; i < 6; i++) // Fire a projectile every 60 degrees from 0 to 360
            {
                float angle = i * 60;

                float angleCos = (float)Math.Cos(MathHelper.ToRadians(angle));
                float angleSin = (float)Math.Sin(MathHelper.ToRadians(angle));

                float projX = playerPos.X + (65 * angleCos);
                float projY = playerPos.Y - (65 * angleSin);

                Vector2 projPos = new(projX, projY);

                Projectile projectile = Main.projectile[Projectile.NewProjectile(source, projPos, new Vector2(0, 0), 
                    Main.rand.Next(BowProjectiles), 0, 0)];

                for (int k = 0; k < 12; k++) // Draw dust every 30 degrees
                {
                    float dustAngle = k * 30;

                    float dustCos = (float)Math.Cos(MathHelper.ToRadians(dustAngle));
                    float dustSin = (float)Math.Sin(MathHelper.ToRadians(dustAngle));

                    float dustX = projPos.X + (2 * dustCos);
                    float dustY = projPos.Y - (2 * dustSin);

                    Vector2 dustLoc = new(dustX, dustY);
                    Dust.NewDust(dustLoc, 1, 1, DustID.TintableDustLighted, -projectile.velocity.X / 3, -projectile.velocity.Y / 3, 
                        newColor: new Color(new Random().Next(0, 255), new Random().Next(0, 255), new Random().Next(0, 255)));
                }
            }

            for(int i = -1; i < 2; i++) // Also shoot three arrows
            {
                Projectile.NewProjectile(source, position - new Vector2(0, i * 7), velocity, type, damage, knockback);
            }

            // Rain arrows from the sky
            Vector2 center;
            Vector2 val = Main.screenPosition + new Vector2(Main.mouseX, Main.mouseY);

            float num2 = val.Y;
            if (num2 > player.Center.Y - 200f)
            {
                num2 = player.Center.Y - 200f;
            }

            for (int j = 0; j < 8; j++)
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
