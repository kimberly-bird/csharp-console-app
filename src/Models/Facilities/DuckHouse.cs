using System;
using System.Text;
using System.Collections.Generic;
using Trestlebridge.Interfaces;
using Trestlebridge.Models.Animals;

namespace Trestlebridge.Models.Facilities {
    public class DuckHouse 
    {
        private int _capacity = 3;
        private Guid _id = Guid.NewGuid();

        private List<Duck> _ducks = new List<Duck>();

        public double Capacity {
            get {
                return _capacity;
            }
        }

        public int GetTotalInField() {
            return _ducks.Count;
        }

        public bool AddResource (Duck duck)
        {
            if (_ducks.Count < _capacity) {
                _ducks.Add(duck);
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

        public void AddResource (List<Duck> ducks)  
        {
            if (_ducks.Count + ducks.Count <= _capacity) {
                _ducks.AddRange(ducks);
            }
        }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            string shortId = $"{this._id.ToString().Substring(this._id.ToString().Length - 6)}";

            output.Append($"Grazing field {shortId} has {this._ducks.Count} animals\n");
            this._ducks.ForEach(a => output.Append($"   {a}\n"));

            return output.ToString();
        }
    }
}