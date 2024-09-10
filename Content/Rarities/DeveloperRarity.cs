using Microsoft.Xna.Framework;
using Terraria;
using Terraria.GameContent.UI;
using Terraria.ID;
using Terraria.ModLoader;

namespace RangerExpansion.Content.Rarities
{
    class DeveloperRarity : ModRarity
    {
        public override Color RarityColor => new(112, 176, 74);

        public override int GetPrefixedRarity(int offset, float valueMult)
        {
            // Developer rarity should be above purple rarity
            if(offset < 0)
            {
                return ItemRarityID.Purple;
            }

            return Type;
        }
    }
}
