using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarGames.Models
{
    [Serializable]
    public class Place
    {
        public Place()
        {

        }

        public Place(string name, Coordinates coordinates)
        {
            Name = name;
            Coords = coordinates;
        }

        public string Name { get; set; }

        public string Description { get; set; }

        public List<Resource> Resources { get; set; }

        public Coordinates Coords { get; set; }

        //TODO: add type (System, etc.)

        //TODO: have new places register with the universe

    }
}
