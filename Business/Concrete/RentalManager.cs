using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;

        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }
        [ValidationAspect(typeof(RentalValidator))]
        public IResults Add(Rental rental)
        {
            //if (rental.ReturnDate ==null)
            //{
            //    return new ErrorResults(Messages.DelayReturnDate);
            //}
            _rentalDal.Add(rental);
            return new SuccessResults(Messages.CarReturned);
        }

        public IResults Update(Rental rental)
        {
            _rentalDal.Update(rental);
            return new SuccessResults();
        }

        public IResults Delete(Rental rental)
        {
            _rentalDal.Delete(rental);
            return new SuccessResults();
        }

        public IDataResults<List<Rental>> GetAll()
        {
            return new SuccessDataResults<List<Rental>>(_rentalDal.GetAll());
        }
    }
}
