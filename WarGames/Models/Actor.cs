using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarGames.Models
{
    public class Actor
    {
        public int BasePower { get; set; }

        public int BaseStrength { get; set; }

        public int EffectivePower { get; set; }

        public int EffectiveStrength { get; set; }

        public int ResourceTotal { get; set; }

        public bool Equip(Item item)
        {
            // add to power and strength
            EffectivePower += item.Power;
            EffectiveStrength += item.Strength;

            return true;
        }

        public bool Unequip(Item item)
        {
            // remove power and strength
            EffectivePower -= item.Power;
            EffectiveStrength -= item.Strength;

            return true;
        }

        public bool Use(Item item)
        {
            if (item.Active)
            {
                Equip(item);

                //TODO: use the item (attack, block, move, etc)

                // degrade item
                ResourceTotal -= item.PlayCost;
                item.Degrade();
                // TODO: implement damage to other character
            }
            if (!item.Active)
            {
                Unequip(item);
            }
            return true;
        }


        //TODO: add AssessTurn to Event.cs
        public bool AssessTurn(Actor attacker, Actor defender)
        {
            int netEffect = attacker.EffectivePower - defender.EffectiveStrength;
            // kill people and things here

            return true;
        }
    }
}
