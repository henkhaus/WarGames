using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarGames.Events;
using WarGames.Data.IO;
using WarGames.Users;

namespace WarGamesApp
{
    /// <summary>
    /// Key Event engine. Parses user input into args.
    /// </summary>
    public static class KeyEvent
    {
        /// <summary>
        /// Acts a jump point for all commands given by the user during a game.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string DetermineInput(string input, Game game, Player player)
        {
            string[] args = Parse(input);

            foreach (string arg in args)
            {

            }

            string output = "";

            MenuCommand menu = new MenuCommand();
            List<ICommand> commands = menu.GetCommands();

            // formal args passed here after going through Parse()
            foreach (var command in commands)
            {
                if (command.Triggers.Contains(input.ToLower()))
                {
                    output = command.Execute(game, player);
                    return output;
                }
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
