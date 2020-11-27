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
    public class FavoriteCustomersController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<Customer> Get()
        {
            return CustomerRepository.GetAllFavorites();
        }

        [HttpPost]
        public IActionResult Post([FromBody] FavoriteCustomer favoriteCustomer)
        {
            var customer = CustomerRepository.Get(favoriteCustomer.CustomerId);
            //Business Logic goes here
            //Technisches Layer
            customer.IsFavorite = true;
            CustomerRepository.Update(customer);
            return new CreatedAtRouteResult(Routes.GetCustomer, new { id = customerId }, null);
        }
    }
}
