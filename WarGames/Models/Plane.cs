using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarGames.Algorithms;

namespace WarGames.Models
{
    [Serializable]
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
            // TODO: refactor with better practices/split into methods

            // the first row written will be the max diameter-1
            int row = universe.Diameter - 1;
            StringBuilder endLine = new StringBuilder();
            endLine.Append("===");

            while (row > -1)
            {
                List<Place> rowPlaces = new List<Place>();
                List<Place> rowPlacesNextPlane = new List<Place>();
                List<Place> rowPlacesThirdPlane = new List<Place>();
                List<Place> rowPlacesFourthPlane = new List<Place>();

                // get next plane
                // TODO: fix out of range
                Plane nextPlane = universe.Planes.Where(p => p.Z == (this.Z + 1)).First();
                Plane thirdPlane = universe.Planes.Where(p => p.Z == (this.Z + 2)).First();
                Plane fourthPlane = universe.Planes.Where(p => p.Z == (this.Z + 3)).First();

                // get the places that are on this row (Y values)
                foreach (Place place in this.Places.Where(c => c.Coords.Y == row))
                {
                    rowPlaces.Add(place);
                }
                // get the places that are on this row (Y values) for next Plane
                foreach (Place place in nextPlane.Places.Where(c => c.Coords.Y == row))
                {
                    rowPlacesNextPlane.Add(place);
                }
                // get the places that are on this row (Y values) for third Plane
                foreach (Place place in thirdPlane.Places.Where(c => c.Coords.Y == row))
                {
                    rowPlacesThirdPlane.Add(place);
                }
                // get the places that are on this row (Y values) for fourth Plane
                foreach (Place place in fourthPlane.Places.Where(c => c.Coords.Y == row))
                {
                    rowPlacesFourthPlane.Add(place);
                }

                // order em
                rowPlaces.OrderBy(x => x.Coords.X);
                rowPlacesNextPlane.OrderBy(x => x.Coords.X);
                rowPlacesThirdPlane.OrderBy(x => x.Coords.X);
                rowPlacesFourthPlane.OrderBy(x => x.Coords.X);


                var cols = Enumerable.Range(0, universe.Diameter);
                Console.Write("| ");
                // these are the columns (X values)
                foreach (int col in cols)
                {
                    bool found = false;
                    // look though this plane
                    foreach (var place in rowPlaces)
                    {
                        if (place.Coords.X == col)
                        {
                            Console.Write(" @ ");
                            found = true;
                        }
                    }
                    // look though next plane
                    if (!found)
                    {
                        foreach (var place in rowPlacesNextPlane)
                        {
                            if (place.Coords.X == col)
                            {
                                Console.Write(" * ");
                                found = true;
                            }
                        }
                    }
                    // look though third plane
                    if (!found)
                    {
                        foreach (var place in rowPlacesThirdPlane)
                        {
                            if (place.Coords.X == col)
                            {
                                Console.Write(" . ");
                                found = true;
                            }
                        }
                    }
                    // look though fourth plane
                    if (!found)
                    {
                        foreach (var place in rowPlacesFourthPlane)
                        {
                            if (place.Coords.X == col)
                            {
                                Console.Write(" . ");
                                found = true;
                            }
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
