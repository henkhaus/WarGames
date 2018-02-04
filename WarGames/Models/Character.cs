using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarGames.Models.ShipModel;
using WarGames.Models.UnitModel;
using WarGames.Models.ActionModel;

namespace WarGames.Models
{
    public enum Race
    {
        Bob, 
        Cyborg, 
        FourDimensioners
    }

    [Serializable]
    public class Character : Actor
    {

        public Character(string _name, int _basePower, int _baseStrength)
        {
            Name = _name;
            BasePower = _basePower;
            BaseStrength = _baseStrength;
            Items = new Dictionary<string, Item>();
            Ships = new List<Ship>();
            Units = new List<Unit>();
            EffectivePower = BasePower;
            EffectiveStrength = BaseStrength;
        }

        public string Name { get; set; }

        public Race Race { get; set; }

        public Dictionary<string, Item> Items { get; set; }

        public List<Ship> Ships { get; set; }

        public List<Unit> Units { get; set; }

        public void GetStats()
        {
            // TODO: develop smart query
            // var shipQuery = Ships.GroupBy(elem => new { elem.ShipType, elem.ShipClass }).Select(x=>x);

            Console.WriteLine($"Stats for {Name}:");
            Console.WriteLine($"");
            Console.WriteLine($"Base Power/Stregth {BasePower}/{BaseStrength}\n");

            Console.WriteLine($"Ships:");
            foreach (IShip ship in Ships)
            {
                Console.WriteLine($"{ship.GetNomenclature()}");
            }

            Console.WriteLine("Units:");
            foreach (IUnit unit in Units)
            {
                Console.WriteLine($"{unit.GetNomenclature()}");
            }

            Console.WriteLine("Items:");
            for (int i = 0; i < Items.Count; i++)
            {
                //not implemented yet
                Console.WriteLine($"None.");
            }
            Console.WriteLine($"Stats Complete, press Enter to continue.");
            Console.WriteLine($"");
            Console.ReadLine();
            Console.Clear();
        }
    }
}
