using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManagerTest();
            //CarTest();

        }

        private static void CarTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            foreach (var car in carManager.GetAll().Data)
            {
                Console.WriteLine(car.Description);
            }
        }

        private static void CarManagerTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            var result = carManager.GetCarDetails();
            if (result.Success==true)
            {
              foreach (var car in result.Data)
              {
                Console.WriteLine("Model: " +car.Description + " Brand: " + car.BrandName + " Color: " + car.ColorName + " Price: " + car.DailyPrice);

              }
            }
            else
            {
                Console.WriteLine(result.Message);
            }

            
        }
    }
}
