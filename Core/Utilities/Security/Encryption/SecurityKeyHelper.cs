﻿using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace Core.Utilities.Security.Encryption
{
    public class SecurityKeyHelper
    {
        public static SecurityKey CreateSecurityKey(string securityKey) //Microsoft.IdentityModel.Tokens
        {
            return new SymmetricSecurityKey(Encoding.UTF8.GetBytes(securityKey));//TokenOptions-SecurtyKey dönüştürülür: SymmetricSecurityKey
        }
    }
}
