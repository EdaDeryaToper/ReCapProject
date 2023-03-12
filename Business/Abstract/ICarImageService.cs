using System;
using System.Collections.Generic;
using System.Text;
using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface ICarImageService
    {
        IDataResults<List<CarImage>> GetAll();
        IResults Add(CarImage carImage);
        IResults Update(CarImage carImage);
        IResults Delete(CarImage carImage);
    } 
    
}
