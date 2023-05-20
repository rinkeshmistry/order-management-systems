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
    public class CustomerContactRepository : BaseRepository<CustomerContact>, ICustomerContactRepository
    {
        private readonly OrderManagementContext _orderManagementContext;
        public CustomerContactRepository(OrderManagementContext orderManagementContext) : base(orderManagementContext) { }
    }
}
