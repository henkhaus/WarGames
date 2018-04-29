using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarGames.Models;

namespace WarGames.Users
{

    [Serializable]
    public class Player
    {
        // intended for 'outside of game' properties
        // groups of players will create a league to play in a game
        // players will have a character => units, and assets
        // TODO: check uniqueness of player name
        public Player(string PlayerName, string CharacterName)
        {
            Name = PlayerName;

            // all characters start with the same bases
            Character = new Models.Character(CharacterName, 5, 5);
        }

        public string Name { get; set; }

        // this property is set when league is created
        public string League { get; set; }

        public Character Character { get; set; }

        // will be true if it is this player's turn
        public bool Turn { get; set; } = false;

    }
}
