using SpaceAdventure.Abstractions;
using SpaceAdventure.Common;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceAdventure.Common
{
    public class SpriteSheetReader : ISpriteSheetReader
    {
        Bitmap SpriteSheet { get; set; }
        int ImageWidth { get; set; }
        int ImageHeight { get; set; }

        Bitmap GetImage(int row, int column)
        {
            return new Bitmap(SpriteSheet).Clone(new Rectangle(column * ImageWidth, row * ImageHeight, ImageWidth, ImageHeight), SpriteSheet.PixelFormat);
        }
    }
}
