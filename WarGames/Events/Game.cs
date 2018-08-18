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

        /// <summary>
        /// Counter for turns in the game. Used to 
        /// process travel times for players
        /// </summary>
        public int TurnCount { get; set; }

        public League LeagueType { get; set; }

        public List<Session> Sessions { get; set; }

        public Difficulty Difficulty { get; set; }

        public Universe Universe { get; set; }

    }
}
