using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarGames.Models;
using WarGames.Users;

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


        public static List<PlaceDistance> GetClosestSystems(Character character, Universe universe, int number)
        {
            List<PlaceDistance> placeDistances = new List<PlaceDistance>();

            // will be replaced by KD-tree or octree
            foreach (var place in universe.Systems)
            {
                PlaceDistance placeDistance = new PlaceDistance();
                placeDistance.distanceFromPlayer = DetermineDistance(character.CurrentLocation, place);
                placeDistance.place = place;
                if(placeDistance.distanceFromPlayer >0)
                    placeDistances.Add(placeDistance);
            }

            // sort and get the number of systems specified
            List<PlaceDistance> sorted = placeDistances.OrderBy(x => x.distanceFromPlayer).Take(number).ToList();

            return sorted;
        }
    }


    public class PlaceDistance
    {
        public double distanceFromPlayer { get; set; }

        public Place place { get; set; }
    }
}
