using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceAdventure
{
    class Item
    {
        public string ItemImage { get; set; }
        public bool IsEquipable { get; set; }

        public Item(string fileName, bool equipment)
        {
            ItemImage = fileName;
            IsEquipable = equipment;
        }
    }

    static class ItemList
    {
        static public Dictionary<ItemNames, Item> Items;

        static ItemList()
        {
            Items = new Dictionary<ItemNames, Item>();
            Items.Add(ItemNames.Sword, new Item("oryx_16bit_scifi_items_114.png", true));
            Items.Add(ItemNames.Pistol, new Item("oryx_16bit_scifi_items_113.png", true));
            Items.Add(ItemNames.Rifle, new Item("oryx_16bit_scifi_items_111.png", true));
            Items.Add(ItemNames.MachineGun, new Item("oryx_16bit_scifi_items_117.png", true));
            Items.Add(ItemNames.Shotgun, new Item("oryx_16bit_scifi_items_112.png", true));
            Items.Add(ItemNames.Bazooka, new Item("oryx_16bit_scifi_items_115.png", true));
            Items.Add(ItemNames.RocketLauncher, new Item("oryx_16bit_scifi_items_116.png", true));
        }

        static void Add(ItemNames name, Item item)
        {
            Items.Add(name,item);
        }
    }
}
