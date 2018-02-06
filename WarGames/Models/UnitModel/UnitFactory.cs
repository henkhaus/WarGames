using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarGames.Models;

namespace WarGames.Models.UnitModel
{
    public class UnitFactory
    {
        public IUnit CreateUnit(UnitType unitType, UnitSize unitSize)
        {
            switch (unitType)
            {
                case UnitType.Strike:
                    return new Strike(unitSize);

                case UnitType.Recon:
                    return new Recon(unitSize);

                default:
                    throw new NotSupportedException();
            }
        }
    }
}
