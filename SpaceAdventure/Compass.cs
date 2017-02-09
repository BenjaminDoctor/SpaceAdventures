using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace SpaceAdventure
{
    static class Compass
    {
        static public Dictionary<Direction,Point> CompassDirections;

        static Compass()
        {
            CompassDirections = new Dictionary<Direction, Point>();
            CompassDirections.Add(Direction.Up, new Point(0,1));
            CompassDirections.Add(Direction.Down, new Point(0,-1));
            CompassDirections.Add(Direction.Left, new Point(1,0));
            CompassDirections.Add(Direction.Right, new Point(-1,0));
        }
    }

    enum Direction {
        Up,
        Down,
        Left,
        Right 
    }
}
