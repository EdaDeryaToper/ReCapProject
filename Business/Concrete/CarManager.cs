using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using Business.BusinessAspect.Autofac;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Performance;
using Core.Aspects.Autofac.Transaction;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }



        [CacheAspect]
        public IDataResults<List<Car>> GetAll()
        {
            if (DateTime.Now.Hour==03)
            {
                return new ErrorDataResults<List<Car>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResults<List<Car>>(_carDal.GetAll(),Messages.CarsListed);
        }

        [CacheRemoveAspect("ICarService.Get")]
        public IResults Delete(Car car)
        {
            _carDal.Delete(car);
            return new SuccessResults();
        }

        public IDataResults<List<CarDetailDto>> GetCarDetails()
        {
            return new SuccessDataResults<List<CarDetailDto>>(_carDal.GetCarDetails());
        }

        [TransactionScopeAspect]
        public IResults AddTransactionalTest(Car car)
        {
            throw new NotImplementedException();
        }

        [PerformanceAspect(5)] //method çalışması 5 sn geçerse beni uyar
        public IDataResults<List<Car>> GetCarsByBrandId(int id)
        {
            return new SuccessDataResults<List<Car>>(_carDal.GetAll(p => p.BrandId == id));
        }

        public IDataResults<List<Car>> GetCarsByColorId(int id)
        {
            return new SuccessDataResults<List<Car>>(_carDal.GetAll(p => p.ColorId == id));
        }
        [SecuredOperation("car.add,admin")]
        [ValidationAspect(typeof(CarValidator))]
        [CacheRemoveAspect("ICarService.Get")]
        public IResults Add(Car car)
        {
            //if (car.CarName.Length <= 2 || car.DailyPrice <= 0)
            //{
            //    return new ErrorResults(Messages.CarInvalid);
            //}
            _carDal.Add(car);
            return new SuccessResults();

        }
        [CacheRemoveAspect("ICarService.Get")]
        public IResults Update(Car car)
        {
            _carDal.Update(car);
            return new SuccessResults();
        }
    }
}
