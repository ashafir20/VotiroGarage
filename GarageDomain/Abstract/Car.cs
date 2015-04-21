using VotiroGarage;

namespace GarageDomain
{
    public abstract class Car
    {
        public string Name { get; set; }
        public Color Color { get; set; }
        public int FuelTank { get; set; }
    }
}