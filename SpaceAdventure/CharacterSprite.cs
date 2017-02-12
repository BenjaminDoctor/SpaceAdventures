using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceAdventure
{
    public class CharacterSprite : ISpriteImage
    {
        public IDictionary<int, Bitmap> Images { get; set; }

        private Bitmap spriteSheet = Properties.Resources.Creatures;
        private Bitmap spriteSheetFlip = Properties.Resources.Creatures;
        private static int Width = 24;
        private static int Heigth = 24;

        public CharacterSprite(int row, int column)
        {
            Images = new Dictionary<int, Bitmap>();            
            Images.Add(0, new Bitmap(spriteSheet).Clone(new Rectangle(row * Heigth, column * Width, Width, Heigth), spriteSheet.PixelFormat));
            Images.Add(1, new Bitmap(spriteSheet).Clone(new Rectangle((row + 1) * Heigth, column * Width, Width, Heigth), spriteSheet.PixelFormat));

            spriteSheetFlip.RotateFlip(RotateFlipType.RotateNoneFlipX);
            Images.Add(2, new Bitmap(spriteSheetFlip).Clone(new Rectangle((31 -row) * Heigth, column * Width, Width, Heigth), spriteSheetFlip.PixelFormat));
            Images.Add(3, new Bitmap(spriteSheetFlip).Clone(new Rectangle((31 - row - 1) * Heigth, column * Width, Width, Heigth), spriteSheetFlip.PixelFormat));
        }

    }
}
