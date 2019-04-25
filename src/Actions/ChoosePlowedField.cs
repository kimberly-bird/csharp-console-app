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
                Console.WriteLine ($"{i + 1}. Plowed Field ({farm.PlowedFields[i].GetSunflowersCount()} sunflower, {farm.PlowedFields[i].GetSesamesCount()} sesame)");
            }

            Console.WriteLine ();

            Console.WriteLine ($"Place the {flower} where?");

            Console.Write ("> ");
            int choice = Int32.Parse(Console.ReadLine ());
            choice = choice - 1; 

            if (!farm.PlowedFields[choice].AddResource(flower))
            {
                ChoosePlowedField.CollectInput(farm, flower);
            }
        }
    }
}