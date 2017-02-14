using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SpaceAdventure.Abstractions;


namespace SpaceAdventure.Sprite
{
    public class SpriteImage : ISpriteImage
    {
        protected Bitmap spriteSheet;
        protected Size frameSize;
        protected int squareSize = 24;       
        

        public SpriteImage(Bitmap spriteSheet,Size frameSize)
        {
            this.spriteSheet = spriteSheet;
            this.frameSize = frameSize;
            this.squareSize = frameSize.Width;
        }
    }
}
