using CustomerService.Models;
using Simple.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CustomerService.Controllers
{
    public class CustomerController : ApiController
    {
        // GET: api/Customer
        public IEnumerable<Customer> Get()
        {
            try
            {
                var database = Database.OpenNamedConnection("MyCorpSolutionsDatabase");            
                var customers = new List<Customer>();

                    var customersData = database.Customer
                        .All()
                        .Select(
                        database.Customer.Id,
                        database.Customer.FirstName,
                        database.Customer.LastName);

                    foreach (var customer in customersData)
                    {
                        customers.Add(
                            new Customer
                            {
                                Id = customer.Id,
                                FirstName = customer.FirstName,
                                LastName = customer.LastName
                            });
                    }

                    return customers;
                
            }
            catch (Exception)
            {
                throw;
            }
        }

        // GET: api/Customer/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Customer
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Customer/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Customer/5
        public void Delete(int id)
        {
        }
    }
}
