using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderManagementApi.Entities.Modules.Customer;
using OrderManagementApi.Repostories.Classes;
using OrderManagementApi.Repostories.Interfaces;
using System.Linq;

namespace OrderManagementApi.Controllers
{
    public class CustomerController : BaseController
    {
        #region Object Declarations
        private readonly ICustomerRepository _customerRepository;
        #endregion

        public CustomerController(ICustomerRepository pCustomerRepository)
        {
            this._customerRepository = pCustomerRepository;
        }

        [HttpGet]
        [Route("Get")]
        public IActionResult Get()
        {
            var customers = _customerRepository.GetAll();
            return Ok(customers);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Customer model)
        {
            model = this._customerRepository.Create(model);
            return Created("", model);
        }

        [HttpPut]
        public IActionResult Put([FromBody] Customer model)
        {
            if (!_customerRepository.Get().Any(i => i.Id == model.Id))
            {
                return NoContent();
            }
            model = this._customerRepository.Update(model);
            return Ok(model);
        }

        [HttpDelete]
        [Route("{Id}")]
        public IActionResult Delete(int Id)
        {
            var existingCustomer = _customerRepository.Get().Where(i => i.Id == Id).FirstOrDefault();
            if (existingCustomer == null)
            {
                return NoContent();
            }
            this._customerRepository.Delete(existingCustomer);
            return Ok();
        }
    }
}
