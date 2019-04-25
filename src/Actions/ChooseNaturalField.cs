using System;
using System.Collections.Generic;
using System.Linq;
using Trestlebridge.Interfaces;
using Trestlebridge.Models;
using Trestlebridge.Models.Animals;

namespace Trestlebridge.Actions {
    public class ChooseNaturalField {
        /*
        Class to list the number of flowers in each natural field, add flower to a field 
        */
        public static void CollectInput (Farm farm, IComposting wildflower) {
            Console.Clear();

            for (int i = 0; i < farm.NaturalFields.Count; i++)
            {
                // calculates the number of sunflowers and wildflowers in the current field
                Console.WriteLine ($"{i + 1}. Natural Field ({farm.NaturalFields[i].GetSunflowersCount()} sunflower, {farm.NaturalFields[i].GetWildflowerCount()} wildflower)");
            }

            Console.WriteLine ();

            Console.WriteLine ($"Place the {wildflower.GetType().Name} where?");

            Console.Write ("> ");
            int choice = Int32.Parse(Console.ReadLine ());
            choice = choice - 1; 

            // only adds flower to field if not at capacity, otherwise, throws an error to prompt user to select another field
            if (!farm.NaturalFields[choice].AddResource(wildflower))
            {
                ChooseNaturalField.CollectInput(farm, wildflower);
            }
        }
    }
}