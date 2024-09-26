using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using System;
using Terraria.Audio;
using Terraria.DataStructures;

namespace UltimateRangerExpansion.Content.Items.Guns.Apex
{
    class Apex : ModItem
    {
        private int mode = 1;
        private readonly List<string> modeDesc = ["Burst Fire", "Shotgun", "Single Shot", "Sniper"];

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
            Item.useTime = 3;
            Item.useAnimation = 9;
            Item.reuseDelay = 9;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.autoReuse = true;
            Item.consumeAmmoOnLastShotOnly = true;

            // Weapon Properties
            Item.DamageType = DamageClass.Ranged;
            Item.damage = 300;
            Item.knockBack = 4f;
            Item.noMelee = true;
            Item.crit = 12;

            // Gun Properties
            Item.shoot = ProjectileID.PurificationPowder;
            Item.shootSpeed = 27f;
            Item.useAmmo = AmmoID.Bullet;

            Item.value = Item.buyPrice(1, 25, 60, 40);
        }

        public override bool CanReforge()
        {
            return false;
        }

        public override bool AltFunctionUse(Player player)
        {
            mode++;

            if (mode > modeDesc.Count)
            {
                mode = 1;
            }

            switch (mode)
            {
                case 1:
                    Item.damage = 300;
                    Item.useTime = 3;
                    Item.useAnimation = 9;
                    Item.reuseDelay = 9;
                    Item.consumeAmmoOnLastShotOnly = true;
                    break;
                case 2:
                    Item.damage = 120;
                    Item.useTime = 4;
                    Item.useAnimation = 4;
                    Item.reuseDelay = 4;
                    Item.consumeAmmoOnLastShotOnly = false;
                    break;
                case 3:
                    Item.damage = 370;
                    Item.useTime = 2;
                    Item.useAnimation = 2;
                    Item.reuseDelay = 2;
                    Item.consumeAmmoOnLastShotOnly = false;
                    break;
                case 4:
                    Item.damage = 2200;
                    Item.useTime = 40;
                    Item.useAnimation = 40;
                    Item.reuseDelay = 40;
                    Item.consumeAmmoOnLastShotOnly = false;
                    break;
            }

            return false;
        }

        public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
        {
            if(mode == 1)
            {
                // Rotate projectile randomy
                float rotation = MathHelper.ToRadians(5);
                velocity = velocity.RotatedByRandom(MathHelper.Lerp(-rotation, rotation, 1));
            }

            if(mode == 4)
            {
                type = ProjectileID.BulletHighVelocity;
            }

            SoundEngine.PlaySound(SoundID.Item11, position); // Play sound every shot
        }

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            if(mode == 2)
            {
                float numberProjectiles = 5 + Main.rand.Next(3);
                float rotation = MathHelper.ToRadians(20);

                position += Vector2.Normalize(velocity) * 20f;
                velocity *= 0.33f;

                for (int i = 0; i < numberProjectiles; i++)
                {
                    Vector2 perturbedSpeed = velocity.RotatedByRandom(MathHelper.Lerp(-rotation, rotation, 1));

                    Projectile.NewProjectile(source, position, perturbedSpeed, type, damage, knockback, player.whoAmI);
                    Projectile.NewProjectile(source, position, velocity.RotatedByRandom(MathHelper.Lerp(-rotation, rotation, 1)),
                        ProjectileID.Xenopopper, damage, knockback);
                }

                Projectile.NewProjectile(source, position, velocity, ProjectileID.BlackBolt, damage, knockback);
                return false;
            }

            if(mode == 3)
            {
                Projectile.NewProjectile(source, position, velocity, ProjectileID.VortexBeater, damage, knockback);
            }

            return true;
        }

        public override bool CanConsumeAmmo(Item ammo, Player player)
        {
            return new Random().Next(0, 100) >= 80;
        }

        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            tooltips.Add(new TooltipLine(Mod, "mode", $"Mode: {mode} ({modeDesc[mode - 1]})") { OverrideColor = Color.Green });
            tooltips.Add(new TooltipLine(Mod, "ammo", "80% chance to save ammo"));
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.Boomstick)
                .AddIngredient(ItemID.Musket)
                .AddIngredient(ItemID.PhoenixBlaster)
                .AddIngredient(ItemID.OnyxBlaster)
                .AddIngredient(ItemID.Uzi)
                .AddIngredient(ItemID.Megashark)
                .AddIngredient(ItemID.VenusMagnum)
                .AddIngredient(ItemID.TacticalShotgun)
                .AddIngredient(ItemID.SniperRifle)
                .AddIngredient(ItemID.ChainGun)
                .AddIngredient(ItemID.Xenopopper)
                .AddIngredient(ItemID.VortexBeater)
                .AddIngredient(ItemID.SDMG)
                .AddTile(TileID.MythrilAnvil)
                .Register();

            CreateRecipe()
                .AddIngredient(ItemID.Boomstick)
                .AddIngredient(ItemID.TheUndertaker)
                .AddIngredient(ItemID.PhoenixBlaster)
                .AddIngredient(ItemID.OnyxBlaster)
                .AddIngredient(ItemID.Uzi)
                .AddIngredient(ItemID.Megashark)
                .AddIngredient(ItemID.VenusMagnum)
                .AddIngredient(ItemID.TacticalShotgun)
                .AddIngredient(ItemID.SniperRifle)
                .AddIngredient(ItemID.ChainGun)
                .AddIngredient(ItemID.Xenopopper)
                .AddIngredient(ItemID.VortexBeater)
                .AddIngredient(ItemID.SDMG)
                .AddTile(TileID.MythrilAnvil)
                .Register();
        }
    }
}
