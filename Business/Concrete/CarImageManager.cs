using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        ICarImageDal _carImageDal;

        public CarImageManager(ICarImageDal carImageDal)
        {
            _carImageDal = carImageDal;
        }
        public IDataResults<List<CarImage>> GetAll()
        {
            return new SuccessDataResults<List<CarImage>>(_carImageDal.GetAll());
        }

        public IResults Add(CarImage carImage)
        {
            _carImageDal.Add(carImage);
            return new SuccessResults();
        }

        public IResults Update(CarImage carImage)
        {
            _carImageDal.Update(carImage);
            return new SuccessResults();
        }

        public IResults Delete(CarImage carImage)
        {
            _carImageDal.Delete(carImage);
            return new SuccessResults();
        }
    }
}
