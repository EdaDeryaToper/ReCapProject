using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public interface IDataResults<T>:IResults
    {
        T Data { get; }
    }
}
