using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using GarageDomain.CarOperations;
using VotiroGarage;

namespace GarageDomain
{
    public class Garage
    {
        public GarageOperationBuilder GetCarOperationsBuilder()
        {
            return new GarageOperationBuilder();
        }

        public class GarageOperationBuilder
        {
            private readonly ICollection<CarOperationBase> _operations;

            internal GarageOperationBuilder()
            {
                _operations = new List<CarOperationBase>();
            }

            public GarageOperationBuilder AddCarOperation(CarOperationBase operation)
            {
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
        }
    }
}
