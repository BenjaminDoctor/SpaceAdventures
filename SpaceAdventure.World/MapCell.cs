using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SpaceAdventure.Common;
using SpaceAdventure.Common.Enums;

namespace SpaceAdventure.World
{
    public class MapCell
    {
        public TileNames Tile { get; set; }
        //public List<TileNames> Tiles = new List<TileNames>();
        public Dictionary<string, TileNames> Tiles = new Dictionary<string, TileNames>();
        public ItemNames Inventory { get; set; }
        

        public MapCell(string name,TileNames tile)
        {
            Tile = tile;
            Tiles.Add("Floor", TileNames.Empty );
            Tiles.Add("Item", TileNames.Empty);
            Tiles[name] = tile;
        }

        public void Add(string name,TileNames tile)
        {
            Tiles.Add(name,tile);
        }

        public void Add(string name,int tileID)
        {
            Tiles.Add(name,(TileNames)tileID);
        }

        public TileNames TileID
        {
            get
            {
                return Tiles.Count > 0 ? Tiles["Floor"] : 0;
            }

            set
            {
                if (Tiles.Count > 0)
                {
                    Tiles["Floor"] = value;
                }
                else
                {
                    Add("Item",value);
                }
            }
        }

        public bool IsPassable
        {            
            get
            {
                foreach (var t in Tiles.Values)
                {                    
                    if (!TileList.Tiles[t].IsPassable)
                    {
                        return false;
                    }
                }
                return true;
            }
        }
    }
}
