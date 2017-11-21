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
            UnitType = _unitType;
            NumTroops = _numTroops;
        }

        public UnitType UnitType { get; set; }

        // default to 0
        public int NumTroops { get; set; } = 0;


    }
}
