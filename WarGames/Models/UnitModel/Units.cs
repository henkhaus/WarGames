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

        // travel props and calculations
        [Description("Units per Earth Day")]
        public double Speed { get; set; }

        public Place UnitLocation { get; set; }

        public Place UnitDestination { get; set; }

        public Place UnitOrigination { get; set; }

        public double DistanceToDestination { get; set; }

        public TimeSpan TimeToDestination { get; set; }

        public DateTime Arrival { get; set; }

        public bool SetDestination(Place destination)
        {
            this.UnitDestination = destination;
            this.UnitOrigination = this.UnitLocation;

            // determine distance to destination
            try
            {
                DistanceToDestination = Travel.DetermineDistance(this.UnitOrigination, this.UnitDestination);
                TimeToDestination = TimeSpan.FromDays(DistanceToDestination / Speed);
                Arrival = DateTime.Now + TimeToDestination;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Could not determine distance or time to destination. {e.Message}");
            }

            return true;
        }

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