using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarGames.Users;

namespace WarGames.Events
{
    public class Game
    {
        // games start here

        // TODO: create game - starts with a league of players/users
        public Game(League league)
        {
            LeagueType = league;   
        }

        public League LeagueType { get; set; }

        public List<Session> Sessions { get; set; }




    }
}
