using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarGames.Models;
using WarGames.Algorithms;
using WarGames.Models.ShipModel;

namespace WarGamesApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Character robert = new Character("Robert", 5, 5);
            robert.Race = Race.Bob;

            // create places
            Place earth = new Place("earth", 0, 0, 0);
            Place planetX = new Place("planet x", 5, 5, 5);

            // ships
            ShipFactory shipFactory = new ShipFactory();

            IShip fighter = shipFactory.CreateShip(ShipType.Fighter, ShipClass.B);
            Console.WriteLine(fighter.GetNomenclature());
            Fighter theFighter = (Fighter)fighter;
            
            /*
            ship.shipLocation = planetX;

            robert.ships.Add(ship);
            robert.characterLocation = earth;
            double dist = Travel.DetermineDistance(robert.characterLocation, ship.shipLocation);

            ship.SetDestination(robert.characterLocation);
            */
            // example

            Console.ReadLine();
            
        }
    }
}
