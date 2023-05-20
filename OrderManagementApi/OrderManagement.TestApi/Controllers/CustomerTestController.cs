using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using OrderManagement.TestApi.MockData;
using OrderManagementApi.Controllers;
using OrderManagementApi.Repostories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagement.TestApi.Controllers
{
    public class CustomerTestController
    {

        [Fact]
        public void Get_Sucess()
        {
            // Arrange
            var _customerRepository = new Mock<ICustomerRepository>();
            _customerRepository.Setup(_ => _.GetAll()).Returns(CustomerMockData.CustomerData);
            var sut = new CustomerController(_customerRepository.Object);

            // Act
            var result = sut.Get();

            //Assert
            result.GetType().Should().Be(typeof(OkObjectResult));
        }

    }
}
