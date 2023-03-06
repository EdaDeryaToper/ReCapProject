using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public interface IResults
    {
        bool Success { get; }
        string Message { get; }
    }
}
