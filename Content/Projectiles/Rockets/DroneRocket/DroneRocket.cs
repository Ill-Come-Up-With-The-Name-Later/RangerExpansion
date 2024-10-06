using Microsoft.Xna.Framework;
using System;
using Terraria.Audio;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace UltimateRangerExpansion.Content.Projectiles.Rockets.DroneRocket
{
    class DroneRocket : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            ProjectileID.Sets.IsARocketThatDealsDoubleDamageToPrimaryEnemy[Type] = true;
            ProjectileID.Sets.PlayerHurtDamageIgnoresDifficultyScaling[Type] = true;
            ProjectileID.Sets.RocketsSkipDamageForPlayers[Type] = true;

            ProjectileID.Sets.Explosive[Type] = true;
        }

        public override void SetDefaults()
        {
            Projectile.width = 26;
            Projectile.height = 20;
            Projectile.DamageType = DamageClass.Ranged;
            Projectile.friendly = true;

            Projectile.penetrate = -1;

            Projectile.timeLeft = 1000;
        }

        public override void AI()
        {
            if (Projectile.owner == Main.myPlayer && Projectile.timeLeft <= 3)
            {
                Projectile.PrepareBombToBlow();
            }
            else
            {
                if (Math.Abs(Projectile.velocity.X) >= 8f || Math.Abs(Projectile.velocity.Y) >= 8f)
                {
                    for (int i = 0; i < 2; i++)
                    {
                        float posOffsetX = 0f;
                        float posOffsetY = 0f;
                        if (i == 1)
                        {
                            posOffsetX = Projectile.velocity.X * 0.5f;
                            posOffsetY = Projectile.velocity.Y * 0.5f;
                        }

                        Dust fireDust = Dust.NewDustDirect(new Vector2(Projectile.position.X + 3f + posOffsetX, Projectile.position.Y + 3f + posOffsetY) - Projectile.velocity * 0.5f,
                            Projectile.width - 8, Projectile.height - 8, DustID.Torch, 0f, 0f, 100);
                        fireDust.scale *= 2f + Main.rand.Next(10) * 0.1f;
                        fireDust.velocity *= 0.2f;
                        fireDust.noGravity = true;

                        Dust smokeDust = Dust.NewDustDirect(new Vector2(Projectile.position.X + 3f + posOffsetX, Projectile.position.Y + 3f + posOffsetY) - Projectile.velocity * 0.5f, Projectile.width - 8, Projectile.height - 8, DustID.Smoke, 0f, 0f, 100, default, 0.5f);
                        smokeDust.fadeIn = 1f + Main.rand.Next(5) * 0.1f;
                        smokeDust.velocity *= 0.05f;
                    }
                }

                if (Math.Abs(Projectile.velocity.X) <= 15f && Math.Abs(Projectile.velocity.Y) <= 15f)
                {
                    Projectile.velocity *= 1.1f;
                }

                if (Projectile.velocity != Vector2.Zero)
                {
                    Projectile.rotation = Projectile.velocity.ToRotation();
                }
            }
        }

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            Projectile.velocity *= 0f;
            Projectile.timeLeft = 3;
            return false;
        }

        public override void PrepareBombToBlow()
        {
            Projectile.tileCollide = false;
            Projectile.alpha = 255;

            Projectile.Resize(300, 300);
            Projectile.knockBack = 8f;
        }

        public override void OnKill(int timeLeft)
        {
            SoundEngine.PlaySound(SoundID.Item14, Projectile.position);

            Projectile.Resize(75, 75);

            for (int i = 0; i < 30; i++)
            {
                Dust smokeDust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.Smoke, 0f, 0f, 100, default, 1.5f);
                smokeDust.velocity *= 1.4f;
            }

            for (int j = 0; j < 20; j++)
            {
                Dust fireDust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.Torch, 0f, 0f, 100, default, 3.5f);
                fireDust.noGravity = true;
                fireDust.velocity *= 7f;
                fireDust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.Torch, 0f, 0f, 100, default, 1.5f);
                fireDust.velocity *= 3f;
            }

            for (int k = 0; k < 2; k++)
            {
                float speedMulti = 0.4f;
                if (k == 1)
                {
                    speedMulti = 0.8f;
                }

                Gore smokeGore = Gore.NewGoreDirect(Projectile.GetSource_Death(), Projectile.position, default, Main.rand.Next(GoreID.Smoke1, GoreID.Smoke3 + 1));
                smokeGore.velocity *= speedMulti;
                smokeGore.velocity += Vector2.One;
                smokeGore = Gore.NewGoreDirect(Projectile.GetSource_Death(), Projectile.position, default, Main.rand.Next(GoreID.Smoke1, GoreID.Smoke3 + 1));
                smokeGore.velocity *= speedMulti;
                smokeGore.velocity.X -= 1f;
                smokeGore.velocity.Y += 1f;
                smokeGore = Gore.NewGoreDirect(Projectile.GetSource_Death(), Projectile.position, default, Main.rand.Next(GoreID.Smoke1, GoreID.Smoke3 + 1));
                smokeGore.velocity *= speedMulti;
                smokeGore.velocity.X += 1f;
                smokeGore.velocity.Y -= 1f;
                smokeGore = Gore.NewGoreDirect(Projectile.GetSource_Death(), Projectile.position, default, Main.rand.Next(GoreID.Smoke1, GoreID.Smoke3 + 1));
                smokeGore.velocity *= speedMulti;
                smokeGore.velocity -= Vector2.One;
            }
        }
    }
}
