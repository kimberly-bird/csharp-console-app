using System;
using System.Linq;
using System.Text;
using Trestlebridge.Interfaces;
using Trestlebridge.Models;
using Trestlebridge.Models.Animals;

namespace Trestlebridge.Actions {
    public class ChooseGrazingField {
        /*
        Class to list the number of grazing animals in each grazing field, add grazing animal to a field 
        */
        public static void CollectInput (Farm farm, IGrazing animal) {
            Console.Clear();

            for (int i = 0; i < farm.GrazingFields.Count; i++)
            {
                // prints incrementing number next to grazing field
                Console.WriteLine ($"{i + 1}. Grazing Field");
                // prints name of animal and the count of that animal in the field
                farm.GrazingFields[i].GroupAnimalTotals();
            }

            Console.WriteLine ();

            Console.WriteLine ($"Place the {animal.Type} where?");

            Console.Write ("> ");
            int choice = Int32.Parse(Console.ReadLine ());
            choice = choice - 1; 

            // only adds grazing animal to grazing field if not at capacity, otherwise, throws an error to prompt user to select another field
            if (!farm.GrazingFields[choice].AddResource(animal))
            {
                ChooseGrazingField.CollectInput(farm, animal);
            }
        }
    }
}