using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarGames.Models;
using WarGames.Models.ActionModel;

namespace WarGames.Events
{
    /// <summary>
    /// Smallest unit of combat. Engagements exist within a battle.
    /// Engagements will assess each party's actions against the target of that action.
    /// We can think of this one set of turns in a battle.
    /// </summary>
    [Serializable]
    public class Engagement : Battle
    {


        public int MyProperty { get; set; }
        
        
        public bool AssessTurn(Actor attacker, Actor defender)
        {
            int netEffect = attacker.EffectivePower - defender.EffectiveStrength;
            // kill people and things here

            return true;
        }
    }
}
