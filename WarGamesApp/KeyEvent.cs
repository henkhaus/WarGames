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
            string[] args = Parse(input.ToLower());
            MenuCommand menu = new MenuCommand();
            List<ICommand> commands = menu.GetCommands();
            string output = "";

            // formal args passed here after going through Parse()

            // these are only the multiple arg commands 
            if (args.Length > 1)
            {
                foreach (var command in commands.Where(x => x.MultipleArguments == true).ToList())
                {
                    if (command.Triggers.Contains(args[0]))
                    {
                        output = command.Execute(game, player, args);
                        return output;
                    }
                }
            }

            // these are only the single arg commands 
            foreach (var command in commands.Where(x => x.MultipleArguments == false).ToList())
            {
                if (command.Triggers.Contains(args[0]))
                {
                    output = command.Execute(game, player, null);
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
