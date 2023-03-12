using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class ColorManager : IColorService
    {
        IColorDal _colorDal;

        public ColorManager(IColorDal colorDal)
        {
            _colorDal = colorDal;
        }

        

        public IDataResults<List<Color>> GetAll()
        {
            return new SuccessDataResults<List<Color>>(_colorDal.GetAll());
        }

        public IResults Add(Color color)
        {
            _colorDal.Add(color);
            return new SuccessResults();
        }

        public IResults Update(Color color)
        {
            _colorDal.Update(color);
            return new SuccessResults();
        }

        public IResults Delete(Color color)
        {
            _colorDal.Delete(color);
            return new SuccessResults();
        }
    }
}
