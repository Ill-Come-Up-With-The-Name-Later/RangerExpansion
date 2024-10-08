﻿using Terraria;
using Terraria.ModLoader;
using UltimateRangerExpansion.Content.Buffs.DronePet;
using UltimateRangerExpansion.Content.Projectiles.Pets.Drone;
using UltimateRangerExpansion.Content.Rarities;
using Terraria.ID;

namespace UltimateRangerExpansion.Content.Items.Pets.Drone
{
    class DronePetSummon : ModItem
    {
        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 1;
        }

        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.ZephyrFish);

            Item.width = 32;
            Item.height = 32;

            Item.DamageType = DamageClass.Ranged;

            Item.rare = ModContent.RarityType<DeveloperRarity>();

            Item.value = Item.buyPrice(1, 0, 0, 0);

            Item.buffType = ModContent.BuffType<DronePetBuff>();
            Item.shoot = ModContent.ProjectileType<DronePetProjectile>();
        }

        public override bool? UseItem(Player player)
        {
            if (player.whoAmI == Main.myPlayer)
            {
                player.AddBuff(Item.buffType, 3600);
            }

            return true;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.LunarBar, 10)
                .AddIngredient(ItemID.SoulofFlight, 15)
                .AddIngredient(ItemID.FragmentVortex, 5)
                .AddIngredient(ItemID.RocketLauncher)
                .AddIngredient(ItemID.ClockworkAssaultRifle)
                .AddIngredient(ItemID.SniperRifle)
                .AddTile(TileID.MythrilAnvil)
                .Register();
        }
    }
}
