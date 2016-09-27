using CustomerWeb.Models;
using System.Collections.Generic;

namespace CustomerWeb.Services
{
    public interface ICustomerOrderService
    {
        IEnumerable<CustomerOrder> GetCustomerOrders();
    }
}