using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using UltimateRangerExpansion.Content.Items.Slingshots.Wooden;
using UltimateRangerExpansion.Content.Projectiles.Rocks.Molten;

namespace UltimateRangerExpansion.Content.Items.Slingshots.Molten
{
    class MoltenSlingshot : ModItem
    {
        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 1;
        }

        public override void SetDefaults()
        {
            Item.CloneDefaults(ModContent.ItemType<WoodSlingshot>());

            Item.damage = 20;

            Item.useTime -= 18;
            Item.useAnimation -= 18;
            Item.shootSpeed += 12;

            Item.crit += 12;

            Item.rare = ItemRarityID.Orange;

            Item.value += 4000;
        }

        public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
        {
            type = ModContent.ProjectileType<MoltenRockProjectile>();
        }

        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-12, 0);
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.HellstoneBar, 5)
                .AddIngredient(ItemID.Silk)
                .AddTile(TileID.Anvils)
                .Register();
        }
    }
}
