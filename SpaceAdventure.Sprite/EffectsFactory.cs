using SpaceAdventure.Abstractions;
using SpaceAdventure.Common;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceAdventure.Sprite
{
    public class EffectsFactory
    {
        IDictionary<Effects, Lazy<ItemSprite>> lookup;
        Bitmap spriteSheet = Properties.Resources.FX_Small;
        Size size = new Size(24,24);

        public EffectsFactory()
        {
            lookup = new Dictionary<Effects, Lazy<ItemSprite>>();

            lookup.Add(Effects.SingleStrike,new Lazy<ItemSprite>(() => new ItemSprite(spriteSheet,0,0,size,2)));
            //lookup.Add(Effects.SingleStrike, new Lazy<ItemSprite>(() => new ItemSprite(spriteSheet, 0, 0, size, 2)));
            lookup.Add(Effects.TripleStrike, new Lazy<ItemSprite>(() => new ItemSprite(spriteSheet, 2, 0, size, 2)));
            lookup.Add(Effects.YellowExplosion, new Lazy<ItemSprite>(() => new ItemSprite(spriteSheet, 0, 2, size, 3)));
            lookup.Add(Effects.GreyExplosion, new Lazy<ItemSprite>(() => new ItemSprite(spriteSheet, 0, 5, size, 5)));
            lookup.Add(Effects.BlueExplosion, new Lazy<ItemSprite>(() => new ItemSprite(spriteSheet, 1, 2, size, 4)));
            lookup.Add(Effects.PurpleExplosion, new Lazy<ItemSprite>(() => new ItemSprite(spriteSheet, 1, 5, size, 5)));
            lookup.Add(Effects.BlackExplosion, new Lazy<ItemSprite>(() => new ItemSprite(spriteSheet, 2, 2, size, 4)));
            lookup.Add(Effects.GreenExplosion, new Lazy<ItemSprite>(() => new ItemSprite(spriteSheet, 2, 5, size, 4)));
            lookup.Add(Effects.Slash, new Lazy<ItemSprite>(() => new ItemSprite(spriteSheet, 4, 0, size, 1)));
            lookup.Add(Effects.SmallElectric, new Lazy<ItemSprite>(() => new ItemSprite(spriteSheet, 8, 0, size, 4)));
            lookup.Add(Effects.LargeElectric, new Lazy<ItemSprite>(() => new ItemSprite(spriteSheet, 9, 0, size, 4)));

            
        }

        public ItemSprite Get(Effects effect)
        {
            return lookup[effect].Value;
        }
    }
}
