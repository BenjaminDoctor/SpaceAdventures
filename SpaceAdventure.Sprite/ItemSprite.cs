using SpaceAdventure.Abstractions;
using SpaceAdventure.Common;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceAdventure.Sprite
{
    public class ItemSprite : IItemSprite
    {
        public IDictionary<int, Bitmap> Images { get; set; }

        protected Bitmap spriteSheet;
        protected Size frameSize;
        protected int squareSize = 24;

        public ItemSprite(Bitmap spriteSheet, int row, int column, Size frameSize, int frameCount)
        {
            Images = new Dictionary<int, Bitmap>();

            int index = 0;
            do
            {                
                Images.Add(index, new Bitmap(spriteSheet).Clone(new Rectangle((column + index) * squareSize, row * squareSize, squareSize, squareSize), spriteSheet.PixelFormat));
                index++;
                frameCount--;
            }
            while (frameCount > 0);
        }
    }
}
