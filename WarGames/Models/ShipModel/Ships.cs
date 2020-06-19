using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarGames.Models;
using WarGames.Algorithms;
using Newtonsoft.Json;

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

    [Serializable]
    public abstract class Ship : Actor
    {
        public ShipClass shipClass { get; set; }
        public ShipType shipType { get; set; }
        // TODO: use getter to calc new TotalDamage prop
    }

    #region: Classes for specific ships
    [Serializable]
    public class Fighter : Ship, IShip
    {
        public Fighter(ShipClass _shipClass)
        {
            this.shipClass = _shipClass;
            this.shipType = ShipType.Fighter;
        }

        public string GetNomenclature()
        {
            string nomenclature = $"Class {shipClass} {shipType} ";
            return nomenclature;
        }

    }

    [Serializable]
    public class Transport : Ship, IShip
    {
        public Transport(ShipClass _shipClass)
        {
            this.shipClass = _shipClass;
            this.shipType = ShipType.Transport;
            this.Name = GetNomenclature();
        }

        public string GetNomenclature()
        {
            string nomenclature = $"Class {shipClass} {shipType} ";
            return nomenclature;
        }
    }
    #endregion
}