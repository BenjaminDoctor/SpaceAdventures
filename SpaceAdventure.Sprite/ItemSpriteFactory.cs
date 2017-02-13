using SpaceAdventure.Common;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceAdventure.Sprite
{
    public class ItemSpriteFactory<T>
    {
        IDictionary<ItemNames, Lazy<ItemSprite>> images;
        Bitmap spriteSheet = Properties.Resources.Items;
        Size size;

        private void initImages()
        {
            size = new Size(16, 16);

            images.Add(ItemNames.Sword, new Lazy<ItemSprite>(() => new ItemSprite(spriteSheet, 5, 3, size,1)));
            images.Add(ItemNames.Pistol, new Lazy<ItemSprite>(() => new ItemSprite(spriteSheet, 5, 2, size,1)));
            images.Add(ItemNames.Shotgun, new Lazy<ItemSprite>(() => new ItemSprite(spriteSheet, 5, 1, size, 1)));
            images.Add(ItemNames.Rifle, new Lazy<ItemSprite>(() => new ItemSprite(spriteSheet, 5, 0, size, 1)));
            images.Add(ItemNames.SubMachineGun, new Lazy<ItemSprite>(() => new ItemSprite(spriteSheet, 5, 6, size, 1)));
            images.Add(ItemNames.RocketLauncher, new Lazy<ItemSprite>(() => new ItemSprite(spriteSheet, 5, 4, size, 1)));
            images.Add(ItemNames.Bazooka, new Lazy<ItemSprite>(() => new ItemSprite(spriteSheet, 5, 4, size, 1)));
            images.Add(ItemNames.Flamethrower, new Lazy<ItemSprite>(() => new ItemSprite(spriteSheet, 5, 5, size, 1)));
            images.Add(ItemNames.RedFlag, new Lazy<ItemSprite>(() => new ItemSprite(spriteSheet, 3, 19, size, 1)));
            images.Add(ItemNames.BlueFlag, new Lazy<ItemSprite>(() => new ItemSprite(spriteSheet, 3, 20, size, 1)));
            images.Add(ItemNames.GreenFlag, new Lazy<ItemSprite>(() => new ItemSprite(spriteSheet, 3, 21, size, 1)));
            images.Add(ItemNames.RedSword, new Lazy<ItemSprite>(() => new ItemSprite(spriteSheet, 5, 8, size, 1)));
            images.Add(ItemNames.BlueSword, new Lazy<ItemSprite>(() => new ItemSprite(spriteSheet, 5, 7, size, 1)));
            //images.Add(ItemNames.Shield, new Lazy<ItemSprite>(() => new ItemSprite(spriteSheet, 5, 3, size)));
        }

        public ItemSprite Get(ItemNames item)
        {
            return images[item].Value;
        }
    }
}
