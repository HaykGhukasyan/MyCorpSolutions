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
    public class OrderController : ApiController
    {
        // GET: api/Order
        public IEnumerable<Order> Get()
        {
            try
            {
                var database = Database.OpenNamedConnection("MyCorpSolutionsDatabase");            
                var orders = new List<Order>();

                    var ordersData = database.Order
                        .All()
                        .Select(
                        database.Order.Id,
                        database.Order.CustomerId,
                        database.Order.OrderItem);

                    foreach (var order in ordersData)
                    {
                        orders.Add(
                            new Order
                            {
                                Id = order.Id,
                                CustomerId = order.CustomerId,
                                OrderItem = order.OrderItem
                            });
                    }

                    return orders;
                
            }
            catch (Exception)
            {
                throw;
            }
        }

        // GET: api/Order/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Order
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Order/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Order/5
        public void Delete(int id)
        {
        }
    }
}
