using System;
using VotiroGarage;

namespace GarageDomain.CarOperations
{
    public class PaintCarOperation : CarOperationBase
    {
        private readonly Color _color;

        private readonly Action<Car, Color> _action = (car, color) => car.Color = color;

        public PaintCarOperation(Car car, Color color)
        {
            Car = car;
            _color = color;
            OperationDescription = "Paint Car";
        }

        public override void RunOperation()
        {
            _action(Car, _color);
        }
    }
}