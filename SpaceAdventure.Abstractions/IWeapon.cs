using SpaceAdventure.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceAdventure.Abstractions
{
    public interface IWeapon
    {
        ItemNames Name { get; set; }
        IItemSprite Image { get; set; }
        object Attack { get; set; }
        IItemSprite CollisionEffect { get; set; }
        object Sound { get; set; }
        int Range { get; set; }
    }
}
