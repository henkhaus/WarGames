using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarGames.Models.ActionModel;
using WarGames.Algorithms;
using System.Runtime.Serialization;
using System.Data.SqlTypes;

namespace WarGames.Models
{
    [Serializable]
    public class Actor
    {
        public string Name { get; set; }

        public int BasePower { get; set; }

        public int BaseStrength { get; set; }

        public int EffectivePower { get; set; }

        public int EffectiveStrength { get; set; }

        public int ResourceTotal { get; set; }

        public bool Engaged { get; set; }

        // travel props and calculations
        [Description("Units per game move")]
        public int Speed { get; set; } = 1;

        public Place CurrentLocation { get; set; }

        // null if not travelling
        public Place Destination { get; set; }

        // null if not travelling
        public Place Origination { get; set; }

        public int DistanceToDestination { get; set; }

        public int TurnsToDestination { get; set; }

        //TODO: add travel events - make this turn based?
        public bool SetDestination(Place destination)
        {
            this.Destination = destination;
            this.Origination = this.CurrentLocation;

            // determine distance to destination
            try
            {
                this.DistanceToDestination = Travel.DetermineDistance(this.Origination, this.Destination);
                this.TurnsToDestination = GetTurnsToDestination();
            }
            catch (Exception e)
            {
                Console.WriteLine($"Could not determine distance or moves to destination. {e.Message}");
            }

            return true;
        }

        public void SyncWithTurns(int turn, int playerCount)
        {
            if (this.Destination != null)
            {
                // set incrementor (could be made to be configurable for easy, med, hard settings)
                int incrementor = 1;

                // make sure only to increment once per round (once per each time all players play)
                int round = (int)Math.Floor((double)(turn / playerCount));

                // make sure turns have made a full round
                if ((round != 0 && turn % round == 0) || playerCount == 1)
                {
                    // sync all the things.
                    DistanceToDestination -= incrementor;
                    this.TurnsToDestination = GetTurnsToDestination();
                    Console.WriteLine($"DEBUG - dist to dest: {DistanceToDestination}, turns to dest: {TurnsToDestination}, turn: {turn}, round: {round}");

                    // we have moved, calculate a new current place...
                    this.CurrentLocation = new Place("Open Space", Travel.GetCurrentCoordinates(this));
                }

                if (DistanceToDestination <= 0)
                {
                    Console.WriteLine($"DEBUG - {Name} arrived at {Destination.Name}.");
                    this.CurrentLocation = this.Destination;
                    this.Destination = null;
                    this.Origination = null;
                    this.DistanceToDestination = 0;
                    this.TurnsToDestination = 0;
                }
            }
        }

        int GetTurnsToDestination()
        {
            //TODO: Implement speed for each actor!
            //return (int)Math.Floor((double)this.DistanceToDestination / this.Speed);
            return (int)Math.Floor((double)this.DistanceToDestination / 1);
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
