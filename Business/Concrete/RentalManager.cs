using Business.Abstract;
using Business.Constants;
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

        public IResults Add(Rental rental)
        {
            if (rental.ReturnDate ==null)
            {
                return new ErrorResults(Messages.DelayReturnDate);
            }
            _rentalDal.Add(rental);
            return new SuccessResults(Messages.CarReturned);
        }

        public IDataResults<List<Rental>> GetAll()
        {
            return new SuccessDataResults<List<Rental>>(_rentalDal.GetAll());
        }
    }
}
