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
        Object Image { get; set; }
        Object Attack { get; set; }
        ISpriteImage CollisionEffect { get; set; }
        Object Sound { get; set; }
    }
}
