using Microsoft.Xna.Framework;
using Terraria.ModLoader;

namespace UltimateRangerExpansion.Content.Rarities
{
    class DeveloperRarity : ModRarity
    {
        public override Color RarityColor => new(112, 176, 74);

        public override int GetPrefixedRarity(int offset, float valueMult)
        {
            return Type; // Modifiers cannot affect rarity of developer items
        }
    }
}
