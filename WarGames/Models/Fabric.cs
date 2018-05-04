using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarGames.Algorithms;

namespace WarGames.Models
{
    [Serializable]
    public class Fabric
    {
        public List<Coordinates> Space { get; set; }

        public Fabric(List<Coordinates> coordinates)
        {
            Space = coordinates;
        }

    }
}
