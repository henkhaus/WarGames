using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarGames.Models
{

    public class Item : IActor
    {
        public Item()
        {
            this.Active = true;
        }

        public Item(string _name, int _power, int _strength)
        {
            this.Active = true;
            Name = _name;
            Power = _power;
            Strength = _strength;
        }

        public string Name { get; set; }

        public bool Active { get; set; }

        public int PlayCost { get; set; }

        public int Power { get; set; }

        public int Strength { get; set; }

        public Place ItemLocation { get; set; }

        public bool Degrade()
        {
            // calc degredation from use
            int degredation = 1;

            // subtract damage from strength
            this.Strength -= degredation;

            if (this.Strength <= 0)
            {
                this.Active = false;
            }

            return true;
        }

        public bool Action()
        {
            return true;
        }


    }
}
