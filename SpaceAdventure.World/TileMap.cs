#define Test
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

using SpaceAdventure.Common;
using SpaceAdventure.Common.Enums;

namespace SpaceAdventure.World
{
    public class TileMap
    {
        public List<MapRow> Rows = new List<MapRow>();
        public int MapWidth;
        public int MapHeight;

        static Random random = new Random();
        private List<TileRoom> rooms = new List<TileRoom>();
        private List<Point> offsets = new List<Point>();

        public TileMap(int w, int h)
        {
            MapWidth = w;
            MapHeight = h;

            for (int r = 0; r < MapHeight; r++)
            {
                MapRow thisRow = new MapRow();
                for (int c = 0; c < MapWidth; c++)
                {
                    thisRow.Columns.Add(new MapCell("Floor",TileNames.Floor));
                }
                Rows.Add(thisRow);
            }

            rooms.Add(new TileRoom(8,7));
            rooms.Add(new TileRoom(5,5));

#if Test
            rooms[0].SetOffsets(MapWidth, MapHeight, new Point(8,0));
            rooms[1].SetOffsets(MapWidth, MapHeight, new Point(8,2));
#else

            foreach (TileRoom room in rooms)
            {
                room.SetOffsets(MapWidth, MapHeight);
                System.Diagnostics.Debug.WriteLine(room.Offset.ToString());
            }
#endif
            #region MyRegion
            if (rooms.Count > 1)
            {
                CleanOverLap();
            }

            LoadRoomsOnToMap();
        }

        private void CleanOverLap()
        {
            for (int i = 1; i < rooms.Count; i++)
            {
                int fr = i - 1;
                int sr = i;

                TileRoom room1 = rooms[fr];
                TileRoom room2 = rooms[sr];

                //Find x and y value range for the first room
                int room1LowerX = room1.Offset.X;
                int room1UpperX = room1.Columns + room1.Offset.X - 1;

                int room1LowerY = room1.Offset.Y;
                int room1UpperY = room1.Rows + room1.Offset.Y - 1;

                //Find x and y value range for the second room
                int room2LowerX = room2.Offset.X;
                int room2UpperX = room2.Columns + room2.Offset.X - 1;

                int room2LowerY = room2.Offset.Y;
                int room2UpperY = room2.Rows + room2.Offset.Y - 1;


                for (int row = 0; row < MapHeight; row++)
                {
                    for (int col = 0; col < MapWidth; col++)
                    {
                        if (room1LowerY <= row + room2.Offset.Y && row + room2.Offset.Y <= room1UpperY)
                        {
                            {
                                if (room1LowerX <= col + room2.Offset.X && col + room2.Offset.X <= room1UpperX)
                                {
                                    if (0 <= row && row < room2.Rows && 0 <= col && col < room2.Columns)
                                    {
                                        room2.RoomLayout[row].Columns[col].Tiles["Floor"] = TileNames.Empty;
                                        room2.RoomLayout[row].Columns[col].Tiles["Item"] = TileNames.Empty;
                                    }
                                }
                            }
                        }

                        if (0 < room2LowerY && room2LowerY < row + room1.Offset.Y && row + room1.Offset.Y < room2UpperY)
                        {
                            if (room2LowerX > 0 && room2LowerX < col + room1.Offset.X && col + room1.Offset.X < room2UpperX)
                            {
                                if (0 <= row && row < room1.Rows && 0 <= col && col < room1.Columns)
                                {
                                    room1.RoomLayout[row].Columns[col].Tiles["Item"] = TileNames.Empty;
                                }
                            }
                        }
                        else if (0 <= room2LowerY && room2LowerY < row + room1.Offset.Y && row + room1.Offset.Y < room2UpperY)
                        {
                            if (room2LowerX > 0 && room2LowerX < col + room1.Offset.X && col + room1.Offset.X < room2UpperX)
                            {
                                if (0 <= row && row < room1.Rows && 0 <= col && col < room1.Columns)
                                {
                                    room1.RoomLayout[row].Columns[col].Tiles["Item"] = TileNames.Empty;
                                }
                            }
                        }
                        //else if (room1UpperY == room2LowerY)
                        //{
                        //    for (int z = room2LowerX - room2.Offset.X; z < room2UpperX - room2.Offset.X; z++)
                        //    {
                        //        room2.RoomLayout[0].Columns[z].Tiles["Item"] = TileNames.Empty;
                        //    }
                        //}
                    }
                } 
            #endregion
                if ((room1LowerX <= room2LowerX & room2LowerX <= room1UpperX & room1LowerY <= room2LowerY & room2LowerY <= room1UpperY) ||
                    (room1UpperX >= room2UpperX & room2UpperX >= room1LowerX & room1UpperY >= room2UpperY & room2UpperY >= room1LowerY) ||
                    (room1UpperX >= room2UpperX & room2UpperX >= room1LowerX & room1UpperY <= room2UpperY & room2UpperY >= room1LowerY) ||
                    (room1UpperX <= room2UpperX & room2UpperX >= room1LowerX & room1UpperY >= room2UpperY & room2UpperY >= room1LowerY))
                {
                    if (room1LowerX == room2LowerX)
                    {
                        if (room1UpperY < room2UpperY & room1UpperY != room2UpperY)
                        {
                            room1.RoomLayout[room1.Rows - 1].Columns[0].Tiles["Item"] = TileNames.Vline;
                        }
                        if (room1UpperX > room2UpperX & room1LowerY < room2LowerY & room1UpperY != room2UpperY)
                        {
                            room1.RoomLayout[room1.Rows - 1].Columns[room2UpperX - room1.Offset.X].Tiles["Item"] = TileNames.UpperLeftCorner;
                        }

                        if(room1LowerY > room2LowerY)
                        {
                            room1.RoomLayout[0].Columns[0].Tiles["Item"] = TileNames.Vline;

                            if (room1UpperX > room2UpperX)
                            {
                                room1.RoomLayout[0].Columns[room2UpperX - room1.Offset.X].Tiles["Item"] = TileNames.LowerLeftCorner;
                            }
                        }                        
                    }
                    else if (room1LowerX > room2LowerX & room1LowerX < room2UpperX)
                    {

                    }
                    else if (room1LowerX < room2LowerX)
                    { 
                        
                    }

                    if (room1UpperX == room2UpperX)
                    {
                        if (room1UpperY < room2UpperY)
                        {
                            room1.RoomLayout[room1.Rows - 1].Columns[room1UpperY].Tiles["Item"] = TileNames.Vline;
                        }
                        else if (room1UpperY > room2UpperY & room1LowerX < room2LowerX)
                        {
                            room1.RoomLayout[room1.Rows - 1].Columns[5].Tiles["Item"] = TileNames.Hline;
                        }
                        if (room1LowerX < room2LowerX & room1LowerX > room2LowerX)
                        {
                            room1.RoomLayout[room1.Rows - 1].Columns[room2LowerX].Tiles["Item"] = TileNames.UpperRightCorner;
                        }
                    }
                    else if(room1UpperX > room2LowerX & room1UpperX < room2UpperX)
                    {
                    
                    }
                    else if (room1UpperX > room2UpperX)
                    { 
                        
                    }

                    

                    if (room1UpperY == room2UpperY)
                    {
                        room1.RoomLayout[room1.Rows - 1].Columns[0].Tiles["Item"] = TileNames.Hline;

                        if (room1LowerX > room2LowerX)
                        {
                            room1.RoomLayout[room1.Rows - 1].Columns[0].Tiles["Item"] = TileNames.Hline;
                        }
                        else if (room1LowerX < room2LowerX)
                        { 
                            
                        }
                        else if (room1LowerX == room2LowerX)
                        {
                            room1.RoomLayout[room1.Rows - 1].Columns[0].Tiles["Item"] = TileNames.LowerLeftCorner;
                        }

                        //if (room1UpperX > room2UpperX)
                        //{
                        //    //room1.RoomLayout[room1.Rows - 1].Columns[room2UpperX - room1.Offset.X].Tiles["Item"] = TileNames.Hline;
                        //}

                        
                    }

                    //if (room1UpperX == room2UpperX)
                    //{ 
                    //    room1.RoomLayout[room1.Rows - 1].Columns[].Tiles["Item"] = TileNames.Hline;
                    //}

                    if (room1UpperX < room2UpperX)
                    {
                        if (room1LowerY < room2LowerY & room1UpperY != room2UpperY)
                        { 
                            room1.RoomLayout[room1.Rows - 1].Columns[room2LowerX -room1.Offset.X].Tiles["Item"] = TileNames.UpperRightCorner;
                        }

                        if (room1LowerY > room2LowerY)
                        { 
                            room1.RoomLayout[0].Columns[room2LowerX - room1.Offset.X].Tiles["Item"] = TileNames.LowerRightCorner;
                        }

                        if (room1UpperX < room2UpperX)
                        { 
                            room1.RoomLayout[room2UpperY - room1.Offset.Y].Columns[room1.Columns - 1].Tiles["Item"] = TileNames.UpperLeftCorner;
                        }

                        if (room1UpperY < room2UpperY)
                        { 
                            room1.RoomLayout[room2LowerY - room1.Offset.Y].Columns[room1.Columns - 1].Tiles["Item"] = TileNames.LowerLeftCorner;
                        }

                        if (room1UpperY == room2UpperY)
                        {
                            room1.RoomLayout[room1.Rows - 1].Columns[room1.Columns - 1].Tiles["Item"] = TileNames.Hline;
                        }

                        if (room1LowerY < room2LowerY & room1UpperX != room2UpperX)
                        {
                            room1.RoomLayout[room2LowerY - room1.Offset.Y].Columns[room1.Columns - 1].Tiles["Item"] = TileNames.LowerLeftCorner;
                        }
                    }

                    if (room1UpperX > room2UpperX)
                    {
                        
                        if (room1LowerY < room2LowerY & room1LowerX < room2LowerX)
                        {
                            room1.RoomLayout[room1.Rows - 1].Columns[room2LowerX - room1.Offset.X].Tiles["Item"] = TileNames.UpperRightCorner;

                            for (int z = room2LowerX + 1 - room1.Offset.X; z < room2UpperX - room1.Offset.X; z++)
                            {
                                room1.RoomLayout[room1.Rows -1].Columns[z].Tiles["Item"] = TileNames.Empty;
                            }
                        }

                        if (room1LowerY > room2LowerY & room1LowerX < room2LowerX)
                        {
                            room1.RoomLayout[0].Columns[room2LowerX - room1.Offset.X].Tiles["Item"] = TileNames.LowerRightCorner;
                        }

                        if(room1LowerY > room2LowerY & room1UpperX > room2UpperX  )
                        {
                            if (room1LowerX != room2LowerX)
                            {
                                room1.RoomLayout[room2UpperY - room1.Offset.Y].Columns[0].Tiles["Item"] = TileNames.UpperRightCorner;
                            }

                            room1.RoomLayout[0].Columns[room2UpperX - room1.Offset.X].Tiles["Item"] = TileNames.LowerLeftCorner;
                        }

                        if (room1LowerY < room2LowerY & room1LowerX > room2LowerX)
                        {
                            room1.RoomLayout[room2LowerY - room1.Offset.Y].Columns[0].Tiles["Item"] = TileNames.LowerRightCorner;

                            for (int z = room2LowerX + 1 - room1.Offset.X; z < room2UpperX - room1.Offset.X; z++)
                            {
                                room1.RoomLayout[room1.Rows - 1].Columns[z].Tiles["Item"] = TileNames.Empty;
                            }

                            for (int z = room2LowerY + 1 - room1.Offset.Y; z < room1UpperY - room1.Offset.Y; z++)
                            {
                                room1.RoomLayout[z].Columns[0].Tiles["Item"] = TileNames.Empty;
                            }
                        }
                        //if (room1LowerY > room2LowerY & room1UpperY > room2UpperY  & room1LowerX > room2LowerX & room1UpperX > room2UpperX)
                        //{ 
                            
                        //}

                        if (room1UpperY < room2UpperY & room1LowerX != room2LowerX)
                        {
                            room1.RoomLayout[room1.Rows - 1].Columns[room2UpperX - room1.Offset.X].Tiles["Item"] = TileNames.UpperLeftCorner;
                        }

                        if (room1LowerX > room2LowerX)
                        {
                            if (room1LowerY == room2LowerY)
                            {
                                room1.RoomLayout[0].Columns[0].Tiles["Item"] = TileNames.Hline;
                            }
                            
                            if (room1LowerY < room2LowerY)
                            { 
                                room1.RoomLayout[room2LowerY - room1.Offset.Y ].Columns[0].Tiles["Item"] = TileNames.LowerRightCorner;
                            }

                            if (room1UpperY > room2UpperY)
                            {
                                room1.RoomLayout[room2UpperY - room1.Offset.Y].Columns[0].Tiles["Item"] = TileNames.UpperRightCorner;
                            }
                        }
                    }
                    
                }
                //if (room1.Offset.X > room2.Offset.X && room1.Offset.Y > room2.Offset.Y)
                //{
                //    if (room1LowerX < room2.Offset.X && room2.Offset.X < room1UpperX)
                //    {
                //        room1.RoomLayout[room1.Rows - 1].Columns[room2.Offset.X - 1].Tiles["Item"] = TileNames.UpperRightCorner;
                //        room1.RoomLayout[room2.Offset.Y - 1].Columns[room1.Columns - 1].Tiles["Item"] = TileNames.LowerLeftCorner;
                //    }
                //}
                //else if (room1.Offset.X < room2.Offset.X && room1.Offset.Y > room2.Offset.Y)
                //{
                //    if (room1LowerX < room2.Offset.X && room2.Offset.X < room1UpperX)
                //    {
                //        room1.RoomLayout[0].Columns[room2.Offset.X - 1].Tiles["Item"] = TileNames.LowerRightCorner;
                //        room1.RoomLayout[room1.Rows - room1.Offset.Y - room2.Offset.Y].Columns[room1.Columns - 1].Tiles["Item"] = TileNames.UpperLeftCorner;
                //    }
                //}
                //else if (room1.Offset.X < room2.Offset.X && room1.Offset.Y < room2.Offset.Y)
                //{
                //    if (room1LowerX < room2.Offset.X && room2.Offset.X < room1UpperX)
                //    {
                //        room1.RoomLayout[room1.Columns - 1].Columns[room2.Offset.X - 1].Tiles["Item"] = TileNames.UpperRightCorner;
                //        room1.RoomLayout[room2.Offset.Y - room1.Offset.Y].Columns[room1.Columns - 1].Tiles["Item"] = TileNames.LowerLeftCorner;
                //    }
                //}
                //else if (room1.Offset.X > room2.Offset.X && room1.Offset.Y < room2.Offset.Y)
                //{
                //    if (room1LowerX > room2.Offset.X && room2.Offset.X < room1UpperX)
                //    {
                //        room1.RoomLayout[room1.Rows - 1].Columns[room1.Columns - room1.Offset.X - room2.Offset.X].Tiles["Item"] = TileNames.UpperLeftCorner;
                //        room1.RoomLayout[room2.Offset.Y - 1].Columns[0].Tiles["Item"] = TileNames.LowerRightCorner;
                //    }
                //}
                //else if (room1.Offset.X == room2.Offset.X)
                //{
                //    if (room1.Offset.Y < room2.Offset.Y)
                //    {
                //        room1.RoomLayout[room1.Rows -1].Columns[0].Tiles["Item"] = TileNames.Vline;
                //    }
                //    else if (room1.Offset.Y > room2.Offset.Y & room1UpperX > room2UpperX )
                //    {
                //        room1.RoomLayout[0].Columns[room1.Columns - room1.Offset.X - room2.Offset.X].Tiles["Item"] = TileNames.LowerLeftCorner;
                //        room1.RoomLayout[0].Columns[0].Tiles["Item"] = TileNames.Vline;
                //    }
                //    else if (room1.Offset.Y > room2.Offset.Y)
                //    {
                //        room1.RoomLayout[0].Columns[0].Tiles["Item"] = TileNames.Vline;
                //    }
                //}
                //else if (room1.Offset.Y == room2.Offset.Y)
                //{
                //    if (room1.Offset.X < room2.Offset.X)
                //    {
                //        room1.RoomLayout[0].Columns[room1.Columns - 1].Tiles["Item"] = TileNames.Vline;
                //    }
                //}
            }             
        }

        private void ChangeCorners(ref TileRoom room1,ref TileRoom room2)
        {
            List<Direction> walls = new List<Direction>();

            for (int row = 0; row < room1.Rows; row++)
            {
                for (int col = 0; col < room1.Columns; col++)
                {
                    foreach (var direction in Compass.CompassDirections)
                    {
                        if (0 < row + direction.Value.Y && row + direction.Value.Y < room1.Rows && 0 < col + direction.Value.X && col + direction.Value.X < room1.Columns)
                        {
                            if (!TileList.Tiles[room1.RoomLayout[row + direction.Value.Y].Columns[col + direction.Value.X].Tiles["Item"]].IsPassable)
                            {
                                walls.Add(direction.Key);
                                continue;
                            }
                        }
                        else if(0 < row + direction.Value.Y && row + direction.Value.Y < room2.Rows && 0 < col + direction.Value.X && col + direction.Value.X < room2.Columns)
                        {
                            if (!TileList.Tiles[room2.RoomLayout[row + direction.Value.Y ].Columns[col + direction.Value.X ].Tiles["Item"]].IsPassable)
                            {
                                walls.Add(direction.Key);
                            }
                        }
                    }
                }
            }
        }

        private void LoadRoomsOnToMap()
        {
            int counter = 0;
            foreach (var room in rooms.Distinct())
            {  
                for (int i = 0; i < room.Rows ; i++)
                {
                    for (int z = 0; z < room.Columns; z++)
                    {
                        foreach (var t in room.RoomLayout[i].Columns[z].Tiles)
                        {
                            if (t.Value  != TileNames.Empty)
                            {
                                if (0 <= i + room.Offset.Y && i + room.Offset.Y < Rows.Count() && 0 <= z + room.Offset.X && z + room.Offset.X < Rows[0].Columns.Count())
                                {
                                    Rows[i + room.Offset.Y].Columns[z + room.Offset.X].Tiles[t.Key] = t.Value;
                                }
                            }
                        }
                        //if (room.RoomLayout[i].Columns[z].Tiles["Item"] != TileNames.Empty | room.RoomLayout[i].Columns[z].Tiles["Floor"] != TileNames.Empty)
                        //{
                        //    Rows[i + room.Offset.Y ].Columns[z + room.Offset.X ] = room.RoomLayout[i].Columns[z];
                        //}
                    }
                }

                counter++;
            }
        }

        public List<Point> PathFind(Point start, Point goal)
        {
            List<Point> closedSet = new List<Point>();
            List<Point> openSet = new List<Point> { start };
            Dictionary<Point, Point> cameFrom = new Dictionary<Point, Point>();
            Dictionary<Point, int> currentDistance = new Dictionary<Point, int>();
            Dictionary<Point, float> predictedDistance = new Dictionary<Point, float>();

            currentDistance.Add(start, 0);
            predictedDistance.Add(start, 0 + Math.Abs(start.X - goal.X) + Math.Abs(start.Y + goal.Y));

            while (openSet.Count > 0)
            {
                Point current = (from p in openSet
                                 orderby predictedDistance[p] ascending
                                 select p).First();

                if (current == goal)
                {
                    return ReconstructedPath(cameFrom, goal);
                }

                openSet.Remove(current);
                closedSet.Add(current);

                foreach (var neighbor in GetNeighborNodes(current))
                {
                    var tempCurrentDistance = currentDistance[current] + 1;

                    if (closedSet.Contains(neighbor) && tempCurrentDistance >= currentDistance[neighbor])
                    {
                        continue;
                    }

                    if (!closedSet.Contains(neighbor) || tempCurrentDistance < currentDistance[neighbor])
                    {
                        if (cameFrom.Keys.Contains(neighbor))
                        {
                            cameFrom[neighbor] = current;
                        }
                        else
                        {
                            cameFrom.Add(neighbor, current);
                        }

                        currentDistance[neighbor] = tempCurrentDistance;
                        predictedDistance[neighbor] = currentDistance[neighbor] +
                            Math.Abs(neighbor.X - goal.X) +
                            Math.Abs(neighbor.Y - goal.Y);

                        if (!openSet.Contains(neighbor))
                        {
                            openSet.Add(neighbor);
                        }

                    }
                }
            }

            //throw new Exception(
            //    string.Format("Unable to find a path between {0},{1} and {2},{3}",
            //    start.X, start.Y, goal.X, goal.Y));
            return new List<Point>{start};
        }

        private IEnumerable<Point> GetNeighborNodes(Point p)
        {
            //var value = new List<Point>();
            
            foreach(Point d in Compass.CompassDirections.Values)
            {
                int newX = p.X + d.X;
                int newY = p.Y + d.Y;

                if (ValidPoint(newX, newY))
                {
                    if (this.Rows[newY].Columns[newX].IsPassable)
                    {
                        //value.Add(new Point(p.X + d.X, p.Y + d.Y));
                        yield return new Point(p.X + d.X, p.Y + d.Y);
                    }
                }
            }

            //return value;
        }

        private List<Point> ReconstructedPath(Dictionary<Point, Point> cameFrom, Point current)
        {
            if (!cameFrom.Keys.Contains(current))
            {
                return new List<Point> { current };
            }

            var path = ReconstructedPath(cameFrom, cameFrom[current]);
            path.Add(current);
            return path;
        }

        public bool ValidPoint(int newX, int newY)
        { 
            bool value = false;

            if (newX >= 0 && newX < MapWidth  && newY >= 0 && newY < MapHeight)
            {
                value = true;
            }

            return value;
        }

        public int DistanceBetweenPoints(int x1, int y1, int x2, int y2)
        {
            int value = 0;

            value = Math.Abs(x1 - x2) + Math.Abs(y1 - y2);

            return value;
        }

        private void MapToConsole()
        {
            LoadRoomsOnToMap();

            for (int i = 0; i < Rows.Count; i++)
            {
                for (int x = 0; x < Rows[i].Columns.Count(); x++)
                { 
                    System.Diagnostics.Debug.Write(Rows[i].Columns[x].Tiles["Item"]);
                }
                System.Diagnostics.Debug.Write("\r\n");
            }
        }
    }
}
