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

    public class Character : Actor
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

        public Dictionary<string, Item> Items { get; set; }

        public List<Ship> Ships { get; set; }

        public Place CharacterLocation { get; set; }

    }
}
