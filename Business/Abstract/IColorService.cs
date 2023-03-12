using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IColorService
    {
        IDataResults<List<Color>> GetAll();
        IResults Add(Color color);
        IResults Update(Color color);
        IResults Delete(Color color);
    }
}
