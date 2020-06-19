using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarGames.Models;
using WarGames.Algorithms;
using System.Runtime.CompilerServices;

namespace WarGames.Models.UnitModel
{
    public enum UnitType
    {
        Recon,
        Strike
    }

    public enum UnitSize
    {
        [Description("Element")]
        Element,
        [Description("Squadron")]
        Squadron,
        [Description("Battle Group")]
        BattleGroup,
        [Description("Fleet")]
        Fleet
    }


    [Serializable]
    public abstract class Unit : Actor
    {
        public UnitSize unitSize { get; set; }
        public UnitType unitType { get; set; }
        // TODO: use getter to calc new TotalDamage prop
    }

    #region: Classes for specific units
    [Serializable]
    public class Strike : Unit, IUnit
    {
        public Strike(UnitSize _unitSize)
        {
            this.unitSize = _unitSize;
            this.unitType = UnitType.Strike;
            this.Name = GetNomenclature();
        }
        

        public string GetNomenclature()
        {
            string nomenclature = $"{unitType} {unitSize}";
            return nomenclature;
        }

    }

    [Serializable]
    public class Recon : Unit, IUnit
    {
        public Recon(UnitSize _unitSize)
        {
            this.unitSize = _unitSize;
            this.unitType = UnitType.Recon;
        }


        public string GetNomenclature()
        {
            string nomenclature = $"{unitType} {unitSize}";
            return nomenclature;
        }

    }
    #endregion
}