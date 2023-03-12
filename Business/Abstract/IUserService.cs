using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IUserService
    {
        IDataResults<List<User>> GetAll();
        IResults Add(User user);
        IResults Update(User user);
        IResults Delete(User user);
    }
}
