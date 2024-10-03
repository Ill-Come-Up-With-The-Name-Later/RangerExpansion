using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using UltimateRangerExpansion.Content.Projectiles.Rockets.BallisticMissile;
using System;

namespace UltimateRangerExpansion.Content.Items.MiscWeapons.MissileLauncher
{
    class MissileLauncher : ModItem
    {
        Vector2 target = Vector2.Zero;
        public static readonly float gravity = 50;
        private static readonly float vel = (float)(gravity * 0.9);

        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 1;
        }

        public override void SetDefaults()
        {
            // Common Properties
            Item.width = 52;
            Item.height = 22;
            Item.rare = ItemRarityID.Red;

            // Use Properties
            Item.useTime = 45;
            Item.useAnimation = 45;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.autoReuse = true;
            Item.UseSound = SoundID.Item40;

            // Weapon Properties
            Item.DamageType = DamageClass.Ranged;
            Item.damage = 2500;
            Item.knockBack = 8f;
            Item.noMelee = true;
            Item.crit = 12;

            // Gun Properties
            Item.shoot = ModContent.ProjectileType<BallisticMissile>();
            Item.shootSpeed = vel;
            Item.useAmmo = AmmoID.Rocket;

            Item.value = Item.buyPrice(0, 55, 10, 50);
        }

        public override bool AltFunctionUse(Player player)
        {
            target = Main.MouseWorld;
            Main.NewText($"Set missile target to ({target.X}, {target.Y})");

            return false;
        }

        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            tooltips.Add(new TooltipLine(Mod, "Target", $"Target: (X: {target.X} | Y: {target.Y})") { OverrideColor = Color.Yellow });
        }

        public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
        {
            float angle = UltimateRangerExpansion.LaunchAngle(position, target, vel * 60, gravity);

            velocity = new(1, 0);
            velocity = velocity.RotatedBy(angle);
            velocity *= vel;
        }
    }
}
