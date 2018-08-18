using System.Collections.Generic;
using WarGames.Users;
using WarGames.Art;
using WarGames.Events;
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

            // startup art
            AsciiGenerator ascii = new AsciiGenerator();
            ascii.WriteInAscii("WarGames", Color.OrangeRed);
            Animation.Animate();
            ascii.Info("Created by Robert Henkhaus with contributions from friends");
            Console.ReadLine();
            Console.Clear();

            // game setup
            Game game = GameManager.LoadGame();

            List<Player> players = game.LeagueType.Players;

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

            Console.ReadLine(); 
        }
    }
}
