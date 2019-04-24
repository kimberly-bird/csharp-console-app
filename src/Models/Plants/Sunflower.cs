using System;
using Trestlebridge.Interfaces;
using Trestlebridge.Models.Animals;

namespace Trestlebridge.Models.Plants
{
    public class Sunflower : IResource, ISeedProducing, IComposting
    {
        private int _seedsProduced = 650;
        private double _compostProduced = 21.6;

        public string Type { get; } = "Sunflower";

        public double Compost()
        {
            return _compostProduced;
        }

        public double Harvest () {
            return _seedsProduced;
        }

        public override string ToString () {
            return $"Sunflower. Yum!";
        }
    }
}