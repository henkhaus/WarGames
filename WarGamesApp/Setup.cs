using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarGames.Users;
using WarGames.Models.ActionModel;
using WarGames.Models.ShipModel;
using WarGames.Models.UnitModel;
using WarGames.Models;

namespace WarGamesApp
{
    public static class Setup
    {
        /// <summary>
        /// Build players and characters.
        /// </summary>
        /// <returns></returns>
        public static List<Player> BuildPayerRoutine()
        {
            Console.WriteLine("How many players?");

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
                Console.WriteLine("You must enter a number. Please try again.");

                BuildPayerRoutine();
            }

            // build players
            if (players > 1)
            {
                for (int i = 1; i <= players; i++)
                {
                    string playerName = "";
                    string charName = "";

                    Console.WriteLine("Player {0} Setup:", i);

                    // get player name
                    Console.WriteLine("Enter Player {0} Name:", i);
                    playerName = Console.ReadLine();

                    // get character name
                    Console.WriteLine("Enter {0}'s Character Name:", playerName);
                    charName = Console.ReadLine();

                    Player player = new Player(playerName, charName);
                    Console.WriteLine(player.Name + " Created!");

                    SetRandomItems(player, 25);

                    playersList.Add(player);
                }
            }
            if (players <= 1)
            {
                Console.WriteLine("Must have more than one player. Please try again.");

                BuildPayerRoutine();
            }
            return playersList;
        }

        /// <summary>
        /// Create instance of league for a group of players.
        /// </summary>
        /// <param name="players"></param>
        public static void BuildLeagueRoutine(List<Player> players)
        {
            string leagueName = "";

            Console.WriteLine("Please enter a League Name for the players:");

            leagueName = Console.ReadLine();

            League league = new League(leagueName, players);

            Console.WriteLine("{0} League established.", leagueName);
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
            Random rand = new Random();

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
            Random rand = new Random();

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
