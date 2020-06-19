using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarGames.Models.ShipModel;
using WarGames.Models.UnitModel;
using WarGames.Models.ActionModel;
using WarGames.Art;
using WarGames.Algorithms;
using Console = Colorful.Console;
using WarGames.Events;

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

        public Race Race { get; set; }

        public Dictionary<string, Item> Items { get; set; }

        public List<Ship> Ships { get; set; }

        public List<Unit> Units { get; set; }

        public string GetStats(Game game)
        {
            AsciiGenerator ascii = new AsciiGenerator();
            // TODO: allow user to query and see further stats
            StringBuilder sb = new StringBuilder();
            sb.Append("----\n");
            sb.Append($"{this.Name} (race: {this.Race})\n");
            sb.Append($"Base Power/Stregth {BasePower}/{BaseStrength}\n");
            sb.Append($"Effective Power/Stregth {EffectivePower}/{EffectiveStrength}\n");

            sb.Append($"Current Location: {this.CurrentLocation.Name} - ({this.CurrentLocation.Coords.X}, {this.CurrentLocation.Coords.Y}, {this.CurrentLocation.Coords.Z})\n");
            if (this.Destination != null)
            {
                sb.Append($"Destination: {this.Destination.Name} - ({this.Destination.Coords.X}, {this.Destination.Coords.Y}, {this.Destination.Coords.Z}) which is {this.DistanceToDestination} units away, will arrive in {this.TurnsToDestination} turns\n");
            }
            else
            {
                sb.Append($"Not currently travelling.\n");
            }
            sb.Append("\n");

            sb.Append("Nearest systems:\n");
            List<PlaceDistance> pds = Travel.GetClosestSystems(this, game.Universe, 5);
            foreach (var pd in pds)
            {
                sb.Append($"{pd.place.Name} - ({pd.place.Coords.X}, {pd.place.Coords.Y}, {pd.place.Coords.Z}) -\t distance: {pd.distanceFromPlayer}\n");
            }
            sb.Append("----\n");
            sb.Append("Inventory:\n");
            sb.Append("\n");
            var shipQuery = Ships.OrderBy(y => y.shipType).GroupBy(x => x.shipType);
        
            sb.Append("Ships\n");
            foreach (var ship in shipQuery)
            {
                sb.Append("--\n");
                sb.Append($"{ship.Count()} {ship.Key.ToString()}s\n");

                var shipClasses = ship.OrderBy(y => y.shipClass).GroupBy(x => x.shipClass);
                foreach (var classType in shipClasses)
                {
                    sb.Append($"- {classType.Count()} {classType.Key.ToString()}\n");
                }

            }

            var unitQuery = Units.OrderBy(y => y.unitType).GroupBy(x => x.unitType);
            sb.Append("\n");
            sb.Append("Units\n");
            foreach (var unit in unitQuery)
            {
                sb.Append("--\n");
                sb.Append($"{unit.Count()} {unit.Key.ToString()}\n");

                var unitSizes = unit.OrderBy(y => y.unitSize).GroupBy(x => x.unitSize);
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
