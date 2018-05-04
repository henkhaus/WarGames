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


        /// <summary>
        /// Basic Viewer
        /// </summary>
        /// <param name="universe"></param>
        public void PlanePrinter(Universe universe)
        {
            // the first row written will be the max diameter-1
            int row = universe.Diameter - 1;
            StringBuilder endLine = new StringBuilder();
            endLine.Append("===");
            while (row > -1)
            {
                List<Place> rowPlaces = new List<Place>();

                // get the places that are on this row (Y values)
                foreach (Place place in this.Places.Where(c => c.Coords.Y == row))
                {
                    rowPlaces.Add(place);
                }

                // order em
                rowPlaces.OrderBy(x => x.Coords.X);

                var cols = Enumerable.Range(0, universe.Diameter);
                Console.Write("| ");
                // these are the columns (X values)
                foreach (int col in cols)
                {
                    bool found = false;
                    foreach (var place in rowPlaces)
                    {
                        if (place.Coords.X == col)
                        {
                            Console.Write(" # ");
                            found = true;
                        }
                    }
                    if (!found)
                    {
                        Console.Write("   ");
                    }
                }
                Console.WriteLine("");

                endLine.Append("===");
                row -= 1;
            }
            Console.Write(endLine.ToString());
        }
    }
}
