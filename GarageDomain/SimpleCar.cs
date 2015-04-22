namespace GarageDomain
{
    public class SimpleCar : Car
    {
        public override string ToString()
        {
            return string.Format("Car details color: {0}, Name: {1}, Fuel: {2}", Color, Name, FuelTank);
        }
    }
}
