using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Security.Hashing
{
    public class HashingHelper
    {
        //password hash ve salt oluşturacak yapı. hmac ile
        public static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                
                passwordSalt = hmac.Key; 
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password)); 
            }
        }

        //sonradan girilen password ile hash uyumluluğuna bakılacak yapı //passwordhash doğrulama
        public static bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != passwordHash[i])
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}
