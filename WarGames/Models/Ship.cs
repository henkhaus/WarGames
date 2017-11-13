using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarGames.Models
{
    public enum ShipType
    {
        Transport, 
        Fighter,
        Cargo
    }


    public class Ship : Item
    {
        public Ship(ShipType _shipType)
        {
            // parse ship type to enum
            shipType = _shipType;

        }

        public ShipType shipType { get; set; }

        public int speed { get; set; }

        public Place shipLocation { get; set; }

        public Place shipDestination { get; set; }

        public Place shipOrigination { get; set; }

        public double arrival { get; set; }

        public bool SetDestination(Place destination)
        {
            this.shipDestination = destination;
            this.shipOrigination = this.shipLocation;

            //TODO: determine distance to destination



            return true;
        }




    }
 }