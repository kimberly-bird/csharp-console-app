using System;
using System.Linq;
using Trestlebridge.Interfaces;
using Trestlebridge.Models;
using Trestlebridge.Models.Animals;

namespace Trestlebridge.Actions {
    public class ChooseDuckHouse {
        /*
        Class to list the number of duck in each duck house, add duck to a duck house 
        */
        public static void CollectInput (Farm farm, Duck duck) {
            Console.Clear();

            for (int i = 0; i < farm.DuckHouse.Count; i++)
            {
                Console.WriteLine ($"{i + 1}. Duck House contains ({farm.DuckHouse[i].GetTotalInField()} ducks)");
            }

            Console.WriteLine ();

            Console.WriteLine ($"Place the {duck.Type} where?");

            Console.Write ("> ");
            int choice = Int32.Parse(Console.ReadLine ());
            choice = choice - 1; 

            // only adds duck to duck house if not at capacity, otherwise, throws an error to prompt user to select another field
            if (!farm.DuckHouse[choice].AddResource(duck))
            {
                ChooseDuckHouse.CollectInput(farm, duck);
            }
        }
    }
}