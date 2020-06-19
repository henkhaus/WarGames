using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using WarGames.Models;
using WarGames.Models.UnitModel;
using WarGames.Users;

namespace WarGames.Algorithms
{
    public static class Travel
    {

        public static int DetermineDistance(Place origin, Place destination)
        {
            double xDiff = Math.Abs(origin.Coords.X - destination.Coords.X);
            double yDiff = Math.Abs(origin.Coords.Y - destination.Coords.Y);
            double zDiff = Math.Abs(origin.Coords.Z - destination.Coords.Z);

            // pythagorean formula
            int distance = (int)Math.Floor(Math.Sqrt(Math.Pow(xDiff, 2) + Math.Pow(yDiff, 2) + Math.Pow(zDiff, 2)));
            return distance;
        }


        public static List<PlaceDistance> GetClosestSystems(Character character, Universe universe, int number)
        {
            List<PlaceDistance> placeDistances = new List<PlaceDistance>();

            // may become expensive on big universes, might be replaced by KD-tree or octree
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

        public static Place GetPlaceByName(Universe universe, string placename)
        {
            List<Place> places = universe.Systems;

            Place thePlace = null;

            foreach (Place place in places)
            {
                if (place.Name.ToLower() == placename)
                {
                    thePlace = place;
                }

            }
            return thePlace;
        }

        public static Coordinates GetCurrentCoordinates(Actor actor)
        {
            int totalDistance = DetermineDistance(actor.Origination, actor.Destination);

            // vector that represents delta
            Coordinates unitVector = new Coordinates(
                actor.Destination.Coords.X - actor.Origination.Coords.X,
                actor.Destination.Coords.Y - actor.Origination.Coords.Y,
                actor.Destination.Coords.Z - actor.Origination.Coords.Z);

            // scaled unit vector to length
            Coordinates scaledVector = new Coordinates(
                unitVector.X / totalDistance,
                unitVector.Y / totalDistance,
                unitVector.Z / totalDistance);


            // subract distance to go by the scaled vector to get current position
            Coordinates coords = new Coordinates(
                actor.Destination.Coords.X - (actor.DistanceToDestination * scaledVector.X),
                actor.Destination.Coords.Y - (actor.DistanceToDestination * scaledVector.Y),
                actor.Destination.Coords.Z - (actor.DistanceToDestination * scaledVector.Z));

            return coords;
        }

    }


    public class PlaceDistance
    {
        public double distanceFromPlayer { get; set; }

        public Place place { get; set; }
    }
}
