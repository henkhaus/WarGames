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

        public string GetStats()
        {
            AsciiGenerator ascii = new AsciiGenerator();
            // TODo: allow user to query and see further stats
            StringBuilder sb = new StringBuilder();
            sb.Append($"Base Power/Stregth {BasePower}/{BaseStrength}\n");

            var shipQuery = Ships.GroupBy(x => x.shipType);

            sb.Append("Ships\n");
            foreach (var ship in shipQuery)
            {
                sb.Append("--\n");
                sb.Append($"{ship.Count()} {ship.Key.ToString()}s\n");

                var shipClasses = ship.GroupBy(x => x.shipClass);
                foreach (var classType in shipClasses)
                {
                    sb.Append($"- {classType.Count()} {classType.Key.ToString()}\n");
                }

            }

            var unitQuery = Units.GroupBy(x => x.unitType);
            sb.Append("\n");
            sb.Append("Units\n");
            foreach (var unit in unitQuery)
            {
                sb.Append("--\n");
                sb.Append($"{unit.Count()} {unit.Key.ToString()}\n");

                var unitSizes = unit.GroupBy(x => x.unitSize);
                foreach (var sizeType in unitSizes)
                {
                    sb.Append($"- {sizeType.Count()} {sizeType.Key.ToString()}\n");
                }

            }

            string package = sb.ToString();

            return package;
        }
    }
}
