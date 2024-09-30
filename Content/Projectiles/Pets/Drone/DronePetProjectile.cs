using Terraria.ID;
using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace UltimateRangerExpansion.Content.Projectiles.Pets.Drone
{
    class DronePetProjectile : ModProjectile
    {
        readonly int attackRange = 1000;

        public override void SetStaticDefaults()
        {
            Main.projFrames[Projectile.type] = 2;
            Main.projPet[Projectile.type] = true;

            ProjectileID.Sets.CharacterPreviewAnimations[Projectile.type] = ProjectileID.Sets.SimpleLoop(0, Main.projFrames[Projectile.type], 6)
                .WithOffset(-10, -20f)
                .WithSpriteDirection(-1)
                .WithCode(DelegateMethods.CharacterPreview.Float);
        }

        public override void SetDefaults()
        {
            Projectile.CloneDefaults(ProjectileID.ZephyrFish);

            Projectile.width = 58;
            Projectile.height = 26;

            Projectile.damage = 50;
            Projectile.minion = true;

            AIType = ProjectileID.ZephyrFish;
        }

        public override bool PreAI()
        {
            Player player = Main.player[Projectile.owner];
            player.zephyrfish = false;

            return true;
        }

        public override void AI()
        {
            Projectile.ai[1]++;

            int attackTarget = -1;
            Projectile.Minion_FindTargetInRange(attackRange, ref attackTarget, false);

            if(attackTarget != -1)
            {
                Player player = Main.player[Projectile.owner];
                NPC targetNPC = Main.npc[attackTarget];

                Vector2 enemyPos = targetNPC.Center;
                Vector2 velocity = enemyPos - Projectile.Center;
                velocity.Normalize();
                velocity *= 28;

                float maxRotation = MathHelper.ToRadians(5);

                if (Projectile.ai[1] % 45 == 0)
                {
                    if (Main.myPlayer == Projectile.owner)
                    {
                        Projectile proj = Main.projectile[Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center,
                            velocity.RotatedByRandom(MathHelper.Lerp(-maxRotation, maxRotation, 1)),
                            ProjectileID.RocketI, 600, 7, Main.myPlayer)];

                        proj.netUpdate = true;
                        proj.usesLocalNPCImmunity = true;
                        proj.ArmorPenetration = 15;
                    }
                }

                if (Projectile.ai[1] % 18 == 0 ||
                    Projectile.ai[1] % 29 == 0 ||
                    Projectile.ai[1] % 41 == 0)
                {
                    if (Main.myPlayer == Projectile.owner)
                    {
                        Projectile proj = Main.projectile[Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center,
                            velocity.RotatedByRandom(MathHelper.Lerp(-maxRotation, maxRotation, 1)),
                            ProjectileID.Bullet, 100, 3, Main.myPlayer)];

                        proj.netUpdate = true;
                        proj.usesLocalNPCImmunity = true;
                        proj.ArmorPenetration = 50;
                    }
                }
            }

            int frameSpeed = 5;
            Projectile.frameCounter++;

            if (Projectile.frameCounter >= frameSpeed)
            {
                Projectile.frameCounter = 0;
                Projectile.frame++;

                if (Projectile.frame >= Main.projFrames[Projectile.type])
                {
                    Projectile.frame = 0;
                }
            }

            Projectile.rotation = Projectile.velocity.X * 0.05f;
        }
    }
}
