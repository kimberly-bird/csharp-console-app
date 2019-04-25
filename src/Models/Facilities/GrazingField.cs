using System;
using System.Text;
using System.Collections.Generic;
using Trestlebridge.Interfaces;
using System.Linq;


namespace Trestlebridge.Models.Facilities {
    public class GrazingField : IFacility<IGrazing>
    {
        private int _capacity = 7;
        private Guid _id = Guid.NewGuid();

        private List<IGrazing> _animals = new List<IGrazing>();

        public double Capacity {
            get {
                return _capacity;
            }
        }

        // counts total number of animals in field (method not in use)
        public int GetTotalInField() {
            return _animals.Count;
        }

        // groups animals based off of animal type and then prints out the animal name and the number of animals of that type
        public void GroupAnimalTotals()
        {
            var groupedAnimals = _animals.GroupBy(a => a.Type);

            foreach (var item in groupedAnimals)
            {
                // example output: Cow (3)
                Console.WriteLine($"{item.Key} ({item.Count()})");
            }
        }

        public bool AddResource (IGrazing animal)
        {
            if (_animals.Count < _capacity) {
                _animals.Add(animal);
                return true;
            }
            else {
                Console.WriteLine(@"
**** That facililty is not large enough ****
****     Please choose another one      ****");

                Console.ReadLine();
                return false;

            }
        }

        public void AddResource (List<IGrazing> animals)  
        {
            if (_animals.Count + animals.Count <= _capacity) {
                _animals.AddRange(animals);
            }
        }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            string shortId = $"{this._id.ToString().Substring(this._id.ToString().Length - 6)}";

            output.Append($"Grazing field {shortId} has {this._animals.Count} animals\n");
            this._animals.ForEach(a => output.Append($"   {a}\n"));

            return output.ToString();
        }
    }
}