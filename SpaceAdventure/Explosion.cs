using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SpaceAdventure.Abstractions;


namespace SpaceAdventure
{
    class Explosion
    {
        public Point Position { get; set; }
        public int Counter { get; private set; }

        private int imageNumber;
        protected IDictionary<int, string> image;
        protected IItemSprite images;

        public Bitmap ExplosionImage
        {
            get
            {
                imageNumber = (imageNumber % images.Images.Count);
                var value = images.Images[imageNumber];
                imageNumber++;
                Counter--;
                return value;
            }
        }

        public Explosion(IItemSprite images, Point position)
        {
            Position = position;
            this.images = images;
            Counter = images.Images.Count * 2;
        }
    }
}
