using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarGames.Data.IO;

namespace WarGames.Algorithms
{
    public class UniverseBuilder
    {
        public List<string> GetSystemNames()
        {
            List<string> systemNames = Utilities.ReadResource(Properties.Resources.systemNames);

            return systemNames;
        }


    }

}
