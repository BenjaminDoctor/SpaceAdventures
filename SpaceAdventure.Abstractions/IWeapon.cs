using SpaceAdventure.Common.Enums;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceAdventure.Abstractions
{
    public interface IWeapon
    {
        ItemNames Name { get; set; }
        IItemSprite Image { get; set; }
        IDirectionalSpriteImage Attack { get; set; }
        IItemSprite CollisionEffect { get; set; }
        Stream AttackSound { get; set; }
        Stream CollisionSound { get; set; }
        int Range { get; set; }
    }
}
