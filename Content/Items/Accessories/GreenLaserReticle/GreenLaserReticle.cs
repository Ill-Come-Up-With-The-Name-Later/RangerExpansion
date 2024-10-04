using Terraria.ID;
using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace UltimateRangerExpansion.Content.Items.Accessories.GreenLaserReticle
{
    class GreenLaserReticle : ModItem
    {
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

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetAttackSpeed(DamageClass.Ranged) *= 1.1f;
            player.GetDamage(DamageClass.Ranged) *= 1.05f;
            player.GetCritChance(DamageClass.Ranged) *= 1.05f;

            if (!hideVisual)
            {
                UltimateRangerExpansion.DrawDustLine(player.Center, Main.MouseWorld, DustID.TintableDust, Color.LightGreen);
            }
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddRecipeGroup(RecipeGroupID.IronBar, 5)
                .AddIngredient(ItemID.Glass)
                .AddIngredient(ItemID.Wire, 5)
                .AddIngredient(ItemID.Emerald)
                .AddTile(TileID.Anvils)
                .Register();
        }
    }
}
