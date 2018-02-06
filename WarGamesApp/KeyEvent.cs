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

                case "menu":
                case "m":
                    //menu
                    output = GameManager.Menu();
                    output = DetermineInput(output, game);
                    return output;

                case "save":
                case "s":
                    output = SaveLoad.SaveGame(game).ToString();
                    return output;

                case "load":
                case "l":
                    // need to figure out best way to pass new game obj back to program.cs
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
        public static List<string> Parse(string input)
        {
            // arg format: character/player, actor, adds, action
            // TODO: implements args parsing
            List<string> output = new List<string>();

            


            return output;
        }
    }
}
