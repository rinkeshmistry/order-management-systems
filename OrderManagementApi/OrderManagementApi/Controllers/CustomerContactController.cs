using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderManagementApi.Entities.Modules.Customer;
using OrderManagementApi.Repostories.Classes;
using OrderManagementApi.Repostories.Interfaces;

namespace OrderManagementApi.Controllers
{
    public class CustomerContactController : BaseController
    {
        #region
        private readonly ICustomerContactRepository _customerContactRepository;
        #endregion

        public CustomerContactController(ICustomerContactRepository pCustomerContactRepository)
        {
            this._customerContactRepository = pCustomerContactRepository;
        }

        [HttpGet]
        [Route("Get")]
        public IActionResult Get()
        {
            var customerContacts = _customerContactRepository.GetAll();
            return Ok(customerContacts);
        }

        [HttpPost]
        public IActionResult Post([FromBody] CustomerContact model)
        {
            model = this._customerContactRepository.Create(model);
            return Created("", model);
        }

        [HttpPut]
        public IActionResult Put([FromBody] CustomerContact model)
        {
            if (!_customerContactRepository.Get().Any(i => i.Id == model.Id))
            {
                return NoContent();
            }
            model = this._customerContactRepository.Update(model);
            return Ok(model);
        }

        [HttpDelete]
        [Route("{Id}")]
        public IActionResult Delete(int Id)
        {
            var existingCustomer = _customerContactRepository.Get().Where(i => i.Id == Id).FirstOrDefault();
            if (existingCustomer == null)
            {
                return NoContent();
            }
            this._customerContactRepository.Delete(existingCustomer);
            return Ok();
        }
    }
}
