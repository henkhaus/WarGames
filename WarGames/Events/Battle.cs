using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarGames.Algorithms;
using WarGames.Events;
using WarGames.Models;

namespace WarGames.Models
{
    public enum BattleStat
    {
        Created,
        Active,
        InActive,
        Complete
    }

    /// <summary>
    /// Battles are created and managed here. Fighting/Dueling happens 
    /// within Engagements. Battles exist within a session.
    /// </summary>
    [Serializable]
    public class Battle : Session
    {
        public Battle()
        {

        }

        public Battle(Actor attacker, Actor defender)
        {

            Attacker = attacker;
            Defender = defender;
            BattleStatus = BattleStat.Created;
            PartiesEngagedSwitch();
        }

        public BattleStat BattleStatus { get; set; }

        public Actor Attacker { get; set; }

        public Actor Defender { get; set; }
    
        private void PartiesEngagedSwitch()
        {
            if(!this.Attacker.Engaged)
                this.Attacker.Engaged = true;
            if(!this.Defender.Engaged)
                this.Defender.Engaged = true;
            if(this.Attacker.Engaged)
                this.Attacker.Engaged = false;
            if(this.Defender.Engaged)
                this.Defender.Engaged = false;
        }

        public void StartBattle()
        {
            double battleDistance = Travel.DetermineDistance(this.Attacker.CurrentLocation, this.Defender.CurrentLocation);

            int minDist = 5;

            if (battleDistance <= minDist)
            {
                BattleStatus = BattleStat.Active;

                // will run on a new thread
                // TODO: loop of engagements


                // Moves and Actions occur
            }
            else
            {
                Console.WriteLine($"Cannot create battle: Parties must be within {minDist} units of distance. " +
                    $"Parties are currently {battleDistance} units apart. Travel {battleDistance - minDist} " +
                    $"units to create a battle.");
            }
        }


        public BattleStat AssessBattleStatus()
        {
            //if(!Move)
            BattleStat battleStatus = BattleStatus;
            //if(Move.Timer < some qualified time)
            // change battlestatus
            return battleStatus;
        }

        public void BattleOn()
        {
            // do battle until actor has no more strength
            do
            {
                //series of engagements go here
            }
            while (this.Attacker.EffectiveStrength >= 0 || this.Defender.EffectiveStrength >= 0);
        }

    }
}
