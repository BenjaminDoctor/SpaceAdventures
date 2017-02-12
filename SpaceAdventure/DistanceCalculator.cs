using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceAdventure
{
    public class DistanceCalculator : IDistanceCalculator
    {
        public int DistanceBetween(Point current, Point goal)
        {
            int value = 0;

            value = Math.Abs(current.X - goal.X) + Math.Abs(current.Y - goal.Y);

            return value;
        }
    }
}
