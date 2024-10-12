using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using UltimateRangerExpansion.Content.Buffs.Innacurate;

namespace UltimateRangerExpansion.Common.Global
{
    class VortexInflictInnacurate : GlobalProjectile
    {
        int multiplier = 1;

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

                    target.AddBuff(ModContent.BuffType<Innacurate>(), 60 * 5 * multiplier);
                }
            }
        }
    }
}
