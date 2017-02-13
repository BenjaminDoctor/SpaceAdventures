using SpaceAdventure.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceAdventure.Abstractions
{
    public interface ISpriteFactory<T>
    {
        ISpriteImage<T> Get(CharacterType sprite, CharacterState state);
        ISpriteImage<T> Get(CharacterType sprite, ItemNames item);
    }
}
