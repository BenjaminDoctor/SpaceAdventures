using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceAdventure.Abstractions
{
    public interface IIntergerSpriteImage : ISpriteImage
    {
        IDictionary<int, Bitmap> Images { get; }
    }
}
