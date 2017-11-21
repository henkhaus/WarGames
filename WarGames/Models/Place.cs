using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarGames.Models
{
    public class Place
    {
        public Place()
        {

        }

        public Place(string _name, double _x, double _y, double _z)
        {
            Name = _name;
            Coords = new Coordinates(_x, _y, _z);
        }

        public string Name { get; set; }

        public string Description { get; set; }

        public List<Resource> Resources { get; set; }

        public Coordinates Coords { get; set; }

    }
}
