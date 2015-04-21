using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using VotiroGarage;

namespace GarageDomain
{
    public class Garage
    {
        private Collection<CarOperationBase> _carOperations;

        public void InitGarage()
        {
          _carOperations = new Collection<CarOperationBase>
            {
                { new PaintCarOperation() },
                { new LowerCaseCarNameOperation() }
            };
        }

/*      public void Excecute(CarOperationBase operationBase)
        {
            operationBase.RunOperation();
        }*/

        public GarageOperationBuilder GetCarOperationsBuilder(Car car)
        {
            return new GarageOperationBuilder(car);
        }

        public class GarageOperationBuilder
        {
            private Car _car;
            private readonly ICollection<CarOperationBase> _operations;

            internal GarageOperationBuilder(Car car)
            {
                _car = car;
                _operations = new List<CarOperationBase>();
            }

            public GarageOperationBuilder AddCarOperation(CarOperationBase operation)
            {
                operation.Car = _car;
                _operations.Add(new ConsoleLoggerOperationProxy(operation));
                return this;
            }

            public void Execute()
            {
                foreach (var operation in _operations)
                {
                    operation.RunOperation();
                }
            }

            public void SetCar(Car car)
            {
                _car = car;
            }
        }
    }
}
