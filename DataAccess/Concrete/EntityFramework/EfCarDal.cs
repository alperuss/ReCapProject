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
    public class EfCarDal : EfEntityRepositoryBase<Car, DatabaseContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails()
        {
            using (DatabaseContext context = new DatabaseContext())
            {
                var result = from p in context.Cars
                             join b in context.Brands                           
                             on p.BrandId equals b.BrandId
                             join co in context.Colors
                             on p.ColorId equals co.ColorId
                             select new CarDetailDto { CarId = p.CarId,
                                 Description = p.Description,
                                 BrandName = b.BrandName,
                                 ColorName= co.ColorName,
                                 DailyPrice= p.DailyPrice };
                return result.ToList();
            }
        }
    }
}
