using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarGames.Models.UnitModel
{
    public static class UnitConversion
    {
        public static double Convert(int units, UnitSize from, UnitSize to)
        {
            // element, squadron, group, fleet
            double[][] factor =
                {
                new double[] {1, .1, .025, .0125},
                new double[] {10, 1, .25, .125},
                new double[] {40, 4, 1, .5},
                new double[] {80, 8, 2, 1}
            };
            return units * factor[(int)from][(int)to];
        }
    }
}
