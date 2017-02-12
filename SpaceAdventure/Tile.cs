using SpaceAdventure.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceAdventure
{
    class Tile
    {
        public string TileImage { get; set; }
        public bool IsPassable { get; set; }

        public Tile(string fileName, bool passable)
        {
            TileImage = fileName;
            IsPassable = passable;
        }
    }

    static class TileList
    {
        static public Dictionary<TileNames, Tile> Tiles;

        static TileList()
        {
            Tiles = new Dictionary<TileNames, Tile>();
            Tiles.Add(TileNames.Empty, new Tile(null, true));
            Tiles.Add(TileNames.Hline, new Tile("oryx_16bit_scifi_world_09.png", false)); //Horizontal Line
            Tiles.Add(TileNames.Vline, new Tile("oryx_16bit_scifi_world_12.png", false)); //Vertical Line
            Tiles.Add(TileNames.UpperRightCorner, new Tile("oryx_16bit_scifi_world_15.png", false)); //Upper Right Corner
            Tiles.Add(TileNames.UpperLeftCorner, new Tile("oryx_16bit_scifi_world_14.png", false)); //Upper Left Corner
            Tiles.Add(TileNames.LowerRightCorner, new Tile("oryx_16bit_scifi_world_17.png", false)); //Lower Right Corner
            Tiles.Add(TileNames.LowerLeftCorner, new Tile("oryx_16bit_scifi_world_16.png", false));//Lower Left Corner
            Tiles.Add(TileNames.ClosedDoor, new Tile("oryx_16bit_scifi_world_80.png", false));
            Tiles.Add(TileNames.OpenDoor, new Tile("oryx_16bit_scifi_world_78.png", true));
            Tiles.Add(TileNames.Computer, new Tile("oryx_16bit_scifi_items_197.png", false));
            Tiles.Add(TileNames.BarrelFull, new Tile("oryx_16bit_scifi_world_710.png", false));
            Tiles.Add(TileNames.Floor, new Tile("oryx_16bit_scifi_world_01.png", true));
            Tiles.Add(TileNames.TUp, new Tile("oryx_16bit_scifi_world_22.png", false));
            Tiles.Add(TileNames.TDown, new Tile("oryx_16bit_scifi_world_19.png", false));
            Tiles.Add(TileNames.TLeft, new Tile("oryx_16bit_scifi_world_20.png", false));
            Tiles.Add(TileNames.TRight, new Tile("oryx_16bit_scifi_world_21.png", false));
            Tiles.Add(TileNames.Cross, new Tile("oryx_16bit_scifi_world_18.png", false));
        }
    }
}
