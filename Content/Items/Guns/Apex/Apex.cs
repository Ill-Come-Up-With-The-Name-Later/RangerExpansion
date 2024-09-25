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
        private readonly List<string> modeDesc = ["Burst Fire", "Shotgun", "Single Shot"];

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
            Item.useTime = 2;
            Item.useAnimation = 6;
            Item.reuseDelay = 6;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.autoReuse = true;
            Item.consumeAmmoOnLastShotOnly = true;

            // Weapon Properties
            Item.DamageType = DamageClass.Ranged;
            Item.damage = 110;
            Item.knockBack = 4f;
            Item.noMelee = true;

            // Gun Properties
            Item.shoot = ProjectileID.PurificationPowder;
            Item.shootSpeed = 27f;
            Item.useAmmo = AmmoID.Bullet;

            Item.value = Item.buyPrice(1, 25, 60, 40);
        }

        public override bool AltFunctionUse(Player player)
        {
            mode++;

            if (mode > 3)
            {
                mode = 1;
            }

            switch (mode)
            {
                case 1:
                    Item.useTime = 2;
                    Item.useAnimation = 6;
                    Item.reuseDelay = 6;
                    Item.consumeAmmoOnLastShotOnly = true;
                    break;
                case 2:
                    Item.useTime = 2;
                    Item.useAnimation = 2;
                    Item.reuseDelay = 2;
                    Item.consumeAmmoOnLastShotOnly = false;
                    break;
                case 3:
                    Item.useTime = 2;
                    Item.useAnimation = 2;
                    Item.reuseDelay = 2;
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
                }

                return false;
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
    }
}
