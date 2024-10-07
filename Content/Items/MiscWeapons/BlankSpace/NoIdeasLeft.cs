using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using UltimateRangerExpansion.Content.Rarities;
using Terraria.DataStructures;
using Microsoft.Xna.Framework;
using UltimateRangerExpansion.Content.Projectiles.BlankSpace.Magic;
using UltimateRangerExpansion.Content.Projectiles.BlankSpace.Madness;
using UltimateRangerExpansion.Content.Projectiles.BlankSpace.Heaven;
using UltimateRangerExpansion.Content.Projectiles.BlankSpace.Sin;

namespace UltimateRangerExpansion.Content.Items.MiscWeapons.BlankSpace
{
    class NoIdeasLeft : ModItem
    {
        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 1;
        }

        public override void SetDefaults()
        {
            // Common Properties
            Item.width = 10;
            Item.height = 10;
            Item.rare = ModContent.RarityType<DeveloperRarity>();

            // Use Properties
            Item.useTime = 2;
            Item.useAnimation = 2;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.autoReuse = true;
            Item.consumeAmmoOnLastShotOnly = true;
            Item.UseSound = SoundID.Item40;

            // Weapon Properties
            Item.DamageType = DamageClass.Ranged;
            Item.damage = 1989;
            Item.knockBack = 5f;
            Item.noMelee = true;
            Item.crit = 9;

            // Gun Properties
            Item.shoot = ProjectileID.PurificationPowder;
            Item.shootSpeed = 25f;
            Item.useAmmo = AmmoID.Bullet;

            Item.value = Item.buyPrice(0, 0, 0, 0);
        }

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            float numberProjectiles = 4;
            float rotation = MathHelper.ToRadians(10);

            position += Vector2.Normalize(velocity) * 8f;
            velocity *= 0.8f;

            int[] projectiles = [ModContent.ProjectileType<Magic>(), ModContent.ProjectileType<Madness>(),
                ModContent.ProjectileType<Heaven>(), ModContent.ProjectileType<Sin>()];

            for (int i = 0; i < numberProjectiles; i++)
            {
                Vector2 perturbedSpeed = velocity.RotatedBy(MathHelper.Lerp(-rotation, rotation, i / (numberProjectiles - 1)));
                Projectile.NewProjectile(source, position, perturbedSpeed, projectiles[i], damage, knockback, player.whoAmI);
            }

            return false;
        }
    }
}
