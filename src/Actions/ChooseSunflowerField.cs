using System;
using System.Collections.Generic;
using System.Linq;
using Trestlebridge.Interfaces;
using Trestlebridge.Models;
using Trestlebridge.Models.Animals;

namespace Trestlebridge.Actions {
    public class ChooseSunflowerField {
        public static void CollectInput (Farm farm, IResource sunflower) {
            Console.Clear();

            // farm shows how many instances of fields exist
            // sunflower contains the selected type of seeds to purchase

            // create dictionary with key as number, value is selected field
            // loop over each field and build up dictionary
            // pass flower to correct field

            Dictionary<int, ISunflowerGrouping> fieldList = new Dictionary<int, ISunflowerGrouping>();
            int counter = 1;
            farm.NaturalFields.ForEach(f => {
                fieldList.Add(counter, f);
                counter++;
            });
            farm.PlowedFields.ForEach(p => {
                fieldList.Add(counter, p);
                counter++;
            });
            foreach (var item in fieldList)
            {
                Console.WriteLine($"{item.Key}. {item.Value.GetType().Name} ({item.Value.GetTotalInField()} flowers)");
            }

            Console.WriteLine ();

            // How can I output the type of sunflower chosen here?
            Console.WriteLine ($"Place the {sunflower} where?");

            Console.Write ("> ");
            int choice = Int32.Parse(Console.ReadLine ());
            choice = choice - 1; 

            // if (!farm.NaturalFields[choice].AddResource(sunflower))
            // {
            //     ChooseSunflowerField.CollectInput(farm, sunflower);
            // }

            /*
                Couldn't get this to work. Can you?
                Stretch goal. Only if the app is fully functional.
             */
            // farm.PurchaseResource<IGrazing>(animal, choice);

        }
    }
}