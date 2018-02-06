﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using WarGames.Users;
using WarGames.Models.ActionModel;
using WarGames.Models.ShipModel;
using WarGames.Models.UnitModel;
using WarGames.Models;
using WarGames.Events;
using WarGames.Art;
using Console = Colorful.Console;
using WarGames.Data.IO;

namespace WarGamesApp
{
    public static class GameManager
    {

        public static string Menu()
        {
            AsciiGenerator ascii = new AsciiGenerator();
            ascii.WriteInAscii("Menu", Color.AntiqueWhite);
            ascii.Help("");
            ascii.Help("Save Game: s or save");
            ascii.Help("Load Game: l or load");
            ascii.Help("Exit Game: xx or exit");


            string x = Console.ReadLine();
            return x;
        }


        public static string Help()
        {
            AsciiGenerator ascii = new AsciiGenerator();
            ascii.WriteInAscii("Help", Color.AntiqueWhite);
            // TODO: make the help dialog

            string x = Console.ReadLine();
            return x;
        }

        /// <summary>
        /// Creates a new game.
        /// </summary>
        /// <returns></returns>
        public static Game SetupNewGame()
        {
            List<Player> players = GameManager.BuildPayerRoutine();
            League league = GameManager.BuildLeagueRoutine(players);
            Game game = new Game(league);

            // save it
            WarGames.Data.IO.SaveLoad.SaveGame(game);

            return game;
        }

        /// <summary>
        /// e
        /// </summary>
        /// <param name="game"></param>
        /// <returns></returns>
        public static Game LoadGame()
        {
            AsciiGenerator ascii = new AsciiGenerator();

            Game game = null;

            List<Game> games = SaveLoad.Load<Game>();
            if (games.Count == 0)
            {
                // set up new game
                game = GameManager.SetupNewGame();
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
                    game = WarGamesApp.GameManager.SetupNewGame();
                }

                // grab the game and use it
                foreach (Game savedGame in games)
                {
                    if (maybeLeague == savedGame.LeagueType.LeagueName.ToLower())
                    {
                        game = savedGame;
                    }
                }

                // league not found or something went odd.. just make a new game
                if (game == null)
                {
                    ascii.Info("Game not found. Creating new game.");
                    game = GameManager.SetupNewGame();
                }
            }
            return game;
            
        }


        public static bool ExitGame(Game game)
        {
            AsciiGenerator ascii = new AsciiGenerator();

            ascii.Warn("Are you sure you want to exit the game? y/n ");
            string x = Console.ReadLine();

            if (KeyEvent.DetermineInput(x, game) == "yes")
            {
                ascii.Warn("Do you want to save the game? y/n ");
                string y = Console.ReadLine();
                if (KeyEvent.DetermineInput(x, game) == "yes")
                {
                    ascii.Warn("Saving...");
                    WarGames.Data.IO.SaveLoad.SaveGame(game);
                }
                Environment.Exit(0);
            }
            else
            {
                ascii.Warn("Back to the game!");
                return false;
            }
            return true;
        }

        /// <summary>
        /// Build players and characters.
        /// </summary>
        /// <returns></returns>
        public static List<Player> BuildPayerRoutine()
        {
            AsciiGenerator ascii = new AsciiGenerator();
            ascii.Info("How many players?");

            string input = Console.ReadLine();

            int players = 0;

            List<Player> playersList = new List<Player>();

            // TODO: handle when user inputs 0 or negative
            // check if number
            try
            {
                players = Convert.ToInt32(input);
            }
            catch (Exception)
            {
                ascii.Warn("You must enter a number. Please try again.");

                BuildPayerRoutine();
            }

            // build players
            if (players > 1)
            {
                for (int i = 1; i <= players; i++)
                {
                    string playerName = "";
                    string charName = "";

                    ascii.Warn($"Player {i} Setup:");
                    
                    // get player name
                    ascii.Info($"Enter Player {i} Name:");
                    playerName = Console.ReadLine();

                    // get character name
                    ascii.Info($"Enter {playerName}'s Character Name:");
                    charName = Console.ReadLine();

                    Player player = new Player(playerName, charName);
                    ascii.Info(player.Name + " Created!");

                    SetRandomItems(player, 25);

                    playersList.Add(player);
                }
            }
            if (players <= 1)
            {
                ascii.Danger("Must have more than one player. Please try again.");

                BuildPayerRoutine();
            }
            return playersList;
        }

        /// <summary>
        /// Create instance of league for a group of players.
        /// </summary>
        /// <param name="players"></param>
        public static League BuildLeagueRoutine(List<Player> players)
        {
            AsciiGenerator ascii = new AsciiGenerator();
            string leagueName = "";

            ascii.Warn("Please enter a League Name for the players:");

            leagueName = Console.ReadLine();

            League league = new League(leagueName, players);

            ascii.Info($"{leagueName} League established.");

            return league;
        }


        /// <summary>
        /// Build random items for a player based on a fuzzy total of items.
        /// </summary>
        /// <param name="player"></param>
        /// <param name="totalItems"></param>
        public static void SetRandomItems(Player player, int totalItems)
        {
            int goalNum = 0;

            Random rand = new Random();

            int rando = rand.Next(1, totalItems);

            while (goalNum <= totalItems)
            {
                Console.WriteLine(rando);
                player.Character.Ships.AddRange(MakeShips(rando));
                player.Character.Units.AddRange(MakeUnits(rando));

                goalNum += rando;
            }
        }


        /// <summary>
        /// Ship seed for a player.
        /// </summary>
        /// <param name="howMany"></param>
        public static List<Ship> MakeShips(int howMany)
        {
            List<Ship> ships = new List<Ship>();

            ShipFactory shipFactory = new ShipFactory();
            Random rand = new Random(Guid.NewGuid().GetHashCode());

            for (int i = 0; i < howMany; i++)
            {
                IShip ship = shipFactory.CreateShip(Utilities.RandomEnumValue<ShipType>(rand), Utilities.RandomEnumValue<ShipClass>(rand));
                //Console.WriteLine(ship.GetNomenclature());
                ships.Add((Ship)ship);
            }

            return ships;
        }


        /// <summary>
        /// Unit seed for a player.
        /// </summary>
        /// <param name="howMany"></param>
        public static List<Unit> MakeUnits(int howMany)
        {
            List<Unit> units = new List<Unit>();

            UnitFactory unitFactory = new UnitFactory();
            Random rand = new Random(Guid.NewGuid().GetHashCode());

            for (int i = 0; i < howMany; i++)
            {
                // TODO: fix issue where this only creates battalions
                IUnit unit = unitFactory.CreateUnit(Utilities.RandomEnumValue<UnitType>(rand), Utilities.RandomEnumValue<UnitSize>(rand));
                //Console.WriteLine(unit.GetNomenclature());
                units.Add((Unit)unit);
            }

            return units;
        }


    }
}