using System;
using System.Linq;
using Trestlebridge.Interfaces;
using Trestlebridge.Models;
using Trestlebridge.Models.Animals;

namespace Trestlebridge.Actions {
    public class ChooseChickenHouse {
        /*
        Class to list the number of chickens in each chicken house, add chicken to a chicken house 
        */
        public static void CollectInput (Farm farm, Chicken chicken) {
            Console.Clear();

            for (int i = 0; i < farm.ChickenHouse.Count; i++)
            {
                // calculates the number of chickens currently in each chicken house
                Console.WriteLine ($"{i + 1}. Chicken House contains ({farm.ChickenHouse[i].GetTotalInField()} chickens)");
            }

            Console.WriteLine ();

            Console.WriteLine ($"Place the {chicken.Type} where?");

            Console.Write ("> ");
            int choice = Int32.Parse(Console.ReadLine ());
            choice = choice - 1; 

            // only adds chicken to chicken house if not at capacity, otherwise, throws an error to prompt user to select another field
            if (!farm.ChickenHouse[choice].AddResource(chicken))
            {
                ChooseChickenHouse.CollectInput(farm, chicken);
            }
        }
    }
}