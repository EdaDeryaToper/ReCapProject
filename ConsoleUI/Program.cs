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
            //CarManager carManager = new CarManager(new InMemoryCarDal());
            //foreach (var car in carManager.GetAll())
            //{
            //    Console.WriteLine(car.CarId + " " + car.Descriptions);
            //}
            CarManager carManager = new CarManager(new EfCarDal());

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
