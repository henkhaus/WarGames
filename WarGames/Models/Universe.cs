using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WarGames.Algorithms;
using WarGames.Events;


namespace WarGames.Models
{
    [Serializable]
    public class Universe : UniverseBuilder
    {
        private Game _game { get; set; }

        public Universe(Game game) : base (game)
        {
            _game = game;
        }

        public void ShowFabric()
        {
            Coordinates originCoords = new Coordinates(0.0, 0.0, 0.0);
            Place origin = new Place("origin", originCoords);

            /*
            foreach (var item in Systems)
            {
                double distToOrigin = Travel.DetermineDistance(origin, item);
                Console.WriteLine($"{item.Name} System at ({item.Coords.X}, {item.Coords.Y}, {item.Coords.Z}) - {distToOrigin} from origin");
            }
            */
            foreach (var plane in Planes)
            {
                plane.RegisterPlaces(this);
            }
            foreach (var plane in Planes)
            {
                Console.Clear();
                Console.WriteLine($"{plane.Z}:");

                plane.PlanePrinter(this);
                Console.ReadLine();
                /*
                foreach (var place in plane.Places)
                {
                    Console.WriteLine($"{place.Name} System at {place.Coords.X}, {place.Coords.Y}, {place.Coords.Z}");
                }
                */
                //Thread.Sleep(1 * 200);
                //plane.PlanePrinter(this);
            }
        }
    }
}
