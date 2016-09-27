using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CustomerWeb.Models;
using System.Net.Http;
using CustomerWeb.Properties;
using System.Web.Helpers;
using CustomerDomain.Models;

namespace CustomerWeb.Services
{
    public class CustomerOrderService : ICustomerOrderService
    {
        string customersUrl = Settings.Default.CustomerServiceEndpoint + Settings.Default.CustomerUrl;
        string ordersUrl = Settings.Default.CustomerServiceEndpoint + Settings.Default.OrderUrl;

        public IEnumerable<CustomerOrder> GetCustomerOrders()
        {
            var customers = GetCustomers();
            var orders = GetOrders();

            return customers.Join(
                orders,
                c => c.Id,
                o => o.CustomerId,
                (c, o) => new CustomerOrder
                {
                    FirstName = c.FirstName,
                    LastName = c.LastName,
                    OrderItem = o.OrderItem
                });
        }

        private IEnumerable<Order> GetOrders()
        {
            var responseString = new HttpClient().GetStringAsync(ordersUrl).Result;
            return Json.Decode<Order[]>(responseString);
        }

        private IEnumerable<Customer> GetCustomers()
        {
            var responseString = new HttpClient().GetStringAsync(customersUrl).Result;
            return Json.Decode<Customer[]>(responseString);
        }
    }
}