﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SpaceAdventure.Abstractions;


namespace SpaceAdventure
{
    class Actor
    {
        public string Name { get; set; }
        public Point Position { get; set; }
        public bool FacingLeft { get; set; }        
        public Facing Direction { get; set; }
        public ItemNames Equiped { get; set; }
        public List<ItemNames> Inventory;

        private int imageNumber;
        protected Point startPosition;

        protected ISpriteImage sprite;

        public Bitmap ActorImage
        {
            get
            {
                imageNumber = (imageNumber % 2);
                Bitmap value = FacingLeft ? sprite.Images[imageNumber]  : sprite.Images[imageNumber + 2];
                imageNumber++;
                if (imageNumber > 2) imageNumber = 1;
                return value;
            }
        }

        public Actor()
        {            
            Inventory = new List<ItemNames>();     
            imageNumber = 1;
            
        }

        public Actor(ISpriteImage images,Point startingPosition)
            :this()
        {
            sprite = images;
            this.Position = startingPosition;
        }

        public void EquipItem(ItemNames item)
        {
            if (Inventory.Contains(item))
            {
                Equiped = item;
            }
        }

        public virtual void Update(ref Stopwatch sw)
        { 
            
        }
    }
}
