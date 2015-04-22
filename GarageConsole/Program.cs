using System;
using GarageDomain;
using GarageDomain.CarOperations;
using VotiroGarage;

namespace GarageConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            //client example usage of votiro's Car Garage
            var garage = new Garage();
            
            Car car1 = new SimpleCar { Color = Color.Black, FuelTank = 100, Name = "Ferrari" };
            Car car2 = new SimpleCar { Color = Color.White, FuelTank = 100, Name = "Porche" };
            Car car3 = new SimpleCar { Color = Color.Yellow, FuelTank = 50, Name = "BMW" };


            //using a garage builder (for a more manual control over the operations)
            //with this design we wont need to touch exising code at all only create new operations that inherit from baseCarOperation
            //-----------------------------
            var builder = garage.GetCarOperationsBuilder();
            builder.AddCarOperation(new PaintCarOperation(car1, Color.Blue))
                .AddCarOperation(new LowerCaseCarNameOperation(car1));

            builder.AddCarOperation(new PaintCarOperation(car2, Color.Yellow));

            builder.AddCarOperation(new LowerCaseCarNameOperation(car3))
                .AddCarOperation(new PaintCarOperation(car3, Color.Blue))
                .AddCarOperation(new FuelCarOperation(car3, 10));

            builder.Execute();

            Console.Read();
        }
    }
}
