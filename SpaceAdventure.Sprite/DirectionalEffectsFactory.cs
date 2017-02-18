using SpaceAdventure.Abstractions;
using SpaceAdventure.Common;
using SpaceAdventure.Common.Enums;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceAdventure.Sprite
{
    public class DirectionalEffectsFactory
    {
        IDictionary<Effects, Lazy<IDirectionalSpriteImage>> lookup;
        Bitmap spriteSheet = Properties.Resources.FX_Small;
        Size size = new Size(24, 24);

        public DirectionalEffectsFactory()
        {
            lookup = new Dictionary<Effects, Lazy<IDirectionalSpriteImage>> ();

            lookup.Add(Effects.RedProjectile, new Lazy<IDirectionalSpriteImage>(() => new SingleFrameDirectionalSprite(spriteSheet, 11, 0, size, 2)));
            lookup.Add(Effects.BlueProjectile, new Lazy<IDirectionalSpriteImage>(() => new SingleFrameDirectionalSprite(spriteSheet, 12, 0, size, 2)));
            lookup.Add(Effects.WhiteProjectile, new Lazy<IDirectionalSpriteImage>(() => new SingleFrameDirectionalSprite(spriteSheet, 13, 0, size, 2)));
            lookup.Add(Effects.PurpleProjectile, new Lazy<IDirectionalSpriteImage>(() => new SingleFrameDirectionalSprite(spriteSheet, 14, 0, size, 2)));
            lookup.Add(Effects.BlackProjectile, new Lazy<IDirectionalSpriteImage>(() => new SingleFrameDirectionalSprite(spriteSheet, 15, 0, size, 2)));
            lookup.Add(Effects.GreenProjectile, new Lazy<IDirectionalSpriteImage>(() => new SingleFrameDirectionalSprite(spriteSheet, 16, 0, size, 2)));
            lookup.Add(Effects.IceProjectile, new Lazy<IDirectionalSpriteImage>(() => new SingleFrameDirectionalSprite(spriteSheet, 16, 0, size, 2)));
            lookup.Add(Effects.LavaProjectilve, new Lazy<IDirectionalSpriteImage>(() => new SingleFrameDirectionalSprite(spriteSheet, 18, 0, size, 2)));
        }

        public ISpriteImage Get(Effects effect)
        {
            return (ISpriteImage) lookup[effect].Value;
        }

    }
}
