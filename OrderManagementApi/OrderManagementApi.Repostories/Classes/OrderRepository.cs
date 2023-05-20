using Microsoft.EntityFrameworkCore;
using OrderManagementApi.Entities;
using OrderManagementApi.Entities.Modules.Order;
using OrderManagementApi.Repostories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace OrderManagementApi.Repostories.Classes
{
    public class OrderRepository : BaseRepository<Order>, IOrderRepository
    {
        #region
        private readonly OrderManagementContext _orderManagementContext;
        #endregion
        public OrderRepository(OrderManagementContext pOrderManagementContext) : base(pOrderManagementContext)
        {
            this._orderManagementContext = pOrderManagementContext;
        }

        public new Order Create(Order entity)
        {
            using (var tran = new TransactionScope())
            {
                try
                {
                    // Logic to insert Order
                    this._orderManagementContext.Orders.Add(entity);
                    this._orderManagementContext.SaveChanges();

                    // Logic to inser Order Product
                    foreach (OrderProduct item in entity.OrderProducts)
                    {
                        item.OrderId = entity.Id;
                        item.Id = 0;
                    }
                    this._orderManagementContext.OrderProducts.AddRange(entity.OrderProducts);
                    this._orderManagementContext.ChangeTracker.Clear();
                    this._orderManagementContext.SaveChanges();

                    // Logic to commit the transaction
                    tran.Complete();

                    return entity;
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        public new IEnumerable<Order> GetAll()
        {
            return this._orderManagementContext.Orders.Include(p => p.OrderProducts).ToList();
        }
    }
}
