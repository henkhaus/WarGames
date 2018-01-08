using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarGames.Models;
using WarGames.Algorithms;
using WarGames.Models.ActionModel;
using WarGames.Models.ShipModel;
using WarGames.Models.UnitModel;
using WarGames.Users;
using System.Threading;
using WarGames.Data;

namespace WarGamesApp
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            // game startup
            Console.WriteLine("Welcome to WarGames! (v.0.1.0.0)");
            Console.WriteLine("################################");
            Thread.Sleep(1 * 1000);
            Console.WriteLine("Developed by Robert and Friends");
            Config.WaitandClear();

            // TODO: check for previous sessions and ask the user if they want to load it

            // game setup
            // create players routine
            List<Player> players = Setup.BuildPayerRoutine();
            Config.WaitandClear();

            foreach (Player player in players)
            {
                player.Character.GetStats();
            }

            // create league routine
            Setup.BuildLeagueRoutine(players);
            Config.WaitandClear();
            

            // main game routine
            string x;
            do
            {
                x = Console.ReadLine();
                KeyEvent.DetermineInput(x);

                //Console.WriteLine(x + " was pressed");
            }
            while (x.ToUpper() != "XX");

            */
            
            // create characters
            Character robert = new Character("Robert", 5, 5);
            robert.Race = Race.Bob;
            Character amanda = new Character("Amanda", 5, 5);
            amanda.Race = Race.Cyborg;

            List<Character> chars = new List<Character>();
            chars.Add(robert);
            //chars.Add(amanda);
            WarGames.Data.IO.Utilities.Save(chars);

            List<Character> loadedCharacters = WarGames.Data.IO.Utilities.Load<Character>();

            Console.WriteLine(loadedCharacters.Count);


            // create places
            Place earth = new Place("earth", 0, 0, 0);
            Place planetX = new Place("planet x", 9, 5, 15);

            robert.CurrentLocation = earth;
            amanda.CurrentLocation = planetX;


            // ships
            ShipFactory shipFactory = new ShipFactory();

            IShip fighter = shipFactory.CreateShip(ShipType.Fighter, ShipClass.B);
            Console.WriteLine(fighter.GetNomenclature());            
            Fighter aFighter = (Fighter)fighter;
            aFighter.Speed = 7;
            aFighter.CurrentLocation = earth;
            
            //robert: take ship to planetX 
            robert.Ships.Add(aFighter);
            Fighter robertsFighter = (Fighter)robert.Ships[0];
            robertsFighter.SetDestination(planetX);

            double DaystoDest = Convert.ToDouble(robertsFighter.TimeToDestination.TotalDays);
            Console.WriteLine($"dist to {robertsFighter.Destination.Name}-{robertsFighter.DistanceToDestination} days-{DaystoDest} est.arrival-{robertsFighter.Arrival}");

            Console.WriteLine("travelling");
            // traveltime
            int travelTime = Convert.ToInt32(DaystoDest) * 10000;
            Thread.Sleep(travelTime);

            robert.CurrentLocation = planetX;


            
            Battle battle;
            if(robert.CurrentLocation == amanda.CurrentLocation)
            {
                battle = new Battle(robert, amanda);
                Console.WriteLine(battle.BattleStatus);

            }
            
            Console.ReadLine();
            
        }
    }
}
