using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarGames.Models.ActionModel
{
    public enum ActionType
    {
        Attack, 
        Block, 
        Recon, 
        Move,
        Ambush
    }

    public class Action
    {
        public ActionType ActionType { get; set; }

        // other Action-scope props 

    }


    // TODO: use Battle Actions only in battle  
    #region: Classes for scpecific actions
    public class Attack : Action, IAction
    {
        public Attack() { }

        public Attack(Actor attacker, Item implement)
        {

        }

        public int DamageGiven { get; set; }
        public int DamageReceived { get; set; }
        public bool BattleAction { get; } = true;

        public string GetActionType()
        {
            return this.GetType().Name;
        }
    }

    public class Block : Action, IAction
    {
        public int DamageGiven { get; set; }
        public int DamageReceived { get; set; }
        public bool BattleAction { get; } = true;

        public string GetActionType()
        {
            return this.GetType().Name;
        }
    }

    public class Recon : Action, IAction
    {
        public int DamageGiven { get; set; }
        public int DamageReceived { get; set; }
        public bool BattleAction { get; } = false;

        public string GetActionType()
        {
            return this.GetType().Name;
        }
    }

    public class Move : Action, IAction
    {
        public int DamageGiven { get; set; }
        public int DamageReceived { get; set; }
        public bool BattleAction { get; } = false;

        public string GetActionType()
        {
            return this.GetType().Name;
        }
    }

    public class Ambush : Action, IAction
    {
        public int DamageGiven { get; set; }
        public int DamageReceived { get; set; }
        public bool BattleAction { get; } = false;

        public string GetActionType()
        {
            return this.GetType().Name;
        }
    }

    #endregion  
}
