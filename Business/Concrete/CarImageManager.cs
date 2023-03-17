using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Business.Abstract;
using Business.Constants;
using Core.Utilities.Business;
using Core.Utilities.Helpers.FileHelper;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        ICarImageDal _carImageDal;
        IFileHelper _fileHelper;

        public CarImageManager(ICarImageDal carImageDal, IFileHelper fileHelper)
        {
            _carImageDal = carImageDal;
            _fileHelper = fileHelper;
        }
        public IDataResults<List<CarImage>> GetAll()
        {
            return new SuccessDataResults<List<CarImage>>(_carImageDal.GetAll());
        }

        public IResults Add(IFormFile file, CarImage carImage)
        {

            IResults results = BusinessRules.Run(CheckCarImageLimit(carImage.CarId), CheckImageDefault(carImage.CarImageId));
            if (results!=null)
            {
                return results;
            }

            carImage.ImagePath = _fileHelper.Upload(file, FilePath.ImagesPath);
            carImage.Dates = DateTime.Now;
            _carImageDal.Add(carImage);
            return new SuccessResults(Messages.CarImageAdded);
        }

        public IResults Update(IFormFile file, CarImage carImage)
        {
            carImage.ImagePath = _fileHelper.Update(file, FilePath.ImagesPath + carImage.ImagePath, FilePath.ImagesPath);
            _carImageDal.Update(carImage);
            return new SuccessResults();
        }

        public IResults Delete(CarImage carImage)
        {
            _fileHelper.Delete(FilePath.ImagesPath + carImage.ImagePath);
            _carImageDal.Delete(carImage);
            return new SuccessResults();
        }

        public IDataResults<List<CarImage>> GetById(int carid)
        {
            
            return new SuccessDataResults<List<CarImage>>(_carImageDal.GetAll(p => p.CarId == carid));
        }


        private IResults CheckCarImageLimit(int carid)
        {
            var result = _carImageDal.GetAll(p => p.CarId==carid).Count;
            if (result>5)
            {
                return new ErrorResults(Messages.CarImageExceed);
            }

            return new SuccessResults();
        }

        private IResults CheckImageDefault(int carId)
        {
            string carImagePath = null;
            var result = _carImageDal.GetAll(p => p.CarId == carId).Any(p => p.ImagePath == carImagePath);
            if (result)
            {
                return new ErrorResults(Messages.DefaultImage);
            }
            return new SuccessResults();
        }
        
        //public IResults Upload(CarImage carImage,string imagePath)
        //{
        //    imagePath = @"C:\Resimler\eda.jpg"; 
        //    string saveDirectory = @"C:\Users\eda_t\source\repos\EnginDemirog\ReCapProject\Business\Images\UploadedImages\"; 

        //    Guid guid = Guid.NewGuid();
        //    string newFileName = guid.ToString() + Path.GetExtension(imagePath);
        //    string savePath = Path.Combine(saveDirectory, newFileName);
        //    File.Copy(imagePath, savePath);
        //    carImage.ImagePath = newFileName;
        //    if (File.Exists(savePath))
        //    {
        //        return new ErrorResults(Messages.ImagePathError);
        //    }
        //    _carImageDal.Add(carImage);
        //    return new SuccessResults();
        //}


    }
}
