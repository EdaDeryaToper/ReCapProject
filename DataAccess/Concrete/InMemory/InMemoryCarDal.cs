using DataAccess.Abstract;
using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;
        public InMemoryCarDal()
        {
            _cars = new List<Car>
            {
                 
                 new Car{Id=1,BrandId=1,ColorId=1,DailyPrice=10, ModelYear=1990, Description="Toyota"},
                 new Car{Id=2,BrandId=1,ColorId=1,DailyPrice=15, ModelYear=1992, Description="Nissa"},
                 new Car{Id=3,BrandId=2,ColorId=2,DailyPrice=50, ModelYear=2022, Description="TOBB"}
                
            };
        }



        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            var carDelete = _cars.FirstOrDefault(p => p.Id == car.Id);
            _cars.Remove(carDelete);
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetById(int id)
        {
            return _cars.Where(p => p.Id == id).ToList();
        }


        public void Update(Car car)
        {
            var carUpdate = _cars.SingleOrDefault(p => p.Id == car.Id);
            carUpdate.BrandId = car.BrandId;
            carUpdate.ColorId = car.ColorId;
            carUpdate.DailyPrice = car.DailyPrice;
            carUpdate.ModelYear = car.ModelYear;
            carUpdate.Description = car.Description;
        }
    }
}
