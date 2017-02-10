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
        Queue<Point> path;
        public Point Goal {get;set;}
        public int Delay = 2;

        //public NPC(IDictionary<int, string> images)
        //{
        //    base.image = images;
        //}

        public NPC(ISpriteImage images)
        {
            base.sprite = images;
        }

        public void SetPosition(int x, int y)
        {
            base.X = x;
            base.Y = y;
        }        
    }
}
