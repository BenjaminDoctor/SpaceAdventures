using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SpaceAdventure.Abstractions;


namespace SpaceAdventure.Sprite
{
    public class CharacterSprite<T> : ISpriteImage<int>
    {
        public IDictionary<int, Bitmap> Images { get; set; }

        private Bitmap spriteSheet = Properties.Resources.Creatures;
        private Bitmap spriteSheetFlip = Properties.Resources.Creatures;
        private static int SquareSize = 24;

        public CharacterSprite(int row, int column)
        {
            Images = new Dictionary<int, Bitmap>();
                             
            Images.Add(0, new Bitmap(spriteSheet).Clone(new Rectangle(column * SquareSize, row * SquareSize, SquareSize, SquareSize), spriteSheet.PixelFormat));
            Images.Add(1, new Bitmap(spriteSheet).Clone(new Rectangle((column + 1) * SquareSize, row * SquareSize, SquareSize, SquareSize), spriteSheet.PixelFormat));

            spriteSheetFlip.RotateFlip(RotateFlipType.RotateNoneFlipX);
            Images.Add(2, new Bitmap(spriteSheetFlip).Clone(new Rectangle((31 - column) * SquareSize, row * SquareSize, SquareSize, SquareSize), spriteSheetFlip.PixelFormat));
            Images.Add(3, new Bitmap(spriteSheetFlip).Clone(new Rectangle((31 - column - 1) * SquareSize, row * SquareSize, SquareSize, SquareSize), spriteSheetFlip.PixelFormat));
        }

    }
}
