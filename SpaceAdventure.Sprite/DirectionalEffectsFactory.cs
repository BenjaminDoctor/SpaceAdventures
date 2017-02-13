using SpaceAdventure.Common;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceAdventure.Sprite
{
    public class DirectionalEffectsFactory<T>
    {
        IDictionary<Effects, Lazy<SingleFrameDirectionalSprite<Direction>>> lookup;
        Bitmap spriteSheet = Properties.Resources.FX_Small;
        Size size = new Size(24, 24);

        public DirectionalEffectsFactory()
        {
            lookup = new Dictionary<Effects, Lazy<SingleFrameDirectionalSprite<Direction>>>();

            lookup.Add(Effects.RedProjectile, new Lazy<SingleFrameDirectionalSprite<Direction>>(() => new SingleFrameDirectionalSprite<Direction>(spriteSheet, 0, 0, size, 2)));
            lookup.Add(Effects.BlueProjectile, new Lazy<SingleFrameDirectionalSprite<Direction>>(() => new SingleFrameDirectionalSprite<Direction>(spriteSheet, 0, 0, size, 2)));
            lookup.Add(Effects.WhiteProjectile, new Lazy<SingleFrameDirectionalSprite<Direction>>(() => new SingleFrameDirectionalSprite<Direction>(spriteSheet, 0, 0, size, 2)));
            lookup.Add(Effects.PurpleProjectile, new Lazy<SingleFrameDirectionalSprite<Direction>>(() => new SingleFrameDirectionalSprite<Direction>(spriteSheet, 0, 0, size, 2)));
            lookup.Add(Effects.BlackProjectile, new Lazy<SingleFrameDirectionalSprite<Direction>>(() => new SingleFrameDirectionalSprite<Direction>(spriteSheet, 0, 0, size, 2)));
            lookup.Add(Effects.GreenProjectile, new Lazy<SingleFrameDirectionalSprite<Direction>>(() => new SingleFrameDirectionalSprite<Direction>(spriteSheet, 0, 0, size, 2)));
            lookup.Add(Effects.IceProjectile, new Lazy<SingleFrameDirectionalSprite<Direction>>(() => new SingleFrameDirectionalSprite<Direction>(spriteSheet, 0, 0, size, 2)));
            lookup.Add(Effects.LavaProjectilve, new Lazy<SingleFrameDirectionalSprite<Direction>>(() => new SingleFrameDirectionalSprite<Direction>(spriteSheet, 0, 0, size, 2)));
        }

    }
}
