using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarGames.Algorithms;

namespace WarGames.Models
{
    public class Plane
    {
        public Plane(int z, List<Coordinates> coordinatesList, UniverseBuilder ub)
        {
            Z = z;
            CoordinatesList = coordinatesList;
        }

        public int Z { get; set; }

        public List<Coordinates> CoordinatesList { get; set; }

        public List<Place> Places { get; set; }


        /// <summary>
        /// Adds all the places in the plane to the Places object.
        /// </summary>
        /// <param name="ub"></param>
        /// <returns></returns>
        public bool RegisterPlaces(Universe universe)
        {

            List<Place> places = new List<Place>();

            // get all places in the universe that is in the plane
            foreach (Place place in universe.Systems.Where(c => c.Coords.Z == this.Z))
            {
                places.Add(place);
            }
            this.Places = places;
            return true;
        }
    }
}
