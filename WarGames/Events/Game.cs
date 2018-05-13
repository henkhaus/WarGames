using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarGames.Models;
using WarGames.Users;

namespace WarGames.Events
{
    public enum Difficulty
    {
        Easy = 0,
        Medium = 1,
        Hard = 2
    }

    [Serializable]
    public class Game
    {
        // games start
        public Game(League league)
        {
            LeagueType = league;   
        }

        public League LeagueType { get; set; }

        public List<Session> Sessions { get; set; }

        public Difficulty Difficulty { get; set; }

        public Universe universe { get; set; }

    }
}
