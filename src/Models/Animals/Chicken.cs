using System;
using System.Collections.Generic;
using Trestlebridge.Interfaces;

namespace Trestlebridge.Models.Animals {
    public class Chicken : IResource, IEggProducing, IFeatherProducing, IMeatProducing {

        private Guid _id = Guid.NewGuid();
        private double _eggsProduced = 6;
        private double _feathersProduced = 0.75;
        private double _meatProduced = 1.7;

        private string _shortId {
            get {
                return this._id.ToString().Substring(this._id.ToString().Length - 6);
            }
        }

        public double GrassPerDay { get; set; } = 5.4;
        public string Type { get; } = "Chicken";

        // Methods
        public void Graze () {
            Console.WriteLine($"Chicken {this._shortId} just ate {this.GrassPerDay}kg of grass");
        }

        public double GatherEggs () {
            return _eggsProduced;
        }

        public double gatherFeathers () {
            return _feathersProduced;
        }

        public override string ToString () {
            return $"Chicken {this._shortId}. Bawk!";
        }

        public double Butcher()
        {
            return _meatProduced;
        }
    }
}