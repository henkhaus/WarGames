using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarGames.Models;
using WarGames.Algorithms;
using WarGames.Models.ActionModel;
using WarGames.Models.ShipModel;
using WarGames.Models.UnitModel;
using System.Threading;

namespace WarGamesApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // create characters
            Character robert = new Character("Robert", 5, 5);
            robert.Race = Race.Bob;

            Character amanda = new Character("Amanda", 5, 5);
            amanda.Race = Race.Cyborg;

            // create places
            Place earth = new Place("earth", 0, 0, 0);
            Place planetX = new Place("planet x", 5, 5, 5);

            robert.CharacterLocation = earth;
            amanda.CharacterLocation = planetX;


            // ships
            ShipFactory shipFactory = new ShipFactory();

            IShip fighter = shipFactory.CreateShip(ShipType.Fighter, ShipClass.B);
            Console.WriteLine(fighter.GetNomenclature());            
            Fighter aFighter = (Fighter)fighter;
            aFighter.Speed = 7;
            aFighter.ShipLocation = earth;
            
            //robert: take ship to planetX 
            robert.Ships.Add(aFighter);
            Fighter robertsFighter = (Fighter)robert.Ships[0];
            robertsFighter.SetDestination(planetX);

            double DaystoDest = Convert.ToDouble(robertsFighter.TimeToDestination.TotalDays);
            Console.WriteLine($"dist to {robertsFighter.ShipDestination.Name}-{robertsFighter.DistanceToDestination} days-{DaystoDest} est.arrival-{robertsFighter.Arrival}");

            Console.WriteLine("travelling");
            // traveltime
            int travelTime = Convert.ToInt32(DaystoDest) * 10000;
            Thread.Sleep(travelTime);

            robert.CharacterLocation = planetX;


            
            Battle battle;
            if(robert.CharacterLocation == amanda.CharacterLocation)
            {
                battle = new Battle(robert, amanda);
                Console.WriteLine(battle.BattleStatus);

            }

            // testing interop
            /*
            battle.Attacke

            //TODO: create tests for these examples
            ActionFactory actionFactory = new ActionFactory();
            IAction attack = actionFactory.CreateAction(ActionType.Attack);
            Console.WriteLine(attack.GetActionType());

            Attack theAttack = new Attack(robert, new Item());

            theFighter.Use(new Item(), theAttack);
            UnitFactory unitFactory = new UnitFactory();
            IUnit recon = unitFactory.CreateUnit(UnitType.Recon, UnitSize.Battalion);
            Console.WriteLine(recon.GetNomenclature());
            */

            Console.ReadLine();
            
        }
    }
}
