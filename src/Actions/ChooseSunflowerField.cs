using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Trestlebridge.Interfaces;
using Trestlebridge.Models;
using Trestlebridge.Models.Animals;
using Trestlebridge.Models.Facilities;
using Trestlebridge.Models.Plants;

namespace Trestlebridge.Actions {
    public class ChooseSunflowerField {
        public static void CollectInput (Farm farm, IResource sunflower) {
        /*
        Class to list the number of flowers in each natural field, add flower to a field 
        */
            Console.Clear();


            // dictionary with key as incrementing counter (which is the number the user will click on the console), value is instance of selected field
            Dictionary<int, ISunflowerGrouping> fieldDict = new Dictionary<int, ISunflowerGrouping>();
            
            // loop over each field and build up dictionary
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
                StringBuilder output = new StringBuilder();

                // get the type of field (natural or plowed)
                var fieldType = item.Value.GetType().Name;

                // output the number, type of field, and the sunflower count
                output.Append($"{item.Key}. {fieldType} ({item.Value.GetSunflowersCount()} sunflower, ");

                // conditionally show wildflower and sesame, based on fieldtype
                if (fieldType == "NaturalField")
                {
                    output.Append($"{item.Value.GetWildflowerCount()} wildflower)");
                } 

                if (fieldType == "PlowedField")
                {
                    output.Append($"{item.Value.GetSesamesCount()} sesame)");
                }

                Console.WriteLine($"{output}");

            }

            Console.WriteLine ();

            Console.WriteLine ($"Place the {sunflower} where?");

            Console.Write ("> ");
            int choice = Int32.Parse(Console.ReadLine ());

            // get the type of field that was selected and add sunflower to appropriate field type
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