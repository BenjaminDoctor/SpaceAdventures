using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

using SpaceAdventure.Abstractions;
using SpaceAdventure.Common;

namespace SpaceAdventure
{
    class NPC : Actor
    {
        Point startPosition;
        Queue<Point> path;
        public Point Goal {get;set;}
        public int Delay = 2;

        private DistanceCalculator calculator;

        public NPC()
        {
            calculator = new DistanceCalculator();
        }

        public NPC(CharacterType character, ItemNames equipedItem, Point startingPosition)
            : base(character, equipedItem, startingPosition)
        {
            calculator = new DistanceCalculator();
        }

        public NPC(ISpriteImage<int> images,Point startingPosition) : base(images,startingPosition)
        {
            calculator = new DistanceCalculator();
        }

        public void SetPosition(int x, int y)
        {
            base.Position = new Point(x, y);
        }

        public void Update(Point heroPosition, Func<Point,Point,List<Point>>PathFind)
        {
            if (calculator.DistanceBetween(Position,heroPosition) > 3)
            {
                List<Point> path = PathFind(Position, heroPosition);

                if (path.Count > 1)
                {
                    Point p = path.First(t => t.X != Position.X || t.Y != Position.Y);

                    if (p.X < Position.X)
                    {
                        FacingLeft = true;
                    }
                    else
                    {
                        FacingLeft = false;
                    }

                    SetPosition(p.X, p.Y);
                }
                else
                {
                    SetPosition(Position.X, Position.Y);
                }
            }
        }        
    }
}
