using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Customer.Hypermedia;
using Customer.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Customer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {

        [HttpGet(Name = Routes.GetCustomers)]
        public Siren Get()
        {
            var customers = CustomerRepository.GetAll();
            var siren = new Siren();
            siren.Class.Add("CustomersAPI");
            siren.Class.Add("Collection");
            foreach (var customer in customers)
            {
                var customerEntity = new EmbeddedRepresentation();
                customerEntity.Class.Add("CustomerOverview");
                customerEntity.Properties.Add(new Property { Name = "Name", Value = customer.Name });
                customerEntity.Properties.Add(new Property { Name = "City", Value = customer.City });
                customerEntity.Properties.Add(new Property { Name = "Country", Value = customer.Country });
                customerEntity.Relation.Add("CustomerOverview");
                customerEntity.Links.Add(new Link()
                {
                    Relation = new List<string>() { "self" },
                    Href = Url.Link(Routes.GetCustomer, new { id = customer.Id })
                });
                siren.Entities.Add(customerEntity);
            }
            siren.Links.Add(new Link()
            {
                Relation = new List<string>() { "self" },
                Href = Url.Link(Routes.GetCustomers, null)
            });

            return siren;
        }
        [HttpGet("{id}", Name = Routes.GetCustomer)]
        public ActionResult<Siren> Get(int id)
        {
            try
            {
                var customer = CustomerRepository.Get(id);
                var siren = new Siren();

                siren.Class.Add("GetCustomer");
                siren.Properties.Add(new Property { Name = "Id", Value = customer.Id });
                siren.Properties.Add(new Property { Name = "Name", Value = customer.Name });
                siren.Properties.Add(new Property { Name = "City", Value = customer.City });
                siren.Properties.Add(new Property { Name = "Country", Value = customer.Country });
                siren.Properties.Add(new Property { Name = "ZipCode", Value = customer.ZipCode });
                siren.Properties.Add(new Property { Name = "Street", Value = customer.Street });
                siren.Properties.Add(new Property { Name = "IsFavorite", Value = customer.IsFavorite });

                siren.Links.Add(new Link()
                {
                    Relation = new List<string>() { "self" },
                    Href = Url.Link(Routes.GetCustomer, new { id = customer.Id })
                });
                if (!customer.IsFavorite)
                {
                    siren.Actions.Add(new Hypermedia.Action()
                    {
                        Name = "MarkAsFavorite",
                        Method = "POST",
                        Type = "FavoriteCustomer",
                        Href = Url.Link(Routes.MarkFavorite, null)
                    });
                }
                else
                {
                    siren.Actions.Add(new Hypermedia.Action()
                    {
                        Name = "UnMarkAsFavorite",
                        Method = "DELETE",
                        Type = "FavoriteCustomer",
                        Href = Url.Link(Routes.MarkFavorite, null)
                    });
                }

                return new OkObjectResult(siren);
            }
            catch (Exception)
            {
                return new NotFoundResult();
            }
        }

        [HttpPost]
        public ActionResult Create([FromBody] Model.Customer customer)
        {
            int id = CustomerRepository.Add(customer);
            return new CreatedAtRouteResult(Routes.GetCustomer, new { Id = id }, null);
        }

        [HttpDelete("{id}", Name = "id")]
        public ActionResult Delete(int id)
        {
            try
            {
                CustomerRepository.Delete(id);
                return new OkResult();
            }
            catch (Exception)
            {
                return new NotFoundResult();
            }
        }
    }
}
