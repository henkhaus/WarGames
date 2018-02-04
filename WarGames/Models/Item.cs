using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarGames.Models
{
    [Serializable]
    public class Item
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

        public Place ItemLocation { get; set; }

        public int PlayCost { get; set; }

        public int Power { get; set; }

        public int Strength { get; set; }

        public double Range { get; set; }

        public double RangeDegradeRatio { get; set; }

        public List<double> extendedEffectivenessRanges
        {
            get
            {
                return extendedEffectivenessRanges;
            }
            set
            {
                RangeDegredation();
            }
        }

        /// <summary>
        /// Items degrade by 1 Strength with each use
        /// </summary>
        /// <returns></returns>
        public bool Degrade()
        {
            //TODO: make a smarter degredation tool in Algorithms namespace
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

        /// <summary>
        /// Example: A power of 2 with a degradation ratio of .25 should be extended to [1.5, 1, .5, 0]
        /// </summary>
        /// <returns></returns>
        public List<double> RangeDegredation()
        {
            List<double> extendedEffectiveness = new List<double>();
            
            double powerleft = this.Power;

            do
            {
                double thisUnitPower = (this.RangeDegradeRatio * this.Power) - powerleft;
                extendedEffectiveness.Add(thisUnitPower);
            }
            while (powerleft > 0);

            return extendedEffectiveness;
        }


        public bool Action()
        {
            return true;
        }


    }
}
