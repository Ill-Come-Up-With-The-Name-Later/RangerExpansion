using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using UltimateRangerExpansion.Content.Buffs.Inaccurate;

namespace UltimateRangerExpansion.Common.Global
{
    class VortexInflictInnacurate : GlobalProjectile
    {
        private static int multiplier = 1;

        public override void OnHitPlayer(Projectile projectile, Player target, Player.HurtInfo info)
        {
            if (projectile.type == ProjectileID.VortexLaser)
            {
                if (Main.rand.NextBool())
                {
                    if (Main.expertMode) multiplier = 2;
                    if (Main.masterMode) multiplier = 3;
                    if (Main.zenithWorld) multiplier = 4;
                    if (Main.zenithWorld && Main.expertMode) multiplier = 3;
                    if (Main.zenithWorld && Main.masterMode) multiplier = 5;

                    target.AddBuff(ModContent.BuffType<Inaccurate>(), 60 * 5 * multiplier);
                }
            }
        }
    }
}
