using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagementApi.Repostories.Interfaces
{
    public interface IBaseRepository<T>
    {
        IEnumerable<T> GetAll();
        T Create(T entity);
        T Update(T entity);
        T Delete(T entity);
        IQueryable<T> Get();
    }
}
