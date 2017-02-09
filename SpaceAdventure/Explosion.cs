using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceAdventure
{
    class Explosion
    {
        public int XPosition { get; set; }
        public int YPosition { get; set; }
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

        public Explosion(IDictionary<int, string> images, int xPosition, int yPosition)
        {
            image = images;
            XPosition = xPosition;
            YPosition = yPosition;
            Counter = 6;
        }
    }
}
