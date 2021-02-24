using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfBrandDal : IBrandDal
    {
        public List<Brand> GetAll(Expression<Func<Brand, bool>> filter = null)
        {
            using (ReCapDbContext dbContext = new ReCapDbContext())
            {
                return filter == null
                    ? dbContext.Set<Brand>().ToList()
                    : dbContext.Set<Brand>().Where(filter).ToList();
            }
        }

        public Brand GetById(Expression<Func<Brand, bool>> filter)
        {
            using (ReCapDbContext dbContext = new ReCapDbContext())
            {
                return dbContext.Set<Brand>().SingleOrDefault(filter);
            }
        }

        public void Add(Brand entity)
        {
            using (ReCapDbContext dbContext = new ReCapDbContext())
            {
                var addedEntity = dbContext.Entry(entity);
                addedEntity.State = EntityState.Added;
                dbContext.SaveChanges();
            }
        }

        public void Update(Brand entity)
        {
            using (ReCapDbContext dbContext = new ReCapDbContext())
            {
                var updatedEntity = dbContext.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                dbContext.SaveChanges();
            }
        }

        public void Delete(Brand entity)
        {
            using (ReCapDbContext dbContext = new ReCapDbContext())
            {
                var deletedEntity = dbContext.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                dbContext.SaveChanges();
            }
        }
    }
}
