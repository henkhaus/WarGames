using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarGames.Models;

namespace WarGames.Events
{
    /// <summary>
    /// Smallest unit of combat. Engagements exist with a battle.
    /// </summary>
    public class Engagement : Battle
    {
        // used for engagements within a session



        public bool AssessTurn(Actor attacker, Actor defender)
        {
            int netEffect = attacker.EffectivePower - defender.EffectiveStrength;
            // kill people and things here

            return true;
        }
    }
}
