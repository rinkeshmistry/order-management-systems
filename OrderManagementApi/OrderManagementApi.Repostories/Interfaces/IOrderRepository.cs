using OrderManagementApi.Entities.Modules.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagementApi.Repostories.Interfaces
{
    public interface IOrderRepository : IBaseRepository<Order>
    {
        new Order Create(Order entity);
        new IEnumerable<Order> GetAll();
    }
}
