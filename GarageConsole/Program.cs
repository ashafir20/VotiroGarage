using System;
using GarageDomain;
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

            garage.InitGarage();


            //using a garage builder (for a more manual control over the operations)
            //-----------------------------
            var builder = garage.GetCarOperationsBuilder(car1);
            builder.AddCarOperation(new PaintCarOperation(Color.Blue))
                .AddCarOperation(new LowerCaseCarNameOperation());

            builder.SetCar(car2);
            builder.AddCarOperation(new PaintCarOperation(Color.Yellow));

            builder.SetCar(car3);
            builder.AddCarOperation(new LowerCaseCarNameOperation())
                .AddCarOperation(new PaintCarOperation(Color.Blue))
                .AddCarOperation(new FuelCarOperation(10));

            builder.Execute();

            //using a more user friendly garage oprerations api
            //-----------------------------



            Console.Read();
        }
    }
}
