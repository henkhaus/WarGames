using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarGames.Data.IO;
using WarGames.Events;
using WarGames.Models;

namespace WarGames.Algorithms
{
    [Serializable]
    public class UniverseBuilder
    {
        public UniverseBuilder(Game game)
        {
            _game = game;
            DetermineSize(_game.Difficulty);
            UniverseFabric = CreateFabric();
            Systems = CreateSystems(UniverseFabric, .005);
        }

        private Game _game { get; set; }

        public int Diameter { get; set; }

        public Fabric UniverseFabric { get; set; }

        public List<Place> Systems { get; set; }

        public List<Plane> Planes { get; set; }


        public List<string> PossibleSystemNames()
        {
            List<string> systemNames = Data.IO.Utilities.ReadResource(Properties.Resources.systemNames);

            return systemNames;
        }

        public void DetermineSize(Difficulty difficulty)
        {
            switch (difficulty)
            {
                case Difficulty.Easy:
                    this.Diameter = 10;
                    break;
                case Difficulty.Medium:
                    this.Diameter = 25;
                    break;
                case Difficulty.Hard:
                    this.Diameter = 50;
                    break;
                default:
                    break;
            }
        }

        public Fabric CreateFabric()
        {
            List<Coordinates> coordinates = new List<Coordinates>();
            List<Plane> planes = new List<Plane>();

            var xRange = Enumerable.Range(0, this.Diameter);
            var yRange = Enumerable.Range(0, this.Diameter);
            var zRange = Enumerable.Range(0, this.Diameter);

            foreach (var z in xRange)
            {
                List<Coordinates> planeCoords = new List<Coordinates>();
                foreach (var y in yRange)
                {
                    foreach (var x in zRange)
                    {
                        Coordinates coord = new Coordinates((double)x, (double)y, (double)z);
                        coordinates.Add(coord);
                        planeCoords.Add(coord);
                    }
                }
                // also register planes
                Plane plane = new Plane(z, planeCoords, this);
                planes.Add(plane);
            }

            this.Planes = planes;

            Fabric fabric = new Fabric(coordinates);
            return fabric;
        }

        /// <summary>
        /// Creates inital systems for the universe at random.
        /// Density is a factor (ie 0.3).
        /// </summary>
        /// <param name="fabric"></param>
        /// <param name="density"></param>
        /// <returns></returns>
        public List<Place> CreateSystems(Fabric fabric, double density)
        {
            // TODO: add rules so systems dont get to close together
            // TODO: need spatial queries to add system placement rules
            List<Place> systems = new List<Place>();

            // get target number of systems to create
            int total = fabric.Space.Count;
            double target = total * density;

            List<string> possibleSystemNames = PossibleSystemNames();

            Random randSystem = new Random();
            Random randName = new Random();

            // lets do this
            while (target > 0)
            {
                int rSystem = randSystem.Next(total);
                int rName = randName.Next(possibleSystemNames.Count);

                Place system = new Place(possibleSystemNames[rName], fabric.Space[rSystem]);

                systems.Add(system);
                
                target -= 1;
            }
            // lets just use the distinct ones
            systems = systems.DistinctBy(x => x.Name).ToList();
            return systems;
        }
    }
}
