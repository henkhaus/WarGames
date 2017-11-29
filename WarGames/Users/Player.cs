using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarGames.Models;

namespace WarGames.Users
{
    public class Player
    {
        // intended for 'outside of game' properties
        // groups of players will create a league to play in a game
        // players will have a character, units, and assets
        

        // this property is set when league is created
        public string League { get; set; }

        public Character Character { get; set; }



    }
}
