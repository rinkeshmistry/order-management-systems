using OrderManagementApi.Entities;
using OrderManagementApi.Entities.Modules.Customer;
using OrderManagementApi.Repostories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagementApi.Repostories.Classes
{
    public class CustomerRepository : BaseRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository(OrderManagementContext pOrderManagementContext) : base(pOrderManagementContext)
        {
        }
    }
}
