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
    [Route("api/customers/{customerId:int}/[controller]")]
    [ApiController]
    public class MovesController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<Move> Get([FromRoute] int customerId)
        {
            return CustomerRepository.GetAllMoves(customerId);
        }
        [HttpPost]
        public IActionResult Post([FromRoute] int customerId, [FromBody] Move move)
        {
            CustomerRepository.AddMove(customerId, move);
            return new CreatedAtRouteResult(Routes.GetCustomer, new {id = customerId}, null);
        }
    }

    public static  class Routes
    {
        public const string GetCustomer = "CUSTOMER";
    }
}
