using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarGamesApp
{
    public static class KeyEvent
    {
        /// <summary>
        /// Acts a jump point for all actions given by the user during a game.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string DetermineInput(string input)
        {
            string output = "";

            // formal args passed here after going through Parse()
            switch (input)
            {
                case "":
                    return output;
                case "w":


                
                   
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
