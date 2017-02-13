using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

using SpaceAdventure.Common;

namespace SpaceAdventure.World
{
    public class TileRoom
    {
        List<MapRow> _room = new List<MapRow>();
        static Random random = new Random();
        int _columns;
        int _rows;
        Point _offset;

        public List<MapRow> RoomLayout
        {
            get
            {
                return _room;

            }
        }

        public int Columns
        {
            get 
            {
                return _columns;
            }
        }

        public int Rows
        {
            get
            {
                return _rows;
            }
        }

        public Point Offset
        {
            get
            {
                return _offset;
            }
            set
            {
                _offset = value;
            }
        }

        public TileRoom()
        {            
            setSize();
            CreateRoom();
        }

        public TileRoom(int x, int y)
        {
            //setSize();
            _rows = y;
            _columns = x;
            CreateRoom();
        }

        private void setSize()
        {
            _columns = random.Next(4, 15);
            _rows = random.Next(4, 10);
        }

        private List<MapRow> CreateRoom()
        {
            for (int r = 0; r < _rows; r++)
            {
                MapRow row = new MapRow();
                for (int c = 0; c < _columns ; c++)
                {
                    if (!IsFirstOrLast(r, _rows))
                    {
                        if (!IsFirstOrLast(c, _columns ))
                        {
                            row.Columns.Add(new MapCell("Floor",TileNames.Floor));
                        }
                        else
                        {
                            row.Columns.Add(new MapCell("Item",TileNames.Vline));
                        }
                    }
                    else if (IsFirstOrLast(r, _rows))
                    {
                        row.Columns.Add(new MapCell("Item",TileNames.Hline));
                    }
                    else
                    {
                        row.Columns.Add(new MapCell("Floor",TileNames.Floor));
                    }
                }

                _room.Add(row);
            }

            _room[0].Columns[0].Tiles["Item"] = TileNames.UpperLeftCorner;
            _room[0].Columns[_columns - 1].Tiles["Item"] = TileNames.UpperRightCorner;
            _room[_rows - 1].Columns[0].Tiles["Item"] = TileNames.LowerLeftCorner;
            _room[_rows - 1].Columns[_columns - 1].Tiles["Item"] = TileNames.LowerRightCorner;

            return _room;
        }

        private bool IsFirstOrLast(int r, int max)
        {
            bool value = false;

            if (r == 0 || r == max - 1)
            {
                value = true;
            }

            return value;
        }

        public void SetOffsets(int MapWidth, int MapHeight)
        {
            _offset = new Point();

            _offset.X = GetOffsetCoor(_columns , MapWidth);
            _offset.Y = GetOffsetCoor(_rows, MapHeight);
        }

        public void SetOffsets(int MapWidth, int MapHeight, Point p)
        {
            _offset = new Point();

            if (this.Rows + p.Y < MapHeight && this.Columns + p.X < MapWidth)
            {
                _offset.X = p.X ;
                _offset.Y = p.Y ;
            }
            else
            {
                _offset.X = 0;
                _offset.Y = 0;
            }
        }

        private int GetOffsetCoor(int dimensionSize, int maxSize)
        {
            int value;
            while (true)
            {
                value = random.Next(maxSize);

                if (value + dimensionSize < maxSize)
                {
                    break;
                }
            }
            return value;
        }
    }
}
