using System;
using System.Text;
using System.Collections.Generic;
using Trestlebridge.Interfaces;


namespace Trestlebridge.Models.Facilities {
    public class GrazingField : IFacility<IGrazing>
    {
        private int _capacity = 3;
        private Guid _id = Guid.NewGuid();

        private List<IGrazing> _animals = new List<IGrazing>();

        public double Capacity {
            get {
                return _capacity;
            }
        }

        public int GetTotalInField() {
            return _animals.Count;
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