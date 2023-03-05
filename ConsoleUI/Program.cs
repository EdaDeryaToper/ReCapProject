using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            
            CarManager carManager = new CarManager(new EfCarDal());
            
            Car car1 = new Car();           
                car1.CarId = 7;
                car1.BrandId = 4;
                car1.ColorId = 2;
                car1.DailyPrice = 20;
                car1.ModelYear = 2025;
                car1.Descriptions = "Toyota";
                //carManager.Add(car1);
                              
            
            Console.WriteLine("\nGet All CarId and Description:");
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.CarId + " " + car.Descriptions);
            }
            Console.WriteLine("\nGet All CarId and Description According to BrandId:");
            foreach (var car in carManager.GetCarsByBrandId(2))
            {
                Console.WriteLine("{0} - {1} - {2}",car.CarId,car.BrandId,car.Descriptions);
            }
            Console.WriteLine("\nGet All CarId and Description According to ColorId:");
            foreach (var car in carManager.GetCarsByColorId(3))
            {
                Console.WriteLine("CarId: {0} - ColorId: {1} - Descriptions: {2}", car.CarId, car.ColorId, car.Descriptions);
            }

            

        }
    }
}
