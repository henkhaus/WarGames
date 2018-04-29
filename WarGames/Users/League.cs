using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarGames.Users
{

    [Serializable]
    public class League
    {
        // TODO: check uniqueness of league name

        // groups of players create a league
        public League(string leagueName, List<Player> players)
        {
            LeagueName = leagueName;
            Players = players;
            AssignLeagueToPlayer();
        }

        public string LeagueName { get; set; }

        public List<Player> Players { get; set; }

        private void AssignLeagueToPlayer()
        {
            foreach (Player player in Players)
            {
                player.League = this.LeagueName;
            }
        }

    }
}
