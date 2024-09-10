using Microsoft.Xna.Framework;
using RangerExpansion.Content.Rarities;
using Terraria;
using Terraria.DataStructures;
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
            Item.scale = 1;
            Item.rare = ModContent.RarityType<DeveloperRarity>();

            // Use Properties
            Item.useTime = 5; 
            Item.useAnimation = 15;
            Item.reuseDelay = 15;
            Item.consumeAmmoOnLastShotOnly = true;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.autoReuse = true; 

            // Weapon Properties
            Item.DamageType = DamageClass.Ranged;
            Item.damage = 45;
            Item.knockBack = 3f; 
            Item.noMelee = true; 

            // Gun Properties
            Item.shoot = ProjectileID.PurificationPowder;
            Item.shootSpeed = 12f;
            Item.useAmmo = AmmoID.Bullet;
        }

        public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
        {
            // Rotate projectile randomy
            float rotation = MathHelper.ToRadians(8);
            velocity = velocity.RotatedByRandom(MathHelper.Lerp(-rotation, rotation, 1));
        }
    }
}
