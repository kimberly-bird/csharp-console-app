using System;
using System.Linq;
using Trestlebridge.Interfaces;
using Trestlebridge.Models;
using Trestlebridge.Models.Animals;

namespace Trestlebridge.Actions {
    public class ChoosePlowedField {
        public static void CollectInput (Farm farm, ISeedProducing flower) {
            Console.Clear();

            for (int i = 0; i < farm.PlowedFields.Count; i++)
            {
                Console.WriteLine ($"{i + 1}. Plowed Field contains ({farm.PlowedFields[i].GetTotalInField()} flowers)");
            }

            Console.WriteLine ();

            // How can I output the type of flower chosen here?
            Console.WriteLine ($"Place the {flower} where?");

            Console.Write ("> ");
            int choice = Int32.Parse(Console.ReadLine ());
            choice = choice - 1; 

            if (!farm.PlowedFields[choice].AddResource(flower))
            {
                ChoosePlowedField.CollectInput(farm, flower);
            }

            /*
                Couldn't get this to work. Can you?
                Stretch goal. Only if the app is fully functional.
             */
            // farm.PurchaseResource<IGrazing>(animal, choice);

        }
    }
}