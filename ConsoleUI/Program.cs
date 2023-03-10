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
            //CarTest();
            //CarDtoTest();
            //CarColorBrandTest();

            //CarAddMethod();
            //ResultTest();


            RentalManager rentalManager = new RentalManager(new EfRentalDal());

            var result = rentalManager.Add(new Rental { CarId = 1, CustomerId = 1 });
            if (result.Success)
            {
                Console.WriteLine(result.Message);

            }
            else
            {
                Console.WriteLine(result.Message);
            }

        }

        private static void ResultTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            var result = carManager.GetAll();
            if (result.Success)
            {
                Console.WriteLine(result.Message);
                foreach (var car in result.Data)
                {
                    Console.WriteLine(car.CarName);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }

        private static void CarAddMethod()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            Car car1 = new Car();
            car1.CarId = 9;
            car1.BrandId = 4;
            car1.ColorId = 2;
            car1.CarName = "";
            car1.DailyPrice = 20;
            car1.ModelYear = 2025;
            car1.Descriptions = "Dizel, 200km";
            if (carManager.Add(car1).Success)
            {
                carManager.Add(car1);
                
            }
            else
            {
                Console.WriteLine(carManager.Add(car1).Message);
            }
            
        }

        private static void CarColorBrandTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            Console.WriteLine("\n--CAR: Id---Name--Description");
            foreach (var car in carManager.GetAll().Data)
            {
                Console.WriteLine(car.CarId + " " + car.CarName + " " + car.Descriptions);
            }

            ColorManager colorManager = new ColorManager(new EfColorDal());
            Console.WriteLine("\n--COLOR: Id---Name");
            foreach (var color in colorManager.GetAll().Data)
            {
                Console.WriteLine(color.ColorId + " " + color.ColorName);
            }

            BrandManager brandManager = new BrandManager(new EfBrandDal());
            Console.WriteLine("\n--BRAND: Id---Name");
            foreach (var brand in brandManager.GetAll().Data)
            {
                Console.WriteLine(brand.BrandId + " " + brand.BrandName);
            }
        }

        private static void CarDtoTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            foreach (var item in carManager.GetCarDetails().Data)
            {
                Console.WriteLine("{0} - {1} - {2} - {3}", item.CarName, item.BrandName, item.ColorName, item.DailyPrice);
            }
        }

        private static void CarTest()
        {

            CarManager carManager = new CarManager(new EfCarDal());

            Console.WriteLine("\nGet All CarId and Description:");
            foreach (var car in carManager.GetAll().Data)
            {
                Console.WriteLine(car.CarId + " " + car.Descriptions);
            }
            Console.WriteLine("\nGet All CarId and Description According to BrandId:");
            foreach (var car in carManager.GetCarsByBrandId(2).Data)
            {
                Console.WriteLine("{0} - {1} - {2}", car.CarId, car.BrandId, car.Descriptions);
            }
            Console.WriteLine("\nGet All CarId and Description According to ColorId:");
            foreach (var car in carManager.GetCarsByColorId(3).Data)
            {
                Console.WriteLine("CarId: {0} - ColorId: {1} - Descriptions: {2}", car.CarId, car.ColorId, car.Descriptions);
            }
        }
    }
}
