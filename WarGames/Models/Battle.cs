using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarGames.Models
{
    public enum BattleStat
    {
        Created,
        Active,
        InActive,
        Complete
    }

    public class Battle
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
            this.Attacker.
            BattleStatus = BattleStat.Active;

            // will run on a new thread
            Task.Run(() => AssessBattleStatus());

            // Moves and Actions occur


            

        }

        public BattleStat AssessBattleStatus()
        {
            //if(!Move)
            BattleStat battleStatus = BattleStatus;
            //if(Move.Timer < some qualified time)
            // change battlestatus
            return battleStatus;
        }



    }
}
