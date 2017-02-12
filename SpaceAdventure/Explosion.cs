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
        protected ISpriteImage images;

        public Bitmap ExplosionImage
        {
            get
            {
                imageNumber = (imageNumber % 2);
                var value = images.Images[imageNumber];
                imageNumber++;
                Counter--;
                return value;
            }
        }

        public Explosion(ISpriteImage images, Point position)
        {
            Position = position;
            this.images = images;
            Counter = 6;
        }
    }
}
