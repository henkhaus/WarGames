using System;
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

        /// <summary>
        /// Creates a new game.
        /// </summary>
        /// <returns></returns>
        public static Game SetupNewGame()
        {
            List<Player> players = GameManager.BuildPlayerRoutine();

            League league = GameManager.BuildLeagueRoutine(players);
            // get difficulty
            Game game = new Game(league);

            game.Difficulty = SetDifficulty();
            // build universe
            game.Universe = new Universe(game);

            // Add all actors to actors list. 
            // this will be used to bulk update Actor data
            foreach (Player player in players)
            {
                SetInitialPlace(player, game);
                Console.WriteLine($"Adding {player.Name}");
                game.Actors = new List<Actor>();
                game.Actors.Add(player.Character);
                game.Actors.AddRange(player.Character.Ships);
                game.Actors.AddRange(player.Character.Units);
            }


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

            // get previously saved games
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

                // league not found or something went odd... just make a new game
                if (game == null)
                {
                    ascii.Info("Game not found. Creating new game.");
                    game = GameManager.SetupNewGame();
                }
            }
            return game;
            
        }

        public static Difficulty SetDifficulty() {
            AsciiGenerator ascii = new AsciiGenerator();

            ascii.Info("Select a difficulty for the Game.");


            int selector = 0;
            foreach (var mode in Enum.GetValues(typeof(Difficulty)))
            {
                ascii.Info($"{selector}. {mode.ToString()}");
                selector += 1;
            }

            string selection = Console.ReadLine();
            int selectionInt;

            // make sure selection is int and one of the enum values 
            if(Int32.TryParse(selection, out selectionInt))
            {
                if(selectionInt <= Enum.GetNames(typeof(Difficulty)).Length)
                {
                    Difficulty selected = (Difficulty)selectionInt;
                    ascii.Info($"{selected.ToString()}");
                    return selected;
                }
                else
                {
                    ascii.Info("Ivalid, going with easy...");
                    return Difficulty.Easy;
                }
            }
            else
            {
                ascii.Info("Ivalid, going with easy...");
                return Difficulty.Easy;
            }
        }

        /// <summary>
        /// Build players and characters.
        /// </summary>
        /// <returns></returns>
        public static List<Player> BuildPlayerRoutine()
        {
            AsciiGenerator ascii = new AsciiGenerator();

            ascii.Info("How many players?");

            string input = Console.ReadLine();

            int players = 0;

            List<Player> playersList = new List<Player>();

            // check if number
            try
            {
                players = Convert.ToInt32(input);
            }
            catch (Exception)
            {
                ascii.Warn("You must enter a number. Please try again.");

                BuildPlayerRoutine();
            }

            // build players
            if (players > 0)
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
            if (players <= 0)
            {
                ascii.Danger("Must have at least one player. Please try again.");

                BuildPlayerRoutine();
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


        public static void SetInitialPlace(Player player, Game game)
        {
            Random rand = new Random(Guid.NewGuid().GetHashCode());
            int rando = rand.Next(game.Universe.Systems.Count());
            player.Character.CurrentLocation = game.Universe.Systems[rando];
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

            while (goalNum <= totalItems)
            {
                int rando = rand.Next(1, totalItems);

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


            for (int i = 0; i < howMany; i++)
            {
               
                IShip ship = shipFactory.CreateShip(WarGames.Models.Utilities.RandomEnumValue<ShipType>(),
                                                    WarGames.Models.Utilities.RandomEnumValue<ShipClass>());
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

            for (int i = 0; i < howMany; i++)
            {

                IUnit unit = unitFactory.CreateUnit(WarGames.Models.Utilities.RandomEnumValue<UnitType>(),
                                                    WarGames.Models.Utilities.RandomEnumValue<UnitSize>());
                //Console.WriteLine(unit.GetNomenclature());
                units.Add((Unit)unit);
            }

            return units;
        }


    }
}
