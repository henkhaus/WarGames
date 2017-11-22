using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarGames.Models;

namespace WarGames.Models.ShipModel
{
    public class ShipFactory
    {
        public IShip CreateShip(ShipType shipType, ShipClass shipClass)
        {
            switch (shipType)
            {
                case ShipType.Fighter:
                    return new Fighter(shipClass);

                case ShipType.Transport:
                    return new Transport(shipClass);

                default:
                    throw new NotSupportedException();
            }
        }
    }
}
