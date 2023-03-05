using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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
                 
                 new Car{CarId=1,BrandId=1,ColorId=1,DailyPrice=10, ModelYear=1990, Descriptions="Toyota"},
                 new Car{CarId=2,BrandId=1,ColorId=1,DailyPrice=15, ModelYear=1992, Descriptions="Nissa"},
                 new Car{CarId=3,BrandId=2,ColorId=2,DailyPrice=50, ModelYear=2022, Descriptions="TOBB"}
                
            };
        }



       
        public void Add(Car entity)
        {
            _cars.Add(entity);
        }

       

        public void Delete(Car entity)
        {
            var carDelete = _cars.FirstOrDefault(p => p.CarId == entity.CarId);
            _cars.Remove(carDelete);
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetById(int id)
        {
            return _cars.Where(p => p.CarId == id).ToList();
        }



        public void Update(Car entity)
        {
            var carUpdate = _cars.SingleOrDefault(p => p.CarId == entity.CarId);
            carUpdate.BrandId = entity.BrandId;
            carUpdate.ColorId = entity.ColorId;
            carUpdate.DailyPrice = entity.DailyPrice;
            carUpdate.ModelYear = entity.ModelYear;
            carUpdate.Descriptions = entity.Descriptions;
        }
    }
}
