using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities.Concrete;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        //    public IResults Add(User user)
        //    {
        //        _userDal.Add(user);
        //        return new SuccessResults();
        //    }

        //    public IResults Delete(User user)
        //    {
        //        _userDal.Delete(user);
        //        return new SuccessResults();
        //    }

        //    public IDataResults<List<OperationClaim>> GetClaims(User user)
        //    {
        //        _userDal.GetClaim(user);
        //        return new SuccessDataResults<List<OperationClaim>>();
        //    }

        //    public IDataResults<List<User>> GetAll()
        //    {
        //        return new SuccessDataResults<List<User>>(_userDal.GetAll());
        //    }

        //    public IResults Update(User user)
        //    {
        //        _userDal.Update(user);
        //        return new SuccessResults();
        //    }


        //    public IResults GetEmail(string email)
        //    {
        //        _userDal.Get(p => p.Email == email);
        //        return new SuccessResults();
        //    }
        //}
        public List<OperationClaim> GetClaims(User user)
        {
           return _userDal.GetClaim(user);
        }

        public void Add(User user)
        {
             _userDal.Add(user);
        }

        public User GetByMail(string email)
        {
            return _userDal.Get(u => u.Email == email);
        }
    }
}