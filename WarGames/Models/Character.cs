using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarGames.Models.ShipModel;
using WarGames.Models.UnitModel;
using WarGames.Models.ActionModel;
using WarGames.Art;
using Console = Colorful.Console;

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
            AsciiGenerator ascii = new AsciiGenerator();
            // TODO: make this into a command

            // TODO: develop smart query to summarize stats
            // var shipQuery = Ships.GroupBy(elem => new { elem.ShipType, elem.ShipClass }).Select(x=>x);

            ascii.Help($"Stats for {Name}:");
            ascii.Help($"");
            ascii.Help($"Base Power/Stregth {BasePower}/{BaseStrength}\n");

            ascii.Help($"Ships:");
            foreach (IShip ship in Ships)
            {
                ascii.Help($"{ship.GetNomenclature()}");
            }

            ascii.Help("Units:");
            foreach (IUnit unit in Units)
            {
                ascii.Help($"{unit.GetNomenclature()}");
            }

            ascii.Help("Items:");
            for (int i = 0; i < Items.Count; i++)
            {
                //not implemented yet
                ascii.Help($"None.");
            }
            ascii.Help($"Stats Complete, press Enter to continue.");
            Console.ReadLine();
            Console.Clear();
        }
    }
}
