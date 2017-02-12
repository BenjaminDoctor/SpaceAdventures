using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceAdventure
{
    class Explosion
    {
        public Point Position { get; set; }
        public int Counter { get; private set; }

        private int imageNumber;
        protected IDictionary<int, string> image;

        public string ExplosionImage
        {
            get
            {
                imageNumber = (imageNumber % 2);
                string value = image[imageNumber];
                imageNumber++;
                Counter--;
                return value;
                //return string.Format($"{Name}_{Equiped}_{imageNumber}.gif");
            }
        }

        public Explosion(IDictionary<int, string> images, Point position)
        {
            image = images;
            Position = position;
            Counter = 6;
        }
    }
}
