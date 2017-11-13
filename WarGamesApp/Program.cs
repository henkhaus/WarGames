using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarGames.Models;
using WarGames.Algorithms;

namespace WarGamesApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Character robert = new Character("Robert", 5, 5);
            robert.race = Race.Bob;

            // create places
            Place earth = new Place("earth", 0, 0, 0);
            Place planetX = new Place("planet x", 5, 5, 5);

            // ships
            Ship ship = new Ship(ShipType.Cargo);
            ship.shipLocation = planetX;

            robert.ships.Add(ship);
            robert.characterLocation = earth;
            double dist = Travel.DetermineDistance(robert.characterLocation, ship.shipLocation);

            ship.SetDestination(robert.characterLocation);

            // example
            Console.WriteLine("Robert is a " + robert.race);
            Console.WriteLine("he is on " + robert.characterLocation.name);

            Console.WriteLine("distance to ship "+dist);
            Console.WriteLine("ship is leaving from " + ship.shipOrigination.name);

            // example

            Item axe = new Item("Axe", 5, 3);
            robert.items.Add(axe.name, axe);
            robert.Use(robert.items["Axe"]);
            Console.WriteLine("roberts power is " + robert.basePower);



            Console.ReadLine();
            
        }
    }
}
