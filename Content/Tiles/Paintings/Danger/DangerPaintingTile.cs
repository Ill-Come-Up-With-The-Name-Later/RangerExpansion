using Terraria.DataStructures;
using Terraria;
using Terraria.ModLoader;
using Terraria.ObjectData;
using Microsoft.Xna.Framework;

namespace UltimateRangerExpansion.Content.Tiles.Paintings.Danger
{
    class DangerPaintingTile : ModTile
    {
        public override void SetStaticDefaults()
        {
            Main.tileFrameImportant[Type] = true;
            Main.tileLavaDeath[Type] = true;
            Main.tileWaterDeath[Type] = false;

            TileObjectData.newTile.CopyFrom(TileObjectData.Style3x2);

            TileObjectData.newTile.Origin = new Point16(0, 0);
            TileObjectData.newTile.CoordinateHeights = [16, 16];

            TileObjectData.addTile(Type);

            AddMapEntry(new Color(0, 0, 0), null);
        }
    }
}
