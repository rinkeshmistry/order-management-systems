using Microsoft.Extensions.DependencyInjection;
using OrderManagementApi.Entities;
using OrderManagementApi.Repostories.Classes;
using OrderManagementApi.Repostories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.ModelBinding;

namespace OrderManagementApi.Common.ExtentionMethods
{
    public static class RegisterProjectDependencies
    {
        public static void RegisterServiceDependencies(this IServiceCollection services)
        {
            services.AddSingleton<OrderManagementContext>();
            services.AddSingleton<ICustomerRepository, CustomerRepository>();
            services.AddSingleton<ICustomerContactRepository, CustomerContactRepository>();
            services.AddSingleton<IOrderRepository, OrderRepository>();
        }
    }
}
