using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarGames.Models.ActionModel
{
    public interface IAction
    {
        bool BattleAction { get; }
        string GetActionType();
    }
}
