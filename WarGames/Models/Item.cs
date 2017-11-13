using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarGames.Models
{

    public class Item : IAction
    {
        public Item()
        {
            this.active = true;
        }

        public Item(string _name, int _power, int _strength)
        {
            this.active = true;
            name = _name;
            power = _power;
            strength = _strength;
        }

        public string name { get; set; }

        public bool active { get; set; }

        public int playCost { get; set; }

        public int power { get; set; }

        public int strength { get; set; }

        public Place itemLocation { get; set; }

        public bool Degrade()
        {
            // calc damage from use
            int damage = 1;

            // subtract damage from strength
            this.strength -= damage;

            if (this.strength <= 0)
            {
                this.active = false;
            }

            return true;
        }

        public bool Action()
        {
            return true;
        }


    }
}
