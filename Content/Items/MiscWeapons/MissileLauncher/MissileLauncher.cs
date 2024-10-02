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
        readonly float shootSpeed = 10;
        readonly float gravity = 10;

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
            Item.damage = 25000;
            Item.knockBack = 8f;
            Item.noMelee = true;
            Item.crit = 12;

            // Gun Properties
            Item.shoot = ModContent.ProjectileType<BallisticMissile>();
            Item.shootSpeed = shootSpeed;
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
            float x = target.X - position.X;
            float y = target.Y - position.Y;

            float discriminant = (float) 
                (Math.Pow(shootSpeed, 4) 
                - gravity * ((gravity * x * x)
                + (2 * y * shootSpeed * shootSpeed)));

            Main.NewText($"Discriminant: {discriminant}");

            if (discriminant < 0)
                return;

            float root = (float)Math.Sqrt(discriminant);
            float angle = (float)Math.Atan((shootSpeed * shootSpeed - root) / (gravity * x));

            velocity = new(1, 0);

            if (target.X < player.position.X)
            {
                angle = (float)(Math.PI - angle);
                velocity *= -1;
            }
            
            velocity.RotatedBy(angle);
            velocity.Normalize();
            velocity *= shootSpeed;
        }
    }
}
