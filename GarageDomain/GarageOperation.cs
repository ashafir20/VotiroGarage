using System;
using VotiroGarage;

namespace GarageDomain
{
    public abstract class CarOperationBase
    {
        protected string OperationDescription { get; set; }
        public abstract void RunOperation();
        public Func<string> PreExecutionMessage { get; set; }
        public Func<string> PostExecutionMessage { get; set; }
        public Car Car { protected get; set; }
    }

    internal class ConsoleLoggerOperationProxy : CarOperationBase
    {
        private IGarageLog logger = new GarageLogger(); //in real life scenerio it will be injected
        private readonly CarOperationBase _innerOperation;

        public ConsoleLoggerOperationProxy(CarOperationBase innerOperation)
        {
            _innerOperation = innerOperation;
        }

        public override void RunOperation()
        {
            logger.Log(_innerOperation.PreExecutionMessage());

            _innerOperation.RunOperation();

            logger.Log(_innerOperation.PostExecutionMessage());
        }
    }

    public class PaintCarOperation : CarOperationBase
    {
        private readonly Color _color;

        private readonly Action<Car, Color> _action = (car, color) => car.Color = color;

        public PaintCarOperation(Color color)
        {
            _color = color;
            OperationDescription = "Paint Car";
            PreExecutionMessage = () => string.Format("Car paint BEFORE paint operation is: {0}", Car.Color);
            PostExecutionMessage = () =>  string.Format("Car paint AFTER paint operation is: {0}", Car.Color);
        }

        public override void RunOperation()
        {
            _action(Car, _color);
        }
    }

    public class LowerCaseCarNameOperation : CarOperationBase
    {
        private readonly Action<Car> _action = car => car.Name = car.Name.ToLower();

        public LowerCaseCarNameOperation()
        {
            OperationDescription = "Lower Case Car Name";
            PreExecutionMessage = () => string.Format("Car name BEFORE name lower casing operation is: {0}", Car.Name);
            PostExecutionMessage = () =>  string.Format("Car name AFTER name lower casing operation is: {0}", Car.Name);
        }

        public override void RunOperation()
        {
            _action(Car);
        }
    }

    public class FuelCarOperation : CarOperationBase
    {
        private readonly int _fuel;
        private readonly Action<Car, int> _action = (car, fuel) => car.FuelTank = Math.Min(car.FuelTank + fuel, 100);

        public FuelCarOperation(int fuel)
        {
            _fuel = fuel;
            OperationDescription = "Lower Case Car Name";
            PreExecutionMessage = () => string.Format("Car fuel BEFORE fuel operation is: {0}", Car.FuelTank);
            PostExecutionMessage = () =>  string.Format("Car fuel AFTER fuel operation is: {0}", Car.FuelTank);
        }

        public override void RunOperation()
        {
            _action(Car, _fuel);
        }
    }
}
