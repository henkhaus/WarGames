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
using WarGames.Art;
using WarGames.Events;
using WarGames.Data;
using System.Drawing;
using Console = Colorful.Console;


namespace WarGamesApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // game startup
            Console.SetWindowSize(150, 40);
            // set up art
            AsciiGenerator ascii = new AsciiGenerator();
            ascii.WriteInAscii("WarGames", Color.OrangeRed);
            Animation.Animate();
            ascii.Info("Developed by Robert and Friends");
            Console.ReadLine();
            Console.Clear();

            //ascii.ColorTest();
            // game setup
            // TODO: check for previous sessions and ask the user if they want to load it

            Game game = null;

            List<Game> games = WarGames.Data.IO.Utilities.Load<Game>();
            if(games.Count == 0)
            {
                // set up new game
                game = Setup.SetupNewGame();
            }
            else
            {
                ascii.Warn("Available Games: ");
                // present games to load or new game
                foreach (Game savedGame in games)
                {
                    ascii.Info(savedGame.LeagueType.LeagueName);
                }

                ascii.Info("Type a league name in from above to load the game or type 'new' to create a new game.");

                string maybeLeague = Console.ReadLine().ToLower();

                // new game anyway
                if (maybeLeague == "new")
                {
                    game = Setup.SetupNewGame();
                }

                // grab the game and use it
                foreach (Game savedGame in games)
                {
                    if(maybeLeague == savedGame.LeagueType.LeagueName.ToLower())
                    {
                        game = savedGame;
                    } 
                }

                // league not found or something went odd.. just make a new game
                if (game == null)
                {
                    ascii.Info("Game not found. Creating new game.");
                    game = Setup.SetupNewGame();
                }
            }


            Console.WriteLine("Lets see them stats first.");

            List<Player> players = game.LeagueType.Players;
            foreach (Player player in players)
            {
                player.Character.GetStats();
            }

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


            /*
            // create characters
            Character robert = new Character("Robert", 5, 5);
            robert.Race = Race.Bob;

            Character amanda = new Character("Amanda", 5, 5);
            amanda.Race = Race.Cyborg;

            // create places
            Place earth = new Place("earth", 0, 0, 0);
            Place planetX = new Place("planet x", 5, 5, 5);

            robert.CharacterLocation = earth;
            amanda.CharacterLocation = planetX;


            // ships
            ShipFactory shipFactory = new ShipFactory();

            IShip fighter = shipFactory.CreateShip(ShipType.Fighter, ShipClass.B);
            Console.WriteLine(fighter.GetNomenclature());            
            Fighter aFighter = (Fighter)fighter;
            aFighter.Speed = 7;
            aFighter.ShipLocation = earth;
            
            //robert: take ship to planetX 
            robert.Ships.Add(aFighter);
            Fighter robertsFighter = (Fighter)robert.Ships[0];
            robertsFighter.SetDestination(planetX);

            double DaystoDest = Convert.ToDouble(robertsFighter.TimeToDestination.TotalDays);
            Console.WriteLine($"dist to {robertsFighter.ShipDestination.Name}-{robertsFighter.DistanceToDestination} days-{DaystoDest} est.arrival-{robertsFighter.Arrival}");

            Console.WriteLine("travelling");
            // traveltime
            int travelTime = Convert.ToInt32(DaystoDest) * 10000;
            Thread.Sleep(travelTime);

            robert.CharacterLocation = planetX;


            
            Battle battle;
            if(robert.CharacterLocation == amanda.CharacterLocation)
            {
                battle = new Battle(robert, amanda);
                Console.WriteLine(battle.BattleStatus);

            }
            */
            Console.ReadLine();
            
        }
    }
}
