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
        public int DamageGiven { get; set; }
        public int DamageReceived { get; set; }

        public ActionType ActionType { get; set; }

        // other Action-scope props 

    }

    #region: Classes for scpecific actions
    public class Attack : Action, IAction
    {
        public string GetActionType()
        {
            return "hi";
        }
    }

    public class Block : Action, IAction
    {
        public string GetActionType()
        {
            return "hi";
        }
    }

    public class Recon : Action, IAction
    {
        public string GetActionType()
        {
            return "hi";
        }
    }

    public class Move : Action, IAction
    {
        public string GetActionType()
        {
            return "hi";
        }
    }

    public class Ambush : Action, IAction
    {
        public string GetActionType()
        {
            return "hi";
        }
    }

    #endregion  
}
