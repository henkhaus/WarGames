using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarGames.Models
{
    public enum Race
    {
        Bob, 
        Cyborg, 
        FourDimensioners
    }

    public class Character
    {

        public Character(string _name, int _basePower, int _baseStrength)
        {
            name = _name;
            basePower = _basePower;
            baseStrength = _baseStrength;
            this.items = new Dictionary<string, Item>();
            this.ships = new List<Ship>();
            effectivePower = basePower;
            effectiveStrength = baseStrength;
        }

        public string name { get; set; }

        public Race race { get; set; }

        public int resourceTotal { get; set; }

        public Dictionary<string, Item> items { get; set; }

        public List<Ship> ships { get; set; }

        public Place characterLocation { get; set; }

        public int basePower { get; set; }

        public int baseStrength { get; set; }

        public int effectivePower { get; set; }

        public int effectiveStrength { get; set; }


        public bool Equip(Item item)
        {
            //subract playCost from character's total resources
            resourceTotal -= item.playCost;

            // get powers
            effectivePower += item.power;
            effectiveStrength += item.strength;

            return true;
        }

        public bool Unequip(Item item)
        {
            // remove powers
            effectivePower -= item.power;
            effectiveStrength -= item.strength;

            return true;
        }

        public bool Use(Item item)
        {
            if (item.active)
            {
                Equip(item);
                
                //TODO: use the item (attack, block, move, etc)

                // degrade item
                item.Degrade();
                // TODO: implement damage to other character
            }
            if (!item.active)
            {
                Unequip(item);
            }
            return true;
        }

    }
}
