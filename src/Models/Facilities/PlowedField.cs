using System;
using System.Text;
using System.Collections.Generic;
using Trestlebridge.Interfaces;
using Trestlebridge.Models.Animals;
using System.Linq;

namespace Trestlebridge.Models.Facilities {
    public class PlowedField : ISunflowerGrouping, IFacility<ISeedProducing>
    {
        private int _capacity = 3;
        private Guid _id = Guid.NewGuid();

        private List<ISeedProducing> _flowers = new List<ISeedProducing>();

        public string Name = "PlowedField";

        public double Capacity {
            get {
                return _capacity;
            }
        }

        // get total # flowers in field (method not in use)
        public int GetTotalInField() {
            return _flowers.Count;
        }

        // get total number of flowers in field
        public int GetSunflowersCount ()
        {
            return _flowers.Where(f => f.GetType().Name == "Sunflower").Count();
        }

        // get total number of sesames in field
        public int GetSesamesCount ()
        {
            return _flowers.Where(f => f.GetType().Name == "Sesame").Count();
        }

        public bool AddResource (ISeedProducing flower)
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

        public void AddResource (List<ISeedProducing> flowers)  
        {
            if (_flowers.Count + flowers.Count <= _capacity) {
                _flowers.AddRange(flowers);
            }
        }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            string shortId = $"{this._id.ToString().Substring(this._id.ToString().Length - 6)}";

            output.Append($"Plowed field {shortId} has {this._flowers.Count} flowers\n");
            this._flowers.ForEach(a => output.Append($"   {a}\n"));

            return output.ToString();
        }

        public double Harvest()
        {
            throw new NotImplementedException();
        }

        public int GetWildflowerCount()
        {
            return 0;
        }
    }
}