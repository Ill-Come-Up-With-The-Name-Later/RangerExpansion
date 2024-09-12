using RangerExpansion.Content.Projectiles.Bullets.Duplex;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace RangerExpansion.Content.Items.Ammo.Bullets.DuplexBullet
{
    class DuplexRound : ModItem
    {
        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 99;
        }

        public override void SetDefaults()
        {
            Item.damage = 7;
            Item.DamageType = DamageClass.Ranged;
            Item.width = 10;
            Item.height = 24;
            Item.maxStack = 9999;
            Item.knockBack = 2;
            Item.consumable = true;
            Item.value = 10;
            Item.rare = ItemRarityID.Green;
            Item.shoot = ModContent.ProjectileType<DuplexBulletProjectile>();
            Item.shootSpeed = 12f;
            Item.ammo = AmmoID.Bullet;
        }
    }
}
