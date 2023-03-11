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

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }




        public IDataResults<List<Car>> GetAll()
        {
            if (DateTime.Now.Hour==03)
            {
                return new ErrorDataResults<List<Car>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResults<List<Car>>(_carDal.GetAll(),Messages.CarsListed);
        }

        public IDataResults<List<CarDetailDto>> GetCarDetails()
        {
            return new SuccessDataResults<List<CarDetailDto>>(_carDal.GetCarDetails());
        }

        public IDataResults<List<Car>> GetCarsByBrandId(int id)
        {
            return new SuccessDataResults<List<Car>>(_carDal.GetAll(p => p.BrandId == id));
        }

        public IDataResults<List<Car>> GetCarsByColorId(int id)
        {
            return new SuccessDataResults<List<Car>>(_carDal.GetAll(p => p.ColorId == id));
        }

        [ValidationAspect(typeof(CarValidator))]
        public IResults Add(Car car)
        {
            //if (car.CarName.Length <= 2 || car.DailyPrice <= 0)
            //{
            //    return new ErrorResults(Messages.CarInvalid);
            //}
            _carDal.Add(car);
            return new SuccessResults();

        }

    }
}
