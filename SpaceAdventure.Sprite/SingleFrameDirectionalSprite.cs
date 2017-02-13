using SpaceAdventure.Common;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceAdventure.Sprite
{
    public class SingleFrameDirectionalSprite<T>
    {
        public IDictionary<Direction, Bitmap> Images { get; private set; }

        private int squareSize = 24;
        private Size frameSize;
        private Bitmap spriteSheet = Properties.Resources.FX_Small;

        public SingleFrameDirectionalSprite(Bitmap spriteSheet, int row, int column, Size frameSize, int frameCount )
        {
            if (!typeof(T).Equals(typeof(Direction))) throw new ArgumentException("Invalid type");
            this.spriteSheet = spriteSheet;
            this.frameSize = frameSize;

            initializeImages(row, column);
        }

        private void initializeImages(int row, int column)
        {
            Images = new Dictionary<Direction, Bitmap>();
            
            Images.Add(Direction.Right, new Bitmap(spriteSheet).Clone(ImageFrame(row,column,0), spriteSheet.PixelFormat));
            Images.Add(Direction.Up, new Bitmap(spriteSheet).Clone(ImageFrame(row, column, 1), spriteSheet.PixelFormat));
            Images.Add(Direction.Left, new Bitmap(spriteSheet).Clone(ImageFrame(row, column,2),spriteSheet.PixelFormat));
            Images.Add(Direction.Down, new Bitmap(spriteSheet).Clone(ImageFrame(row, column, 3), spriteSheet.PixelFormat));
            Images.Add(Direction.DownRight, new Bitmap(spriteSheet).Clone(ImageFrame(row, column, 4), spriteSheet.PixelFormat));
            Images.Add(Direction.DownLeft, new Bitmap(spriteSheet).Clone(ImageFrame(row, column, 5), spriteSheet.PixelFormat));
            Images.Add(Direction.UpLeft, new Bitmap(spriteSheet).Clone(ImageFrame(row, column, 6), spriteSheet.PixelFormat));
            Images.Add(Direction.UpRight, new Bitmap(spriteSheet).Clone(ImageFrame(row, column, 7), spriteSheet.PixelFormat));
        }

        private Rectangle ImageFrame(int row, int column, int frame)
        {
            return new Rectangle(new Point((column + frame) * squareSize, row * squareSize), frameSize);
        }
    }
}
