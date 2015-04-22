using System;

namespace GarageDomain.CarOperations
{
    public class LowerCaseCarNameOperation : CarOperationBase
    {
        private readonly Action<Car> _action = car => car.Name = car.Name.ToLower();

        public LowerCaseCarNameOperation(Car car)
        {
            Car = car;
            OperationDescription = "Lower Case Car Name";
        }

        public override void RunOperation()
        {
            _action(Car);
        }
    }
}