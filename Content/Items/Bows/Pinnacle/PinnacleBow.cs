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
using UltimateRangerExpansion.Content.Projectiles.ZenithBow.Marrow;
using System.Collections.Generic;

namespace UltimateRangerExpansion.Content.Items.Bows.Pinnacle
{
    class PinnacleBow : ModItem
    {
        readonly int seekDistance = 1100;

        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 1;
        }

        public override void SetDefaults()
        {
            // Common Properties
            Item.width = 30;
            Item.height = 60;
            Item.rare = ItemRarityID.Red;

            // Use Properties
            Item.useTime = 20;
            Item.useAnimation = 20;
            Item.reuseDelay = 20;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.autoReuse = true;

            // Weapon Properties
            Item.DamageType = DamageClass.Ranged;
            Item.damage = 200;
            Item.knockBack = 5.5f;
            Item.noMelee = true;

            // Bow Properties
            Item.shootSpeed = 28;
            Item.useAmmo = AmmoID.Arrow;
            Item.shoot = ProjectileID.WoodenArrowFriendly;

            Item.crit = 12;

            Item.value = Item.buyPrice(1, 40, 65, 60);

            Item.UseSound = SoundID.Item5;
        }

        public override bool CanConsumeAmmo(Item ammo, Player player)
        {
            return new Random().Next(0, 100) >= 80;
        }

        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            tooltips.Add(new TooltipLine(Mod, "ammo", "80% chance to save ammo"));
        }

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            Vector2 playerPos = player.Center;

            List<int> BowProjectiles = [
                ModContent.ProjectileType<CopperBowProjectile>(),
                ModContent.ProjectileType<BeesKneesProjectile>(),
                ModContent.ProjectileType<DemonBowProjectile>(),
                ModContent.ProjectileType<TendonBowProjectile>(),
                ModContent.ProjectileType<MoltenFuryProjectile>(),
                ModContent.ProjectileType<MarrowProjectile>(),
                ModContent.ProjectileType<ShadowflameBowProjectile>(),
                ModContent.ProjectileType<DaedalusBowProjectile>(),
                ModContent.ProjectileType<EventideProjectile>(),
                ModContent.ProjectileType<AerialBaneProjectile>(),
                ModContent.ProjectileType<TsunamiProjectile>(),
                ModContent.ProjectileType<PhantasmProjectile>(),
                ModContent.ProjectileType<PinnacleProjectile>(),
            ];

            for (int i = 0; i < 6; i++)
            {
                Vector2 shootPos = playerPos + new Vector2(new Random().Next(-650, 650), -new Random().Next(0, 350));
                int bowProjectile = BowProjectiles[new Random().Next(0, BowProjectiles.Count)];

                Projectile bow = Main.projectile[Projectile.NewProjectile(source, shootPos, velocity,
                    bowProjectile, damage, knockback, Main.myPlayer)];

                Vector2 aimPos = Utils.ClosestNPC(Main.MouseWorld, seekDistance) == null ?
                    Main.MouseWorld : Utils.ClosestNPC(Main.MouseWorld, seekDistance).position;

                Vector2 projVelocity = aimPos - bow.Center;
                projVelocity.Normalize();
                projVelocity *= Item.shootSpeed;

                bow.rotation = projVelocity.ToRotation();

                Projectile portal = Main.projectile[Projectile.NewProjectile(source, bow.Center, new Vector2(0, 0),
                    ProjectileID.MoonlordTurret, 0, 0, Main.myPlayer)];

                portal.alpha = 66;
                portal.timeLeft = Item.useTime * 2;
                portal.scale = 1.75f;
                portal.aiStyle = ProjAIStyleID.FallingStar;

                if (type == ProjectileID.WoodenArrowFriendly)
                {
                    int ProjectileType = BowProjectiles.IndexOf(bowProjectile) switch
                    {
                        1 => ProjectileID.BeeArrow,
                        2 => ProjectileID.CursedArrow,
                        3 => ProjectileID.IchorArrow,
                        4 => ProjectileID.FireArrow,
                        5 => ProjectileID.BoneArrow,
                        6 => ProjectileID.ShadowFlameArrow,
                        7 => ProjectileID.HolyArrow,
                        8 => ProjectileID.FairyQueenRangedItemShot,
                        9 => ProjectileID.DD2BetsyArrow,
                        11 => ProjectileID.PhantasmArrow,
                        _ => type
                    };

                    Projectile.NewProjectile(source, bow.Center, projVelocity, ProjectileType, damage, knockback, Main.myPlayer);
                }
                else
                {
                    Projectile.NewProjectile(source, bow.Center, projVelocity, type, damage, knockback, Main.myPlayer);
                }
            }

            for (int i = -2; i <= 2; i++)
            {
                Projectile.NewProjectile(source, position - new Vector2(0, i * 9), velocity, type, damage, knockback, Main.myPlayer);
            }

            // Rain arrows from the sky
            Vector2 center;
            Vector2 val = Utils.ClosestNPC(Main.MouseWorld, seekDistance) == null ?
                    Main.MouseWorld : Utils.ClosestNPC(Main.MouseWorld, seekDistance).position;

            NPC closest = Utils.ClosestNPC(Main.MouseWorld, seekDistance);

            float num2 = val.Y;
            if (num2 > player.Center.Y - 200f)
            {
                num2 = player.Center.Y - 200f;
            }

            for (int j = 0; j < 6; j++)
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

                if (closest != null)
                    velocity.X += closest.velocity.X;

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
                .AddIngredient(ItemID.Marrow)
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
                .AddIngredient(ItemID.Marrow)
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
