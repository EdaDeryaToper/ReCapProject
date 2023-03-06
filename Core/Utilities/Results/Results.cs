using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class Results : IResults
    {
        public Results(bool success,string message) : this(success)
        {
            Message = message;
        }

        public Results(bool success)
        {
            Success = success;
        }
        public bool Success { get; }

        public string Message { get; }
    }
}
