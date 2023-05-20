using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderManagementApi.Entities.Modules.Customer;
using OrderManagementApi.Entities.Modules.Order;
using OrderManagementApi.Repostories.Interfaces;

namespace OrderManagementApi.Controllers
{
    public class OrderController : BaseController
    {

        #region Object Declarations
        private readonly IOrderRepository _orderRepository;
        #endregion

        public OrderController(IOrderRepository pOrderRepository)
        {
            this._orderRepository = pOrderRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var orders = _orderRepository.GetAll();
            return Ok(orders);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Order model)
        {
            model = this._orderRepository.Create(model);
            return Created("", model);
        }
    }
}
