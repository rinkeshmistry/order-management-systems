using Microsoft.EntityFrameworkCore;
using OrderManagementApi.Entities;
using OrderManagementApi.Repostories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagementApi.Repostories.Classes
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly OrderManagementContext orderManagementContext;
        public BaseRepository(OrderManagementContext pOrderManagementContext)
        {
            this.orderManagementContext = pOrderManagementContext;
        }

        public T Create(T entity)
        {
            try
            {
                this.orderManagementContext.Add<T>(entity);
                this.orderManagementContext.SaveChanges();
                return entity;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public T Delete(T entity)
        {
            try
            {
                this.orderManagementContext.Remove<T>(entity);
                this.orderManagementContext.SaveChanges();
                return entity;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<T> GetAll()
        {
            try
            {
                return this.orderManagementContext.Set<T>().ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public T Update(T entity)
        {
            try
            {
                this.orderManagementContext.Entry<T>(entity).State = EntityState.Modified;
                this.orderManagementContext.SaveChanges();
                return entity;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IQueryable<T> Get()
        {
            return this.orderManagementContext.Set<T>().AsQueryable();
        }
    }
}
