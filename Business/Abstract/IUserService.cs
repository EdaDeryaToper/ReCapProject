using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities.Concrete;

namespace Business.Abstract
{
    public interface IUserService
    {
        //IDataResults<List<User>> GetAll();
        //IResults Add(User user);
        //IResults Update(User user);
        //IResults Delete(User user);

        //IDataResults<List<OperationClaim>> GetClaims(User user);
        //IResults GetEmail(string email);

        List<OperationClaim> GetClaims(User user);
        void Add(User user);
        User GetByMail(string email);
    }
}
