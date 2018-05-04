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
using WarGames.Data.IO;


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
            ascii.Info("Created by Robert Henkhaus with contributions from friends");
            Console.ReadLine();
            Console.Clear();

            // game setup
            Game game = GameManager.LoadGame();

            List<Player> players = game.LeagueType.Players;


            /*
            Console.WriteLine("Lets see them stats first.");

            foreach (Player player in players)
            {
                player.Character.GetStats();
            }

            Config.WaitandClear();
            */
            ascii.Info("Game started!");
            MenuCommand menu = new MenuCommand();


            // main game routine
            string x = "";
            do
            {
                Console.Clear();
                // go through player turns
                foreach (Player player in players)
                {
                    player.Turn = true;
                    while (player.Turn)
                    {
                        menu.Execute(game, player);
                        ascii.Info(player.Name + "'s move...");
                        x = Console.ReadLine();

                        KeyEvent.DetermineInput(x, game, player);
                        Console.Clear();
                    }

                }
                ascii.Info("computer's turn");


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
