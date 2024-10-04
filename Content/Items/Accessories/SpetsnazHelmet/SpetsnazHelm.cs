using Terraria.ID;
using Terraria.ModLoader;
using Terraria;

namespace UltimateRangerExpansion.Content.Items.Accessories.SpetsnazHelmet
{
    class SpetsnazHelm : ModItem
    {
        readonly float bulletDamage = 5;

        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 22;
            Item.height = 24;

            Item.accessory = true;
            Item.rare = ItemRarityID.Yellow;
            Item.value = Item.buyPrice(0, 10, 0, 0);
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.aggro -= 500;
            player.nightVision = true;
            player.bulletDamage *= 1 + (bulletDamage / 100);
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.NightVisionHelmet)
                .AddIngredient(ItemID.SWATHelmet)
                .AddIngredient(ItemID.SoulofNight, 10)
                .AddTile(TileID.MythrilAnvil)
                .Register();
        }
    }
}
