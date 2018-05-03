using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarGames.Models;

namespace WarGames.Algorithms
{
    public static class Travel
    {

        public static double DetermineDistance(Place origin, Place destination)
        {
            double xDiff = Math.Abs(origin.Coords.X - destination.Coords.X);
            double yDiff = Math.Abs(origin.Coords.Y - destination.Coords.Y);
            double zDiff = Math.Abs(origin.Coords.Z - destination.Coords.Z);

            // pythagorean formula
            double distance = Math.Sqrt(Math.Pow(xDiff, 2) + Math.Pow(yDiff, 2) + Math.Pow(zDiff, 2));
            return distance;
        }

        
    }
}
