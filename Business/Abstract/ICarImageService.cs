using System;
using System.Collections.Generic;
using System.Text;
using Core.Utilities.Results;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;

namespace Business.Abstract
{
    public interface ICarImageService
    {
        IDataResults<List<CarImage>> GetAll();
        IDataResults<List<CarImage>> GetById(int carid);
        IResults Add(IFormFile file, CarImage carImage);
        IResults Update(IFormFile file, CarImage carImage);
        IResults Delete(CarImage carImage);

    } 
    
}
