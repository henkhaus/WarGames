using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarGames.Models;

namespace WarGames.Models.ActionModel
{
    public class ActionFactory
    {
        public IAction CreateAction(ActionType actionType)
        {
            switch (actionType)
            {
                case ActionType.Ambush:
                    return new Ambush();
                case ActionType.Attack:
                    return new Attack();
                case ActionType.Block:
                    return new Block();
                case ActionType.Move:
                    return new Move();
                case ActionType.Recon:
                    return new Recon();

                default:
                    throw new NotSupportedException();
            }
        }
    }
}
