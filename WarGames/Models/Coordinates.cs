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
        public Coordinates(double x, double y, double z)
        {
            if (IsValid(x))
                X = x;
            if (IsValid(y))
                Y = y;
            if (IsValid(Z))
                Z = z;
            else
                throw new ArgumentException("Coordinates entered are not valid.");
        }

        public double X { get; set; }

        public double Y { get; set; }

        public double Z { get; set; }

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
