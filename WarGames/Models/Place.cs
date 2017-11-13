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
            name = _name;
            coords = new Coordinates(_x, _y, _z);
        }

        public string name { get; set; }

        public string description { get; set; }

        public List<Resource> resources { get; set; }

        public Coordinates coords { get; set; }

    }
}
