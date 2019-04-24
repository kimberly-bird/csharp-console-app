using System;
using System.Linq;
using Trestlebridge.Interfaces;
using Trestlebridge.Models;
using Trestlebridge.Models.Animals;

namespace Trestlebridge.Actions {
    public class ChooseChickenHouse {
        public static void CollectInput (Farm farm, Chicken chicken) {
            Console.Clear();

            for (int i = 0; i < farm.ChickenHouse.Count; i++)
            {
                Console.WriteLine ($"{i + 1}. Chicken House contains ({farm.ChickenHouse[i].GetTotalInField()} chickens)");
            }

            Console.WriteLine ();

            // How can I output the type of chicken chosen here?
            Console.WriteLine ($"Place the {chicken.Type} where?");

            Console.Write ("> ");
            int choice = Int32.Parse(Console.ReadLine ());
            choice = choice - 1; 

            if (!farm.ChickenHouse[choice].AddResource(chicken))
            {
                ChooseChickenHouse.CollectInput(farm, chicken);
            }

            /*
                Couldn't get this to work. Can you?
                Stretch goal. Only if the app is fully functional.
             */
            // farm.PurchaseResource<IGrazing>(animal, choice);

        }
    }
}