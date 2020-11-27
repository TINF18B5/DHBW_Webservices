using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CustomerDemo.Model;
using CustomerDemo.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CustomerDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        [HttpGet(Name = "CUSTOMERS")]
        public IEnumerable<Customer> Get()
        {
            var customers = CustomerRepository.GetAll();
            return customers;
        }

        [HttpGet("{id}", Name = Routes.GetCustomer)]
        public ActionResult<Customer> Get(int id)
        {
            try
            {
                var customer = CustomerRepository.Get(id);
                return new OkObjectResult(customer);
            }
            catch (KeyNotFoundException)
            {
                return new NotFoundResult();
            }
        }

        [HttpPost]
        public ActionResult Post([FromBody] Customer value)
        {
            var customerId = CustomerRepository.Add(value);

            return new CreatedAtRouteResult("CUSTOMER", new { id = customerId }, null);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            CustomerRepository.Delete(id);
        }
    }
}
