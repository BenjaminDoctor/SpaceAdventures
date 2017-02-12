using SpaceAdventure.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpaceAdventure.Common;

namespace SpaceAdventure.Sprite
{
    public class SpriteFactory : ISpriteFactory
    {
        private IDictionary<SpriteType,ISpriteImage> spriteImages;

        public ISpriteImage Get(SpriteType sprite)
        {
            throw new NotImplementedException();
        }


    }
}
