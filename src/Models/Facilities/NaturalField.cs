using System;
using System.Text;
using System.Collections.Generic;
using Trestlebridge.Interfaces;
using Trestlebridge.Models.Animals;

namespace Trestlebridge.Models.Facilities {
    public class NaturalField : ISunflowerGrouping, IFacility<IComposting>
    {
        private int _capacity = 3;
        private Guid _id = Guid.NewGuid();

        private List<IComposting> _flowers = new List<IComposting>();

        public string Name = "NaturalField";

        public double Capacity {
            get {
                return _capacity;
            }
        }

        public int GetTotalInField() {
            return _flowers.Count;
        }

        public bool AddResource (IComposting flower)
        {
            if (_flowers.Count < _capacity) {
                _flowers.Add(flower);
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

        public void AddResource (List<IComposting> flowers)  
        {
            if (_flowers.Count + flowers.Count <= _capacity) {
                _flowers.AddRange(flowers);
            }
        }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            string shortId = $"{this._id.ToString().Substring(this._id.ToString().Length - 6)}";

            output.Append($"Natural field {shortId} has {this._flowers.Count} flowers\n");
            this._flowers.ForEach(a => output.Append($"   {a}\n"));

            return output.ToString();
        }

        public double Compost()
        {
            return _flowers.Count;
        }
    }
}