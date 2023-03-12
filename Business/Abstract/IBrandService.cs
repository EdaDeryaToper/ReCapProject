using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IBrandService
    {
        IDataResults<List<Brand>> GetAll();
        IResults Add(Brand brand);
        IResults Update(Brand brand);
        IResults Delete(Brand brand);
    }
}
