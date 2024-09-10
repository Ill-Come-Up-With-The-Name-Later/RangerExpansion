using RangerExpansion.Content.Rarities;
using System.Collections.Generic;
using Terraria;
using Terraria.ModLoader;

namespace RangerExpansion.Content.Items
{
    class DeveloperTooltip : GlobalItem
    {
        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
            if(item.rare == ModContent.RarityType<DeveloperRarity>())
            {
                tooltips.Add(new TooltipLine(Mod, "Tooltip1", "Developer Item"));
            }
        }
    }
}
