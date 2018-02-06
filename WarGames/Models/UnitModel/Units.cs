using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarGames.Models;
using WarGames.Algorithms;

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
        public UnitType UnitType { get; set; }

        public UnitSize UnitSize { get; set; }

        // TODO: use getter to calc new TotalDamage prop
    }

    #region: Classes for specific units
    [Serializable]
    public class Strike : Unit, IUnit
    {
        public Strike(UnitSize _unitSize)
        {
            unitSize = _unitSize;
        }

        public UnitSize unitSize { get; set; }

        public string GetNomenclature()
        {
            string nomenclature = $"{this.GetType().Name} {UnitSize.GetDescription()}";
            return nomenclature;
        }

    }

    [Serializable]
    public class Recon : Unit, IUnit
    {
        public Recon(UnitSize _unitSize)
        {
            unitSize = _unitSize;
        }

        public UnitSize unitSize { get; set; }

        public string GetNomenclature()
        {
            string nomenclature = $"{this.GetType().Name} {UnitSize.GetDescription()}";
            return nomenclature;
        }

    }
    #endregion
}