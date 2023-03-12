using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICustomerService
    {
        IDataResults<List<Customer>> GetAll();
        IResults Add(Customer customer);
        IResults Update(Customer customer);
        IResults Delete(Customer customer);
    }
}
