using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarGames.Events;
using WarGames.Data.IO;

namespace WarGamesApp
{
    /// <summary>
    /// Key Event engine. Parses user input into args.
    /// </summary>
    public static class KeyEvent
    {
        /// <summary>
        /// Acts a jump point for all actions given by the user during a game.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string DetermineInput(string input, Game game)
        {
            string[] args = Parse(input);

            foreach (string arg in args)
            {

            }

            string output = "";

            // formal args passed here after going through Parse()
            switch (input.ToLower())
            {
                case "":
                    return output;

                case "yes":
                case "y":
                    output = "yes";
                    return output;

                case "no":
                case "n":
                    output = "no";
                    return output;

                case "help":
                case "h":
                    GameManager.Help();
                    return output;

                case "menu":
                case "m":
                    //menu
                    output = GameManager.Menu();
                    output = DetermineInput(output, game);
                    return output;

                case "save":
                case "s":
                    SaveLoad.SaveGame(game);
                    return output;

                case "load":
                case "l":
                    // TODO: need to figure out best way to pass new game obj back to program.cs
                    // we want to switch games
                    //output = GameManager.LoadGame();
                    return output;

                case "exit":
                case "xx":
                    GameManager.ExitGame(game);
                    return output;



                
                   
                default:
                    break;
            }

            return output;
        }


        /// <summary>
        /// Cleans raw input from user into args the game can decifer.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string[] Parse(string input)
        {
            string[] output = input.Split(' ');

            // add other cleaning here if needed

            return output;
        }
    }
}
