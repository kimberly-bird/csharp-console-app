using System;
using Trestlebridge.Interfaces;
using Trestlebridge.Models.Animals;

namespace Trestlebridge.Models.Plants
{
    public class Wildflower : IResource, IComposting
    {
        private double _compostProduced = 30.3;
        public string Type { get; } = "Wildflower";

        public double Compost()
        {
            return _compostProduced;
        }

        public double Harvest () {
            return _compostProduced;
        }

        public override string ToString () {
            return $"Wildflower. Smells amazing!";
        }
    }
}