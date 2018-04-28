using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarGames.Models
{
    [Serializable]
    public class Coordinates
    {
        public Coordinates(double _x, double _y, double _z)
        {
            if(IsValid(_x))
                x = _x;
            if(IsValid(_y))
                y = _y;
            if (IsValid(_z))
                z = _z;
            else
                throw new ArgumentException("Coordinates entered are not valid.");
        }

        public double x { get; set; }

        public double y { get; set; }

        public double z { get; set; }

        private bool IsValid(double coord)
        {  
            // how big is the universe?
            //TODO: make universe size an option
            if (coord <= 1000000.0)
                return true;
            else
                return false;
        }

    }
}
