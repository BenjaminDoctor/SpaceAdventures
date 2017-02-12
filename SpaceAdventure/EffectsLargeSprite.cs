using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceAdventure
{
    public class EffectsLargeSprite : ISpriteImage
    {
        public IDictionary<int, Bitmap> Images { get; set; }

        private Bitmap spriteSheet = Properties.Resources.FX_Large;
        private static int Width = 32;
        private static int Heigth = 32;

        //TODO: Label column and row correctly
        public EffectsLargeSprite(int row, int column)
        {
            Images = new Dictionary<int, Bitmap>();
            Images.Add(0, new Bitmap(spriteSheet).Clone(new Rectangle(row * Heigth, column * Width, Width, Heigth), spriteSheet.PixelFormat));
            Images.Add(1, new Bitmap(spriteSheet).Clone(new Rectangle((row + 1) * Heigth, column * Width, Width, Heigth), spriteSheet.PixelFormat));
        }
    }
}
