using SpaceAdventure.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceAdventure.Abstractions
{
    public interface ISpriteFactory
    {
        ISpriteImage Get(SpriteType sprite);
    }
}
