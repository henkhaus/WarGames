﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarGames.Models.ActionModel;
using WarGames.Algorithms;
using System.Runtime.Serialization;

namespace WarGames.Models
{
    [Serializable]
    public class Actor
    {

        public int BasePower { get; set; }

        public int BaseStrength { get; set; }

        public int EffectivePower { get; set; }

        public int EffectiveStrength { get; set; }

        public int ResourceTotal { get; set; }

        public bool Engaged { get; set; }

        // travel props and calculations
        [Description("Units per Earth Day")]
        public double Speed { get; set; }

        public Place CurrentLocation { get; set; }

        public Place Destination { get; set; }

        public Place Origination { get; set; }

        public double DistanceToDestination { get; set; }

        public TimeSpan TimeToDestination { get; set; }

        public DateTime Arrival { get; set; }
        //TODO: add travel events - make this turn based?
        public bool SetDestination(Place destination)
        {
            this.Destination = destination;
            this.Origination = this.CurrentLocation;

            // determine distance to destination
            try
            {
                this.DistanceToDestination = Travel.DetermineDistance(this.Origination, this.Destination);
                this.TimeToDestination = TimeSpan.FromDays(DistanceToDestination / this.Speed);
                this.Arrival = DateTime.Now + TimeToDestination;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Could not determine distance or time to destination. {e.Message}");
            }

            return true;
        }

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
        
        public bool Use(Item item, IAction action)
        {
            if (item.Active)
            {
                Equip(item);

                //TODO: use the item (attack, block, move, etc)
                if (action.BattleAction && this.Engaged)
                {
                    // create and send battle action

                }
                else
                {
                    // send non-battle action
                }

                // degrade item
                ResourceTotal -= item.PlayCost;
                item.Degrade();
                // TODO: implement: damage to other character
            }
            if (!item.Active)
            {
                Unequip(item);
            }
            return true;
        }

    }
}
