using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, RecapContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails()
        {
            using (RecapContext context = new RecapContext())
            {
                var result = from p in context.Cars
                             join b in context.Brands
                             on p.BrandId equals b.BrandId
                             join c in context.Colors
                             on p.ColorId equals c.ColorId
                             select new CarDetailDto 
                             {
                                 CarId=p.CarId,
                                 BrandId=b.BrandId,
                                 ColorId=c.ColorId,
                                 BrandName=b.BrandName,
                                 ColorName=c.ColorName,
                                 CarName=p.CarName,
                                 DailyPrice=p.DailyPrice
                             };
                return result.ToList();         
                            
            }
        }
    }
}
