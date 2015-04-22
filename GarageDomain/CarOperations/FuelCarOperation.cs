using System;

namespace GarageDomain.CarOperations
{
    public class FuelCarOperation : CarOperationBase
    {
        private readonly int _fuel;
        private readonly Action<Car, int> _action = (car, fuel) => car.FuelTank = Math.Min(car.FuelTank + fuel, 100);

        public FuelCarOperation(Car car, int fuel)
        {
            Car = car;
            _fuel = fuel;
            OperationDescription = "Fuel Car";
        }

        public override void RunOperation()
        {
            _action(Car, _fuel);
        }
    }
}