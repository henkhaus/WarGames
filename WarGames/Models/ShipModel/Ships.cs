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

        // travel props and calculations
        [Description("Units per Earth Day")]
        public double Speed { get; set; }

        public Place ShipLocation { get; set; }

        public Place ShipDestination { get; set; }

        public Place ShipOrigination { get; set; }

        public double DistanceToDestination { get; set; }

        public TimeSpan TimeToDestination { get; set; }

        public DateTime Arrival { get; set; }

        public bool SetDestination(Place destination)
        {
            this.ShipDestination = destination;
            this.ShipOrigination = this.ShipLocation;

            // determine distance to destination
            try
            {
                DistanceToDestination = Travel.DetermineDistance(this.ShipOrigination, this.ShipDestination);
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