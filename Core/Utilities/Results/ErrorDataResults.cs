using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class ErrorDataResults<T>:DataResults<T>
    {
        public ErrorDataResults(T data, string message) : base(data, false, message)
        {

        }
        public ErrorDataResults(T data) : base(data, false)
        {

        }

        public ErrorDataResults(string message) : base(default, false, message)
        {

        }
        public ErrorDataResults() : base(default, false)
        {

        }
    }
}
