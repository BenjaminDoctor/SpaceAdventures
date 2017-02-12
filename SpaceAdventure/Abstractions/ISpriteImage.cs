using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceAdventure
{
    public interface ISpriteImage
    {
        IDictionary<int, Bitmap> Images { get; set; }
    }
}
