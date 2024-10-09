﻿using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using Microsoft.Xna.Framework;
using UltimateRangerExpansion.Utils;

namespace UltimateRangerExpansion.Content.Items.Accessories.RedLaserReticle
{
    class RedLaserReticle : ModItem
    {
        readonly float attackSpeedBoost = 10f;
        readonly float damageBoost = 5;
        readonly float critChanceBoost = 5;

        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 26;
            Item.height = 26;

            Item.accessory = true;
            Item.rare = ItemRarityID.Orange;
            Item.value = Item.buyPrice(0, 3, 0, 0);
        }

        public override bool CanAccessoryBeEquippedWith(Item equippedItem, Item incomingItem, Player player)
        {
            return !(incomingItem.type == ModContent.ItemType<GreenLaserReticle.GreenLaserReticle>());
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetAttackSpeed(DamageClass.Ranged) *= 1 + (attackSpeedBoost / 100);
            player.GetDamage(DamageClass.Ranged) *= 1 + (damageBoost / 100);
            player.GetCritChance(DamageClass.Ranged) *= 1 + (critChanceBoost / 100);

            if (!hideVisual)
            {
                Utilities.DrawDustLine(player.Center, Main.MouseWorld, DustID.TintableDustLighted, Color.Red);
            }
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddRecipeGroup(RecipeGroupID.IronBar, 5)
                .AddIngredient(ItemID.Glass)
                .AddIngredient(ItemID.Wire, 5)
                .AddIngredient(ItemID.Ruby)
                .AddTile(TileID.Anvils)
                .Register();
        }
    }
}
