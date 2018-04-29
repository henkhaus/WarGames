using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarGames.Events;
using WarGames.Users;

namespace WarGamesApp
{
    public interface ICommand
    {
        // description of the command 
        string Description { get; set; }

        // keys needed to tigger execution (m, menu)
        List<string> Triggers { get; set; }

        // execution of the command
        string Execute(Game game, Player player);
    }
}
