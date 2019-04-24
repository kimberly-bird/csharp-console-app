using System;
using System.Collections.Generic;
using System.Linq;
using Trestlebridge.Interfaces;
using Trestlebridge.Models;
using Trestlebridge.Models.Animals;

namespace Trestlebridge.Actions {
    public class ChooseSunflowerField {
        public static void CollectInput (Farm farm, IComposting wildflower) {
            Console.Clear();

            // farm shows how many instances of fields exist
            // wildflower contains the selected type of seeds to purchase

            // create dictionary with key as number, value is selected field
            // loop over each field and build up dictionary
            // pass flower to correct field

            // Dictionary<int, string> fieldList = new Dictionary<int, string>();
            // int counter = 1;
            // farm.NaturalFields.ForEach(f => {
            //     fieldList.Add(counter, f.Name.ToString());
            //     counter++;
            //     farm.PlowedFields.ForEach(p => {
            //         fieldList.Add(counter, p.Name.ToString());
            //     });
            //     counter++;
            // });

            for (int i = 0; i < farm.NaturalFields.Count; i++)
            {
                Console.WriteLine ($"{i + 1}. Natural Field ({farm.NaturalFields[i].GetTotalInField()} flowers)");
            }
            for (int j = 0; j < farm.PlowedFields.Count; j++)
            {
                Console.WriteLine ($"{j + 1}. Plowed Field ({farm.PlowedFields[j].GetTotalInField()} flowers)");
            }

            Console.WriteLine ();

            // How can I output the type of wildflower chosen here?
            Console.WriteLine ($"Place the {wildflower} where?");

            Console.Write ("> ");
            int choice = Int32.Parse(Console.ReadLine ());
            choice = choice - 1; 

            if (!farm.NaturalFields[choice].AddResource(wildflower))
            {
                ChooseSunflowerField.CollectInput(farm, wildflower);
            }

            /*
                Couldn't get this to work. Can you?
                Stretch goal. Only if the app is fully functional.
             */
            // farm.PurchaseResource<IGrazing>(animal, choice);

        }
    }
}