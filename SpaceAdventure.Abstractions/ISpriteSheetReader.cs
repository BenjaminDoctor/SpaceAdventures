using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceAdventure.Abstractions
{
    public interface ISpriteSheetReader
    {
        Bitmap SpriteSheet { get; }
        int ImageWidth { get; }
        int ImageHeight { get; }

        Bitmap GetImage(int row, int column);
    }
}
