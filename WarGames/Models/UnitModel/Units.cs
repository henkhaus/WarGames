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
        Infantry
    }

    public enum UnitSize
    {
        //TODO: use Navy terms like Fleet, Battle Group, etc. ??
        [Description("Battalion")]
        Battalion,
        [Description("Brigade")]
        Brigade,
        [Description("Corps")]
        Corps
    }

    public abstract class Unit : Actor
    {
        public UnitType UnitType { get; set; }

        public UnitSize UnitSize { get; set; }

        // TODO: use getter to calc new TotalDamage prop
    }

    #region: Classes for specific units
    public class Infantry : Unit, IUnit
    {
        public Infantry(UnitSize _unitSize)
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