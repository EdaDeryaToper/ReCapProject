using System;
using System.Collections.Generic;
using System.Text;
using Core.Utilities.Results;

namespace Core.Utilities.Business
{
    public class BusinessRules
    {
        public static IResults Run(params IResults[] args)
        {
            foreach (var arg in args)
            {
                if (!arg.Success)
                {
                    return arg;
                }
            }
            return null;
        }
    }
}
