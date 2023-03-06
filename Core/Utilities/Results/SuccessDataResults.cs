using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class SuccessDataResults<T>: DataResults<T>
    {
        public SuccessDataResults(T data, string message): base(data,true,message)
        {

        }
        public SuccessDataResults(T data): base(data,true)
        {

        }

        public SuccessDataResults(string message) : base(default, true,message)
        {

        }
        public SuccessDataResults() : base(default, true)
        {

        }
    }
}
