using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Customer.Model;

namespace Customer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FavoriteCustomersController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<Model.Customer> Get()
        {
            return CustomerRepository.GetAllFavorites();
        }
        [HttpPost]
        public IActionResult SetFavorite([FromBody] FavoriteCustomer favorite)
        {
            try
            {
                var customer = CustomerRepository.Get(favorite.CustomerId);
                customer.IsFavorite = true;
                CustomerRepository.Update(customer);
                return new OkResult();

            }
            catch (Exception e)
            {
                return new NotFoundResult();
            }

        }

        [HttpDelete]
        public IActionResult UnsetFavorite([FromBody] FavoriteCustomer notFavorite)
        {
            try
            {
                var customer = CustomerRepository.Get(notFavorite.CustomerId);
                customer.IsFavorite = false;
                CustomerRepository.Update(customer);
                return new OkResult();

            }
            catch (Exception e)
            {
                return new NotFoundResult();
            }

        }

    }

    public class FavoriteCustomer
    {
        public int CustomerId { get; set; }
    }
}
