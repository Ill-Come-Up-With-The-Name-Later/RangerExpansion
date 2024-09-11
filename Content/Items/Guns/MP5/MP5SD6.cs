﻿using Microsoft.Xna.Framework;
using RangerExpansion.Content.Rarities;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace RangerExpansion.Content.Items.Guns.MP5
{
    class MP5SD6 : ModItem
    {
        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 1;
        }

        public override void SetDefaults()
        {
            // Common Properties
            Item.width = 60;
            Item.height = 26;
            Item.rare = ModContent.RarityType<DeveloperRarity>();

            // Use Properties
            Item.useTime = 6;
            Item.useAnimation = 18;
            Item.reuseDelay = 18;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.autoReuse = true;
            Item.consumeAmmoOnLastShotOnly = true;

            // Weapon Properties
            Item.DamageType = DamageClass.Ranged;
            Item.damage = 45;
            Item.knockBack = 3f; 
            Item.noMelee = true; 

            // Gun Properties
            Item.shoot = ProjectileID.PurificationPowder;
            Item.shootSpeed = 12f;
            Item.useAmmo = AmmoID.Bullet;

            Item.value = Item.buyPrice(0, 15, 20, 50);
        }

        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-24f, 0);
        }


        public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
        {
            // Rotate projectile randomy
            float rotation = MathHelper.ToRadians(8);
            velocity = velocity.RotatedByRandom(MathHelper.Lerp(-rotation, rotation, 1));

            SoundEngine.PlaySound(SoundID.Item11, position); // Play sound every shot
        }
    }
}
