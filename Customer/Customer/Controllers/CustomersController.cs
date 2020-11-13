using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Customer.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Customer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {

        [HttpGet]
        public IEnumerable<Model.Customer> Get()
        {
            return CustomerRepository.GetAll();

        }
        [HttpGet("{id}", Name = "CUSTOMER")]
        public ActionResult<Model.Customer> Get(int id)
        {
            try
            {
                return new OkObjectResult(CustomerRepository.Get(id));
            }
            catch (Exception ex)
            {
                return new NotFoundResult();
            }
        }

        [HttpPost]
        public ActionResult Create([FromBody] Model.Customer customer)
        {
            int id = CustomerRepository.Add(customer);
            return new CreatedAtRouteResult("CUSTOMER", new { Id = id }, null);
        }

        [HttpDelete("{id}", Name = "id")]
        public ActionResult Delete(int id)
        {
            try
            {
                CustomerRepository.Delete(id);
                return new OkResult();
            }
            catch (Exception ex)
            {
                return new NotFoundResult();
            }
        }
    }
}
