using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SpaceAdventure.Abstractions;


namespace SpaceAdventure.Sprite
{
    public class SpriteImage<T> : ISpriteImage<T>
    {
        public IDictionary<T, Bitmap> Images { get; set; }

        protected Bitmap spriteSheet;
        protected Size frameSize;
        protected int squareSize = 24;
        
        

        public SpriteImage(Bitmap spriteSheet,Size frameSize)
        {
            Images = new Dictionary<T, Bitmap>();
            this.spriteSheet = spriteSheet;
            this.frameSize = frameSize;
            this.squareSize = frameSize.Width;
        }

        //public SpriteImage(Bitmap spriteSheet, Size frameSize)
    }
}
