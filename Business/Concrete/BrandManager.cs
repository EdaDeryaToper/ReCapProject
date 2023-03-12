using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class BrandManager : IBrandService
    {
        IBrandDal _brandDal;

        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }

       

        public IDataResults<List<Brand>> GetAll()
        {
            return new SuccessDataResults<List<Brand>>(_brandDal.GetAll());
        }

        public IResults Add(Brand brand)
        {
            _brandDal.Add(brand);
            return new SuccessResults();
        }

        public IResults Update(Brand brand)
        {
            _brandDal.Update(brand);
            return new SuccessResults();
        }

        public IResults Delete(Brand brand)
        {
            _brandDal.Delete(brand);
            return new SuccessResults();
        }
    }
}
