using Terraria;
using Terraria.ModLoader;

namespace UltimateRangerExpansion.Content.Projectiles
{
    class ProjectileImmunity : GlobalProjectile
    {
        public override void OnHitNPC(Projectile projectile, NPC target, NPC.HitInfo hit, int damageDone)
        {
            if(projectile.damage > 0 && projectile.DamageType == DamageClass.Ranged)
            {
                target.immune[Main.myPlayer] = 0;
            }
        }
    }
}
