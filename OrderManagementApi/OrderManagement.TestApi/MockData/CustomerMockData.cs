using OrderManagementApi.Entities.Modules.Customer;
using OrderManagementApi.Entities.Modules.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagement.TestApi.MockData
{
    public class CustomerMockData
    {
        public static List<Customer> CustomerData = new List<Customer>()
        {
            new Customer()
            {
                Id = 1,
                OrganizationName = "Wonka Industries",
                WebSiteUrl = "",
                CustomerContacts = new List<CustomerContact>(),
                Orders = new List<Order>()
            },
            new Customer()
            {
                Id = 2,
                OrganizationName = "Acme Corp",
                WebSiteUrl = "",
                CustomerContacts = new List<CustomerContact>(),
                Orders = new List<Order>()
            }
        };

    }
}
