using System;
using System.Text;
using System.Collections.Generic;
using Trestlebridge.Interfaces;
using Trestlebridge.Models.Animals;

namespace Trestlebridge.Models.Facilities {
    public class ChickenHouse 
    {
        private int _capacity = 3;
        private Guid _id = Guid.NewGuid();

        private List<Chicken> _chickens = new List<Chicken>();

        public double Capacity {
            get {
                return _capacity;
            }
        }

        // counts the # of chickens in chicken house
        public int GetTotalInField() {
            return _chickens.Count;
        }

        public bool AddResource (Chicken chicken)
        {
            if (_chickens.Count < _capacity) {
                _chickens.Add(chicken);
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

        public void AddResource (List<Chicken> chickens)  
        {
            if (_chickens.Count + chickens.Count <= _capacity) {
                _chickens.AddRange(chickens);
            }
        }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            string shortId = $"{this._id.ToString().Substring(this._id.ToString().Length - 6)}";

            output.Append($"Grazing field {shortId} has {this._chickens.Count} animals\n");
            this._chickens.ForEach(a => output.Append($"   {a}\n"));

            return output.ToString();
        }
    }
}