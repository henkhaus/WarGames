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

    [Serializable]
    public class Resource
    {
        public Resource(ResourceType _resourceType, int _resourceAmount)
        {
            ResourceName = _resourceType;
            ResourceAmount = _resourceAmount;
        }

        public ResourceType ResourceName { get; set; }

        public int ResourceAmount { get; set; } = 0;
    }
}
