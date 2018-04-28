using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarGames.Art;
using WarGames.Events;

namespace WarGamesApp
{
    public class MenuCommand : ICommand
    {
        public string Description { get; set; } = "Game Menu";

        public List<string> Triggers { get; set; } = new List<string> { "m", "menu" };

        public string Execute(Game game)
        {

            AsciiGenerator ascii = new AsciiGenerator();
            ascii.WriteInAscii("Menu", Color.AntiqueWhite);

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

            ascii.Help("Return to the game by pressing Enter");

            string x = Console.ReadLine();
            return x;
        }

        // get all the other commands to display in the menu
        // new commands must be registered here
        public List<ICommand> GetCommands()
        {
            List<ICommand> commands = new List<ICommand>();

            commands.Add(new HelpCommand());
            commands.Add(new ExitCommand());
            commands.Add(new InventoryCommand());

            return commands;
        }
    }

    public class HelpCommand : ICommand
    {
        public string Description { get; set; } = "Game Help";

        public List<string> Triggers { get; set; } = new List<string> { "h", "help" };

        public string Execute(Game game)
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

        public string Execute(Game game)
        {
            AsciiGenerator ascii = new AsciiGenerator();

            ascii.Warn("Are you sure you want to exit the game? y/n ");
            string x = Console.ReadLine();

            if (KeyEvent.DetermineInput(x, game) == "yes")
            {
                ascii.Warn("Do you want to save the game? y/n ");
                string y = Console.ReadLine();
                if (KeyEvent.DetermineInput(y, game) == "yes")
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

    public class InventoryCommand : ICommand
    {
        public string Description { get; set; } = "See Current Inventory for player";

        public List<string> Triggers { get; set; } = new List<string> { "i", "inventory" };

        public string Execute(Game game)
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

}
