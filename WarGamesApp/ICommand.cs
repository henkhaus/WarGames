using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarGames.Events;
using WarGames.Users;

namespace WarGamesApp
{
    /// <summary>
    /// All user commands implement this interface
    /// </summary>
    public interface ICommand
    {
        // description of the command 
        string Description { get; set; }

        // keys needed to tigger execution (m, menu)
        List<string> Triggers { get; set; }

        // does this command take multiple args (first arg is trigger for command) 
        bool MultipleArguments { get; set; }

        // execution of the command
        string Execute(Game game, Player player, string[] args);
    }
}
