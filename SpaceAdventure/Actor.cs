using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceAdventure
{
    class Actor
    {
        public string Name { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public bool FacingLeft { get; set; }
        public Facing Direction { get; set; }
        public ItemNames Equiped { get; set; }
        public List<ItemNames> Inventory;

        private int imageNumber;
        protected IDictionary<int,string> image;

        public string ActorImage
        {
            get
            {
                imageNumber = (imageNumber % 2);
                string value = image[imageNumber];
                imageNumber++;
                return value;
                //return string.Format($"{Name}_{Equiped}_{imageNumber}.gif");
            }
        }

        public Actor()
        {            
            Inventory = new List<ItemNames>();     
            imageNumber = 1;
        }

        public Actor(IDictionary<int, string> images)
            :this()
        {
            image = images;
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
