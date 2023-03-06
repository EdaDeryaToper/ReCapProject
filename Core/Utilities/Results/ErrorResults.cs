using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class ErrorResults:Results
    {
        public ErrorResults(string message) : base(false,message)
        {

        }
        public ErrorResults() : base(false)
        {

        }
    }
}
