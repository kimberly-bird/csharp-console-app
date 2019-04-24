using System;
using System.Collections.Generic;
using System.Linq;
using Trestlebridge.Interfaces;
using Trestlebridge.Models;
using Trestlebridge.Models.Animals;
using Trestlebridge.Models.Facilities;
using Trestlebridge.Models.Plants;

namespace Trestlebridge.Actions {
    public class ChooseSunflowerField {
        public static void CollectInput (Farm farm, IResource sunflower) {
            Console.Clear();

            // create dictionary with key as incrementing number, value is instance of selected field
            // loop over each field and build up dictionary

            Dictionary<int, ISunflowerGrouping> fieldDict = new Dictionary<int, ISunflowerGrouping>();
            
            int counter = 1;
            farm.NaturalFields.ForEach(f => {
                fieldDict.Add(counter, f);
                counter++;
            });
            farm.PlowedFields.ForEach(p => {
                fieldDict.Add(counter, p);
                counter++;
            });
            foreach (var item in fieldDict)
            {
                // display available fields and # flowers in each field to user
                Console.WriteLine($"{item.Key}. {item.Value.GetType().Name} ({item.Value.GetTotalInField()} rows of plants)");
            }

            Console.WriteLine ();

            Console.WriteLine ($"Place the {sunflower} where?");

            Console.Write ("> ");
            int choice = Int32.Parse(Console.ReadLine ());

            // get the type of field that was selected and add to appropriate field list
            switch (fieldDict[choice].GetType().Name)
            {
                case "PlowedField":
                    var field = (PlowedField)fieldDict[choice];
                    if (!field.AddResource((Sunflower)sunflower))
                    {
                        ChooseSunflowerField.CollectInput(farm, (Sunflower)sunflower);
                    }
                    break;
                case "NaturalField":
                    var natField = (NaturalField)fieldDict[choice];
                    if (!natField.AddResource((Sunflower)sunflower))
                    {
                        ChooseSunflowerField.CollectInput(farm, (Sunflower)sunflower);
                    }
                    break;
            }
        }
    }
}