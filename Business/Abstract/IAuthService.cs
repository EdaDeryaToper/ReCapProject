using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities.Concrete;
using Core.Utilities.Security.Jwt;
using Entities.DTOs;
using Core.Utilities.Results;

namespace Business.Abstract
{
    public interface IAuthService
    {
        IDataResults<User> Register(UserRegisterDto userForRegisterDto, string password);
        IDataResults<User> Login(UserLoginDto userForLoginDto);
        IResults UserExists(string email);
        IDataResults<AccessToken> CreateAccessToken(User user);
    }
}
