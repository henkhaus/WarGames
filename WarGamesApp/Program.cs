using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarGames.Models;
using WarGames.Algorithms;
using WarGames;
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

            theFighter.Speed = 7;
            theFighter.ShipLocation = earth;
            theFighter.SetDestination(planetX);
            double DaystoDest = Convert.ToDouble(theFighter.TimeToDestination.TotalDays);
            Console.WriteLine($"dist to {theFighter.ShipDestination.Name}-{theFighter.DistanceToDestination} days-{DaystoDest} est.arrival-{theFighter.Arrival}");
                        

            Console.ReadLine();
            
        }
    }
}
