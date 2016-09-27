using CustomerWeb.Helpers;
using CustomerWeb.Models;
using CustomerWeb.Properties;
using CustomerWeb.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CustomerWeb.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Settings = Settings.Default;
            return View();
        }

        public ActionResult ExportAll()
        {
            var customerOrderService = new CustomerOrderService();
            var customerOrders = customerOrderService.GetCustomerOrders();
            var csvFormatter = new CsvFormatter<CustomerOrder>(",");
            var exportService = new CsvExportService<CustomerOrder>(csvFormatter);
            var exportStream = exportService.GetExportStream(customerOrders);

            return new FileStreamResult(exportStream, "text/csv")
            {
                FileDownloadName = "CustomerOrders.csv"
            };
        }
    }
}