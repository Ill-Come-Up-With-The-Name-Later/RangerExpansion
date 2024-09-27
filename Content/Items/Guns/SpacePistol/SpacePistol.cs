using Terraria.ID;
using Terraria.ModLoader;

namespace UltimateRangerExpansion.Content.Items.Guns.SpacePistol
{
    class SpacePistol : ModItem
    {
        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 1;
        }

        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.SpaceGun);

            Item.width = 36;
            Item.height = 24;

            Item.crit = 2;

            Item.DamageType = DamageClass.Ranged;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.SpaceGun)
                .AddIngredient(ItemID.IllegalGunParts)
                .AddTile(TileID.Anvils)
                .Register();
        }
    }
}
