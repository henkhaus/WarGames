using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarGames.Models
{
    public enum UnitType
    {
        Recon, 
        Infantry
    }

    public class Unit
    {
        public Unit(UnitType _unitType, int _numTroops)
        {
            unitType = _unitType;
            numTroops = _numTroops;
        }

        public UnitType unitType { get; set; }

        // default to 0
        public int numTroops { get; set; } = 0;


    }
}
