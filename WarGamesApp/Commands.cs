using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarGames.Algorithms;
using WarGames.Art;
using WarGames.Events;
using WarGames.Models;
using WarGames.Users;

namespace WarGamesApp
{
    /// <summary>
    /// Basic menu command
    /// </summary>
    public class MenuCommand : ICommand
    {
        public string Description { get; set; } = "Game Menu";

        public List<string> Triggers { get; set; } = new List<string> { "m", "menu" };

        public bool MultipleArguments { get; set; } = false;

        public string Execute(Game game, Player player, string[] args = null)
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

            commands.Add(new ShowUniverseCommand());
            commands.Add(new SitRepCommand());
            commands.Add(new SetDestinationCommand());
            commands.Add(new EndTurnCommand());

            commands.Add(new HelpCommand());
            commands.Add(new ExitCommand());

            return commands;
        }
    }

    /// <summary>
    /// Gives the user help options
    /// </summary>
    public class HelpCommand : ICommand
    {
        public string Description { get; set; } = "Game Help";

        public List<string> Triggers { get; set; } = new List<string> { "h", "help" };

        public bool MultipleArguments { get; set; } = false;

        public string Execute(Game game, Player player, string[] args = null)
        {
            AsciiGenerator ascii = new AsciiGenerator();
            ascii.WriteInAscii("Help", Color.AntiqueWhite);

            ascii.Help("Open Menu: m or menu");
            ascii.Help("Exit Game: xx or exit");
            ascii.Help("");
            ascii.Help("");
            ascii.Help("Return to menu by pressing Enter.");

            string x = Console.ReadLine();
            return x;
        }
    }

    /// <summary>
    /// Exits Game
    /// </summary>
    public class ExitCommand : ICommand
    {
        public string Description { get; set; } = "Exit Game";

        public List<string> Triggers { get; set; } = new List<string> { "xx", "exit" };

        public bool MultipleArguments { get; set; } = false;

        public string Execute(Game game, Player player, string[] args = null)
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

    /// <summary>
    /// Manages Player Turn state
    /// </summary>
    public class EndTurnCommand : ICommand
    {
        public string Description { get; set; } = "End current turn for the player";

        public List<string> Triggers { get; set; } = new List<string> { "done", "next", "end turn" };

        public bool MultipleArguments { get; set; } = false;

        public string Execute(Game game, Player player, string[] args = null)
        {
            AsciiGenerator ascii = new AsciiGenerator();
            ascii.Help("Ending turn for " + player.Character.Name);

            player.Turn = false;

            game.TurnCount += 1;

            string x = Console.ReadLine();
            return x;
        }
    }

    /// <summary>
    /// Gives the player a situation report for the current turn
    /// </summary>
    public class SitRepCommand : ICommand
    {
        public string Description { get; set; } = "Current Situation Report for the player";

        public List<string> Triggers { get; set; } = new List<string> { "s", "sitrep" };

        public bool MultipleArguments { get; set; } = false;

        public string Execute(Game game, Player player, string[] args = null)
        {
            string sitrep = player.Character.GetStats(game);
            AsciiGenerator ascii = new AsciiGenerator();
            ascii.Help("SITREP for "+ player.Character.Name);
            // TODO: for sitrep: add current location, nearest system, inventory, units
            ascii.Help("----------------------");
            ascii.Help($"{sitrep}");
            ascii.Help("");
            ascii.Help("");
            ascii.Help("----------------------");
            ascii.Help("Return to menu by pressing Enter.");

            string x = Console.ReadLine();
            return x;
        }
    }

    /// <summary>
    /// Gives the player a map of the universe
    /// </summary>
    public class ShowUniverseCommand : ICommand
    {
        public string Description { get; set; } = "Show the universe";

        public List<string> Triggers { get; set; } = new List<string> { "u", "universe" };

        public bool MultipleArguments { get; set; } = false;

        public string Execute(Game game, Player player, string[] args = null)
        {

            game.Universe.ShowFabric();
            AsciiGenerator ascii = new AsciiGenerator();

            ascii.Help("Return to menu by pressing Enter.");

            string x = Console.ReadLine();
            return x;
        }
    }


    public class SetDestinationCommand : ICommand
    {
        public string Description { get; set; } = "Set Destination (example: 't Earth')";

        public List<string> Triggers { get; set; } = new List<string> { "t", "travel", "destination" };

        public bool MultipleArguments { get; set; } = true;

        public string Execute(Game game, Player player, string[] args = null)
        {
            AsciiGenerator ascii = new AsciiGenerator();

            if (args != null && args.Length == 2)
            {
                Place destination = Travel.GetPlaceByName(game.Universe, args[1]);

                if (destination != null)
                {
                    player.Character.SetDestination(destination);

                    ascii.Help("Set destination to " + args[1] + ". Confirmed!");
                    ascii.Help("Time to destination: " + player.Character.TurnsToDestination);
                }
                else
                {
                    ascii.Help("The destination "+ args[1] +" does not exist. Please try again.");
                }

            }

            ascii.Help("Return to menu by pressing Enter.");

            string x = Console.ReadLine();
            return x;
        }
    }

}
