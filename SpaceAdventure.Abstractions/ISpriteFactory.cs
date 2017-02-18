using SpaceAdventure.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceAdventure.Abstractions
{
    public interface ISpriteFactory
    {
        ISpriteImage Get(CharacterType sprite, CharacterState state);
        ISpriteImage Get(CharacterType sprite, ItemNames item);
    }
}
