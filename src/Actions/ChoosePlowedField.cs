using System;
using System.Linq;
using Trestlebridge.Interfaces;
using Trestlebridge.Models;
using Trestlebridge.Models.Animals;

namespace Trestlebridge.Actions {
    public class ChoosePlowedField {
        /*
        Class to list the number of flowers in each natural field, add flower to a field 
        */
        public static void CollectInput (Farm farm, ISeedProducing flower) {
            Console.Clear();

            for (int i = 0; i < farm.PlowedFields.Count; i++)
            {
                // calculates the number of sunflowers and sesames in the current field
                Console.WriteLine ($"{i + 1}. Plowed Field ({farm.PlowedFields[i].GetSunflowersCount()} sunflower, {farm.PlowedFields[i].GetSesamesCount()} sesame)");
            }

            Console.WriteLine ();

            Console.WriteLine ($"Place the {flower} where?");

            Console.Write ("> ");
            int choice = Int32.Parse(Console.ReadLine ());
            choice = choice - 1; 

            // only adds flower to field if not at capacity, otherwise, throws an error to prompt user to select another field
            if (!farm.PlowedFields[choice].AddResource(flower))
            {
                ChoosePlowedField.CollectInput(farm, flower);
            }
        }
    }
}