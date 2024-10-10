using Microsoft.Xna.Framework;
using Terraria.ModLoader;

namespace UltimateRangerExpansion.Content.Rarities
{
    class RandomIdeas : ModRarity
    {
        public override Color RarityColor => new(145, 255, 248);

        public override int GetPrefixedRarity(int offset, float valueMult)
        {
            return Type; // Modifiers cannot affect rarity
        }
    }
}
