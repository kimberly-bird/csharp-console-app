using System;
using System.Linq;
using Trestlebridge.Interfaces;
using Trestlebridge.Models;
using Trestlebridge.Models.Animals;

namespace Trestlebridge.Actions {
    public class ChooseDuckHouse {
        public static void CollectInput (Farm farm, Duck duck) {
            Console.Clear();

            for (int i = 0; i < farm.DuckHouse.Count; i++)
            {
                Console.WriteLine ($"{i + 1}. Duck House contains ({farm.DuckHouse[i].GetTotalInField()} ducks)");
            }

            Console.WriteLine ();

            // How can I output the type of duck chosen here?
            Console.WriteLine ($"Place the {duck.Type} where?");

            Console.Write ("> ");
            int choice = Int32.Parse(Console.ReadLine ());
            choice = choice - 1; 

            if (!farm.DuckHouse[choice].AddResource(duck))
            {
                ChooseDuckHouse.CollectInput(farm, duck);
            }

            /*
                Couldn't get this to work. Can you?
                Stretch goal. Only if the app is fully functional.
             */
            // farm.PurchaseResource<IGrazing>(animal, choice);

        }
    }
}