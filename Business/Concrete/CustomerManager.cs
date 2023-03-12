using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CustomerManager : ICustomerService
    {
        ICustomerDal _customerDal;

        public CustomerManager(ICustomerDal customerDal)
        {
            _customerDal = customerDal;
        }

        public IDataResults<List<Customer>> GetAll()
        {
            return new SuccessDataResults<List<Customer>>(_customerDal.GetAll());
        }

        public IResults Add(Customer customer)
        {
            _customerDal.Add(customer);
            return new SuccessResults();
        }

        public IResults Update(Customer customer)
        {
            _customerDal.Update(customer);
            return new SuccessResults();
        }

        public IResults Delete(Customer customer)
        {
            _customerDal.Delete(customer);
            return new SuccessResults();
        }
    }
}
