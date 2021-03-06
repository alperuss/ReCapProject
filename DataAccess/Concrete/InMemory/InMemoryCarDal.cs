﻿using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;
        public InMemoryCarDal()
        {
            _cars = new List<Car> {
                new Car{ CarId=1 ,BrandId=1, ColorId=1, ModelYear =2015, DailyPrice= 1500, Description= "Volkswagen" },
                new Car{ CarId=2 ,BrandId=2, ColorId=1, ModelYear =2013, DailyPrice= 1000, Description= "Opel" },
                new Car{ CarId=3 ,BrandId=3, ColorId=3, ModelYear =2016, DailyPrice= 1250, Description= "Renault" },
                new Car{ CarId=4 ,BrandId=4, ColorId=4, ModelYear =2017, DailyPrice= 1300, Description= "Toyota" },
                new Car{ CarId=5 ,BrandId=5, ColorId=2, ModelYear =2020, DailyPrice= 2000, Description= "Mercedes" }


            };
        }
        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete = _cars.SingleOrDefault(p => p.CarId == car.CarId);
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetById(Car car)
        {
            return _cars.Where(c => c.CarId == car.CarId).ToList();
        }

        public List<CarDetailDto> GetCarDetails()
        {
            throw new NotImplementedException();
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(c => c.CarId == car.CarId);
            carToUpdate.CarId = car.CarId;
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;
            carToUpdate.ModelYear = car.ModelYear;
        }
    }
}
