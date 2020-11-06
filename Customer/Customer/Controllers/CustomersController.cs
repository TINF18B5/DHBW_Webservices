using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
            var customers = new List<Model.Customer>();
            customers.Add(new Model.Customer() { Id = 1, Name = "Lukas Panni", Street = "LOL", City = "Odenheim", ZipCode = "76684" });
            customers.Add(new Model.Customer() { Id = 2, Name = "Test Person", Street = "Straße", City = "Bruchsal", ZipCode = "76646" });
            return customers;

        }
    }
}
