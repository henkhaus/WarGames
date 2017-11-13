using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarGames.Models
{
    public enum ResourceType
    {
        Oil,
        Wood, 
        Metal
    }

    public class Resource
    {
        public Resource(ResourceType _resourceType, int _resourceAmount)
        {
            resourceName = _resourceType;
            resourceAmount = _resourceAmount;
        }

        public ResourceType resourceName { get; set; }

        public int resourceAmount { get; set; } = 0;
    }
}
