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
            double xDiff = Math.Abs(origin.coords.x - destination.coords.x);
            double yDiff = Math.Abs(origin.coords.y - destination.coords.y);
            double zDiff = Math.Abs(origin.coords.z - destination.coords.z);

            // pythagorean formula
            double distance = Math.Sqrt(Math.Pow(xDiff, 2) + Math.Pow(yDiff, 2) + Math.Pow(zDiff, 2));
            return distance;
        }
    }
}
