using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace UltimateRangerExpansion.Content.Items.Guns.Apex
{
    class Apex : ModItem
    {
        private int mode = 1;
        private readonly List<string> modeDesc = [];

        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 1;

            modeDesc.Add("Burst Fire");
            modeDesc.Add("Shotgun");
            modeDesc.Add("Single Shot");
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

            Item.value = Item.buyPrice(0, 15, 20, 50);
        }

        public override bool AltFunctionUse(Player player)
        {
            if(mode++ > 3)
            {
                mode = 0;
                return false;
            }

            mode++;

            return base.AltFunctionUse(player);
        }

        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            tooltips.Add(new TooltipLine(Mod, "mode", $"Mode: {mode} ({modeDesc[mode - 1]})") { OverrideColor = Color.Green });
        }
    }
}
