using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceAdventure
{
    public struct CharacterSprite : ISpriteImage
    {
        public IDictionary<int, Bitmap> Images { get; set; }

        private static Bitmap spriteSheet = Properties.Resources.Creatures;
        private static int Width = 24;
        private static int Heigth = 24;

        public CharacterSprite(int row, int column)
        {
            Images = new Dictionary<int, Bitmap>();
            Images.Add(0, new Bitmap(spriteSheet).Clone(new Rectangle(row * Heigth, column * Width, Width, Heigth), spriteSheet.PixelFormat));
            Images.Add(1, new Bitmap(spriteSheet).Clone(new Rectangle((row + 1) * Heigth, column * Width, Width, Heigth), spriteSheet.PixelFormat));
        }

    }
}
