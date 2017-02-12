using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace SpaceAdventure
{
    class NPC : Actor
    {
        Point startPosition;
        Queue<Point> path;
        public Point Goal {get;set;}
        public int Delay = 2;

        public NPC(ISpriteImage images,Point startingPosition) : base(images,startingPosition)
        {
            
        }

        public void SetPosition(int x, int y)
        {
            base.Position = new Point(x, y);
        }

        public void Update()
        {

        }        
    }
}
