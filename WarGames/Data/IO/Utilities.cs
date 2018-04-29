using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace WarGames.Data.IO
{
    public static class Utilities
    {
        public static List<string> ReadResource(string resource)
        {
            List<string> resourceList = resource.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries).ToList();

            return resourceList;
        }
    }
}
