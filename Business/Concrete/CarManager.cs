using Business.Abstract;
using Business.CCS;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;
        IColorService _colorService;

        public CarManager(ICarDal carDal,IColorService colorService)
        {
            _carDal = carDal;
            _colorService = colorService;
        }
        [ValidationAspect(typeof(CarValidator))]
        public IResult Add(Car car)
        {
            //bir markada en fazla 10 araba olabilir
            IResult result = BusinessRules.Run(CheckIfCarCountOfBrandCorrect(car.BrandId),CheckIfColorLimitExceded());
            if (result !=null)
            {
                return result;
            }
            _carDal.Add(car);
            return new SuccessResult(Messages.SuccessAdded);
            
          
            

            

        }

        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new SuccessResult(Messages.SuccessDeleted);
        }

        public IDataResult<List<Car>> GetAll()
        {
            //if (DateTime.Now.Hour==20)
            //{
            //    return new ErrorDataResult<List<Car>>(Messages.MaintenanceTime);
            //}
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(),Messages.SuccessListed);
        }

        public IDataResult<List<Car>> GetAllByBrandId(int id)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.BrandId == id));
        }

        public IDataResult<List<Car>> GetAllByColorId(int id)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.ColorId == id));
        }

        public IDataResult<Car> GetById(int carId)
        {
            return new SuccessDataResult<Car>(_carDal.Get(p=>p.CarId== carId),Messages.SuccessListed);
        }

        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            if (DateTime.Now.Hour == 18)
            {
                return new ErrorDataResult<List<CarDetailDto>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails());
        }

        public IResult Update(Car car)
        {
            _carDal.Update(car);
            return new SuccessResult(Messages.SuccessUpdated);
        }

        private IResult CheckIfCarCountOfBrandCorrect(int brandId)
        {
            var result = _carDal.GetAll(c => c.BrandId == brandId).Count;
            if (result >= 10)
            {
                return new ErrorResult(Messages.CarCountOfBrandError);
            }
            return new SuccessResult();
        }
        private IResult CheckIfColorLimitExceded()
        {
            var result = _colorService.GetAll();
            if (result.Data.Count>15)
            {
                return new ErrorResult(Messages.ColorLimitExceded);
            }
            return new SuccessResult();
        }

    }
}
