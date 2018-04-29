using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarGames.Art;
using WarGames.Events;
using WarGames.Users;

namespace WarGamesApp
{
    public class MenuCommand : ICommand
    {
        public string Description { get; set; } = "Game Menu";

        public List<string> Triggers { get; set; } = new List<string> { "m", "menu" };

        public string Execute(Game game, Player player)
        {
            AsciiGenerator ascii = new AsciiGenerator();
            ascii.WriteInAscii("WarGames Menu", Color.AntiqueWhite);

            List<ICommand> commands = GetCommands();

            // go through registered commands and output a nice string
            foreach (var command in commands)
            {
                StringBuilder str = new StringBuilder();

                foreach (var trigger in command.Triggers)
                {
                    str.Append(" ");
                    str.Append(trigger);
                }
                str.Append(" | ");
                str.Append(command.Description);
                ascii.Help(str.ToString());
            }

            string x = null;
            return x;
        }

        // get all the other commands to display in the menu
        // new commands must be registered here
        public List<ICommand> GetCommands()
        {
            List<ICommand> commands = new List<ICommand>();

            commands.Add(new HelpCommand());
            commands.Add(new ExitCommand());
            commands.Add(new SitRepCommand());
            commands.Add(new EndTurnCommand());

            return commands;
        }
    }

    public class HelpCommand : ICommand
    {
        public string Description { get; set; } = "Game Help";

        public List<string> Triggers { get; set; } = new List<string> { "h", "help" };

        public string Execute(Game game, Player player)
        {
            AsciiGenerator ascii = new AsciiGenerator();
            ascii.WriteInAscii("Help", Color.AntiqueWhite);

            ascii.Help("Open Menu: m or menu");
            ascii.Help("Exit Game: xx or exit");
            ascii.Help("");
            ascii.Help("");
            ascii.Help("Return to the game by pressing Enter");

            string x = Console.ReadLine();
            return x;
        }
    }

    public class ExitCommand : ICommand
    {
        public string Description { get; set; } = "Exit Game";

        public List<string> Triggers { get; set; } = new List<string> { "xx", "exit" };

        public string Execute(Game game, Player player)
        {
            AsciiGenerator ascii = new AsciiGenerator();

            ascii.Warn("Are you sure you want to exit the game? y/n ");
            string x = Console.ReadLine();

            if (KeyEvent.DetermineInput(x, game, player) == "yes")
            {
                ascii.Warn("Do you want to save the game? y/n ");
                string y = Console.ReadLine();
                if (KeyEvent.DetermineInput(y, game, player) == "yes")
                {
                    ascii.Warn("Saving...");
                    WarGames.Data.IO.SaveLoad.SaveGame(game);
                }
                ascii.Info("Thanks for playing!");
                Environment.Exit(0);
            }
            else
            {
                ascii.Warn("Back to the game!");
                return "no exit";
            }
            return "exited";
        }
    }

    public class EndTurnCommand : ICommand
    {
        public string Description { get; set; } = "End current turn for the player";

        public List<string> Triggers { get; set; } = new List<string> { "done", "next" };

        public string Execute(Game game, Player player)
        {
            AsciiGenerator ascii = new AsciiGenerator();
            ascii.Help("Ending turn for " + player.Character.Name);
            // TODO: implement state tracking in the player class for if its their turn or not, 
            // turn that off here
            player.Turn = false;

            string x = Console.ReadLine();
            return x;
        }
    }

    public class SitRepCommand : ICommand
    {
        public string Description { get; set; } = "Current Situation Report for the player";

        public List<string> Triggers { get; set; } = new List<string> { "s", "sitrep" };

        public string Execute(Game game, Player player)
        {
            AsciiGenerator ascii = new AsciiGenerator();
            ascii.Help("SITREP for "+ player.Character.Name);
            // TODO: for sitrep: add current location, nearest system, inventory, units

            ascii.Help("----------------------");
            ascii.Help("");
            ascii.Help("");
            ascii.Help("");
            ascii.Help("----------------------");
            ascii.Help("Return to the game by pressing Enter");

            string x = Console.ReadLine();
            return x;
        }
    }

}
