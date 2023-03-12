using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public IResults Add(User user)
        {
            _userDal.Add(user);
            return new SuccessResults();
        }

        public IResults Delete(User user)
        {
            _userDal.Delete(user);
            return new SuccessResults();
        }

        public IDataResults<List<User>> GetAll()
        {
            return new SuccessDataResults<List<User>>(_userDal.GetAll());
        }

        public IResults Update(User user)
        {
            _userDal.Update(user);
            return new SuccessResults();
        }
    }
}
