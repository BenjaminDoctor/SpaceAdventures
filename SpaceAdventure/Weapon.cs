using SpaceAdventure.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpaceAdventure.Common;
using System.IO;
using SpaceAdventure.Common.Enums;

namespace SpaceAdventure
{
    public class Weapon : IWeapon
    {
        public ItemNames Name { get; set; }
        public IItemSprite Image { get; set; }
        public IDirectionalSpriteImage Attack { get; set; }
        public IItemSprite CollisionEffect { get; set; }
        public Stream AttackSound { get; set; }
        public Stream CollisionSound { get; set; }
        public int Range { get; set; }

        public Weapon(ItemNames Name, IItemSprite Image, IDirectionalSpriteImage Attack, 
        IItemSprite CollisionEffect, Stream AttackSound, Stream CollisionSound, int Range)
        {
            this.Name = Name;
            this.Image = Image;
            this.Attack = Attack;
            this.CollisionEffect = CollisionEffect;
            this.AttackSound = AttackSound;
            this.CollisionSound = CollisionSound;
            this.Range = Range;
        }

        
    }
}
