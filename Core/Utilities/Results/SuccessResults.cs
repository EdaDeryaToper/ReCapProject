using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class SuccessResults:Results
    {
        public SuccessResults(string message):base(true,message)
        {
            
        }
        public SuccessResults():base(true)
        {
           
        }
    }
}
