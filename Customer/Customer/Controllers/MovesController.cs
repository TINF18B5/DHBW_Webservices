using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Customer.Model;
using Microsoft.AspNetCore.Routing;

namespace Customer.Controllers
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
            return new CreatedAtRouteResult(Routes.Customer, new {Id = customerId}, null);
        }
    }

    public class Move
    {
        public int Id { get; set; }
        public string Street { get; set; }
        public string ZipCode { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
    }
}
