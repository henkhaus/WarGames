using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarGames.Models.ShipModel;

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
            Name = _name;
            BasePower = _basePower;
            BaseStrength = _baseStrength;
            Items = new Dictionary<string, Item>();
            Ships = new List<Ship>();
            EffectivePower = BasePower;
            EffectiveStrength = BaseStrength;
        }

        public string Name { get; set; }

        public Race Race { get; set; }

        public int ResourceTotal { get; set; }

        public Dictionary<string, Item> Items { get; set; }

        public List<Ship> Ships { get; set; }

        public Place CharacterLocation { get; set; }

        public int BasePower { get; set; }

        public int BaseStrength { get; set; }

        public int EffectivePower { get; set; }

        public int EffectiveStrength { get; set; }


        public bool Equip(Item item)
        {
            //subract playCost from character's total resources
            ResourceTotal -= item.playCost;

            // get powers
            EffectivePower += item.power;
            EffectiveStrength += item.strength;

            return true;
        }

        public bool Unequip(Item item)
        {
            // remove powers
            EffectivePower -= item.power;
            EffectiveStrength -= item.strength;

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
