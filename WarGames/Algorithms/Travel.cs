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
            double xDiff = Math.Abs(origin.Coords.x - destination.Coords.x);
            double yDiff = Math.Abs(origin.Coords.y - destination.Coords.y);
            double zDiff = Math.Abs(origin.Coords.z - destination.Coords.z);

            // pythagorean formula
            double distance = Math.Sqrt(Math.Pow(xDiff, 2) + Math.Pow(yDiff, 2) + Math.Pow(zDiff, 2));
            return distance;
        }

        
    }
}
