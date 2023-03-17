using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarService
    {
        IDataResults<List<Car>> GetAll();
        IDataResults<List<Car>> GetCarsByBrandId(int id);
        IDataResults<List<Car>> GetCarsByColorId(int id);
        IResults Add(Car car);
        IResults Update(Car car);
        IResults Delete(Car car);
        IDataResults<List<CarDetailDto>> GetCarDetails();

        IResults AddTransactionalTest(Car car);

    }
}
