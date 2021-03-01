using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;
        public InMemoryCarDal()
        {
            _cars = new List<Car> {
                new Car{ Id=1 ,BrandId=1, ColorId=1, ModelYear =2015, DailyPrice= 1500, Description= "Volkswagen" },
                new Car{ Id=2 ,BrandId=2, ColorId=1, ModelYear =2013, DailyPrice= 1000, Description= "Opel" },
                new Car{ Id=3 ,BrandId=3, ColorId=3, ModelYear =2016, DailyPrice= 1250, Description= "Renault" },
                new Car{ Id=4 ,BrandId=4, ColorId=4, ModelYear =2017, DailyPrice= 1300, Description= "Toyota" },
                new Car{ Id=5 ,BrandId=5, ColorId=2, ModelYear =2020, DailyPrice= 2000, Description= "Mercedes" }


            };
        }
        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete = _cars.SingleOrDefault(p => p.Id == car.Id);
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetById(Car car)
        {
            return _cars.Where(c => c.Id == car.Id).ToList();
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(c => c.Id == car.Id);
            carToUpdate.Id = car.Id;
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;
            carToUpdate.ModelYear = car.ModelYear;
        }
    }
}
