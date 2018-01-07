using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarGames.Models;
using WarGames.Algorithms;

namespace WarGames.Models.ShipModel
{
    public enum ShipType
    {
        Fighter, Transport
    }

    public enum ShipClass
    {
        [Description("A")]
        A,
        [Description("B")]
        B,
        [Description("C")]
        C
    }

    public abstract class Ship : Actor
    {
        public ShipType ShipType { get; set; }

        public ShipClass ShipClass { get; set; }

        // TODO: use getter to calc new TotalDamage prop
    }

    #region: Classes for specific ships
    public class Fighter : Ship, IShip
    {
        public Fighter(ShipClass _shipClass)
        {
            shipClass = _shipClass;
        }

        public ShipClass shipClass { get; set; }

        public string GetNomenclature()
        {
            string nomenclature = $"Class {shipClass.GetDescription()} {this.GetType().Name} ";
            return nomenclature;
        }

    }

    public class Transport : Ship, IShip
    {
        public Transport(ShipClass _shipClass)
        {
            shipClass = _shipClass;
        }

        public ShipClass shipClass { get; set; }

        public string GetNomenclature()
        {
            string nomenclature = $"Class {shipClass.GetDescription()} {this.GetType().Name} ";
            return nomenclature;
        }
    }
    #endregion
}