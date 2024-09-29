using Terraria;
using Terraria.ModLoader;
using UltimateRangerExpansion.Content.Projectiles.Pets.Drone;

namespace UltimateRangerExpansion.Content.Buffs.DronePet
{
    class DronePetBuff : ModBuff
    {
        public override void SetStaticDefaults()
        {
            Main.buffNoTimeDisplay[Type] = true;
            Main.vanityPet[Type] = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            bool unused = false;
            player.BuffHandle_SpawnPetIfNeededAndSetTime(buffIndex, ref unused, ModContent.ProjectileType<DronePetProjectile>());
        }
    }
}
