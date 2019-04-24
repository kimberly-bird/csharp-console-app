using System;
using System.Linq;
using Trestlebridge.Interfaces;
using Trestlebridge.Models;
using Trestlebridge.Models.Animals;

namespace Trestlebridge.Actions {
    public class ChooseNaturalField {
        public static void CollectInput (Farm farm, IComposting wildflower) {
            Console.Clear();

            for (int i = 0; i < farm.NaturalFields.Count; i++)
            {
                Console.WriteLine ($"{i + 1}. Natural Field contains ({farm.NaturalFields[i].GetTotalInField()} flowers)");
            }

            Console.WriteLine ();

            // How can I output the type of wildflower chosen here?
            Console.WriteLine ($"Place the {wildflower} where?");

            Console.Write ("> ");
            int choice = Int32.Parse(Console.ReadLine ());
            choice = choice - 1; 

            if (!farm.NaturalFields[choice].AddResource(wildflower))
            {
                ChooseNaturalField.CollectInput(farm, wildflower);
            }

            /*
                Couldn't get this to work. Can you?
                Stretch goal. Only if the app is fully functional.
             */
            // farm.PurchaseResource<IGrazing>(animal, choice);

        }
    }
}