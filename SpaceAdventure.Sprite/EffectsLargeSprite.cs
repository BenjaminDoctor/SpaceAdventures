using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SpaceAdventure.Abstractions;


namespace SpaceAdventure.Sprite
{
    public class EffectsLargeSprite<T> : SpriteImage<int> /*ISpriteImage<int>*/
    {
        //public IDictionary<int, Bitmap> Images { get; set; }

        private Bitmap spriteSheet = Properties.Resources.FX_Large;
        private static int SquareSize = 32;

        public EffectsLargeSprite(Bitmap spriteSheet, int row, int column, Size frameSize) : base(spriteSheet,frameSize)
        {
            base.Images = new Dictionary<int, Bitmap>();
            base.Images.Add(0, new Bitmap(spriteSheet).Clone(new Rectangle(column * SquareSize, row * SquareSize, SquareSize, SquareSize), spriteSheet.PixelFormat));
            base.Images.Add(1, new Bitmap(spriteSheet).Clone(new Rectangle((column + 1) * SquareSize, row * SquareSize, SquareSize, SquareSize), spriteSheet.PixelFormat));
        }
    }
}
