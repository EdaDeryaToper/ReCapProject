﻿using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfBrandDal : IBrandDal
    {
        public void Add(Brand entity)
        {
            using (RecapContext context = new RecapContext())
            {
                var addEntity = context.Entry(entity);
                addEntity.State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public void Delete(Brand entity)
        {
            throw new NotImplementedException();
        }

       

        public List<Brand> GetAll(Expression<Func<Brand, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public void Update(Brand entity)
        {
            throw new NotImplementedException();
        }

        public Brand Get(Expression<Func<Brand, bool>> filter)
        {
            throw new NotImplementedException();
        }
    }
}