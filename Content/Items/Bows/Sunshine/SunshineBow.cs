using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using Terraria.DataStructures;
using Microsoft.Xna.Framework;
using System;

namespace UltimateRangerExpansion.Content.Items.Bows.Sunshine
{
    class SunshineBow : ModItem
    {
        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 1;
        }

        public override void SetDefaults()
        {
            // Common Properties
            Item.width = 22;
            Item.height = 42;
            Item.rare = ItemRarityID.Red;

            // Use Properties
            Item.useTime = 12;
            Item.useAnimation = 12;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.autoReuse = true;

            // Weapon Properties
            Item.DamageType = DamageClass.Ranged;
            Item.damage = 64;
            Item.knockBack = 5f;
            Item.noMelee = true;

            // Bow Properties
            Item.shootSpeed = 20f;
            Item.useAmmo = AmmoID.Arrow;
            Item.shoot = ProjectileID.WoodenArrowFriendly;

            Item.crit = 9;

            Item.value = Item.buyPrice(0, 40, 20, 50);

            Item.UseSound = SoundID.Item5;
        }

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            Vector2 playerPos = player.Center;

            for(int i = 0; i < 8; i++) // Fire a projectile every 45 degrees from 0 to 360
            {
                float angle = i * 45;

                float angleCos = (float)Math.Cos(MathHelper.ToRadians(angle));
                float angleSin = (float)Math.Sin(MathHelper.ToRadians(angle));

                float projX = playerPos.X + (45 * angleCos);
                float projY = playerPos.Y - (45 * angleSin);

                Vector2 projPos = new(projX, projY);
                
                /*
                if(projY > playerPos.Y) // Make projectiles converge
                    velocity.Y = -1;
                else if(projY < playerPos.Y)
                    velocity.Y = 1;
                */

                Projectile projectile = Main.projectile[Projectile.NewProjectile(source, projPos, velocity, type, damage, knockback)];
                projectile.tileCollide = false;

                for (int k = 0; k < 12; k++) // Draw dust every 30 degrees
                {
                    float dustAngle = k * 30;

                    float dustCos = (float)Math.Cos(MathHelper.ToRadians(dustAngle));
                    float dustSin = (float)Math.Sin(MathHelper.ToRadians(dustAngle));

                    float dustX = projPos.X + (2 * dustCos);
                    float dustY = projPos.Y - (2 * dustSin);

                    Vector2 dustLoc = new(dustX, dustY);
                    Dust.NewDust(dustLoc, 1, 1, DustID.SolarFlare, -projectile.velocity.X / 3, -projectile.velocity.Y / 3);
                    Lighting.AddLight(dustLoc, TorchID.Orange);
                }
            }

            return false;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
               .AddIngredient(ItemID.SoulofFlight, 5)
               .AddIngredient(ItemID.FragmentSolar, 18)
               .AddIngredient(UltimateRangerExpansion.Calamity.Find<ModItem>("EssenceofSunlight").Type)
               .AddTile(TileID.LunarCraftingStation)
               .Register();
        }
    }
}
