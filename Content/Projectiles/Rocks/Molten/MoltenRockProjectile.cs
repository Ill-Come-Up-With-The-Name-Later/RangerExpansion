using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using UltimateRangerExpansion.Content.Projectiles.Rocks.Iron;

namespace UltimateRangerExpansion.Content.Projectiles.Rocks.Molten
{
    class MoltenRockProjectile : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.CloneDefaults(ModContent.ProjectileType<IronBallProjectile>());
        }

        public override void ModifyHitNPC(NPC target, ref NPC.HitModifiers modifiers)
        {
            target.AddBuff(BuffID.OnFire, 10 * 60);
        }

        public override void AI()
        {
            Player owner = Main.player[Projectile.owner];

            if (!(Main.myPlayer == owner.whoAmI)) // Prevent some potential odd behavior
            {
                Projectile.Kill();
                return;
            }

            if(Projectile.timeLeft % 3 == 0)
            {
                Dust.NewDust(Projectile.position, 1, 1, DustID.FlameBurst);
            }

            Projectile.velocity.Y += 0.08f;
            Projectile.rotation += 2;
        }
    }
}
