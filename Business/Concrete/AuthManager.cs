using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using Business.Constants;
using Core.Entities.Concrete;
using Core.Utilities.Security.Hashing;
using Core.Utilities.Results;
using Core.Utilities.Security.Jwt;
using Entities.DTOs;

namespace Business.Concrete
{
    public class AuthManager:IAuthService
    {
        private IUserService _userService;
        private ITokenHelper _tokenHelper;

        public AuthManager(IUserService userService, ITokenHelper tokenHelper)
        {
            _userService = userService;
            _tokenHelper = tokenHelper;
        }
        public IDataResults<User> Register(UserRegisterDto userForRegisterDto, string password)
        {
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(password, out passwordHash, out passwordSalt);
            var user = new User
            {
                Email = userForRegisterDto.Email,
                FirstName = userForRegisterDto.FirstName,
                LastName = userForRegisterDto.LastName,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Status = true
            };
            _userService.Add(user);
            return new SuccessDataResults<User>(user, Messages.UserRegistered);
        }

        public IDataResults<User> Login(UserLoginDto userForLoginDto)
        {
            var userToCheck = _userService.GetByMail(userForLoginDto.Email);
            if (userToCheck == null)
            {
                return new ErrorDataResults<User>(Messages.UserNotFound);
            }

            if (!HashingHelper.VerifyPasswordHash(userForLoginDto.Password, userToCheck.PasswordHash, userToCheck.PasswordSalt))
            {
                return new ErrorDataResults<User>(Messages.PasswordError);
            }

            return new SuccessDataResults<User>(userToCheck, Messages.SuccessfulLogin);
        }
        
        public IResults UserExists(string email)
        {
            if(_userService.GetByMail(email) != null)
            {
                return new ErrorResults(Messages.UserAlreadyExists);
            }
            return new SuccessResults();
        }
        
        public IDataResults<AccessToken> CreateAccessToken(User user)
        {
            var claims = _userService.GetClaims(user);
            var accessToken = _tokenHelper.CreateToken(user, claims);
            return new SuccessDataResults<AccessToken>(accessToken, Messages.AccessTokenCreated);
        }
    }
}
