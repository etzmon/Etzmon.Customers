using Etzmon.Customers.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace Etzmon.Customers.Web.Controllers
{
    public class CustomersController : Controller
    {
        public IActionResult List()
        {
            Customer customer = new Customer();
            customer.FirstName = "Javier";
            return View(customer);
        }
    }
}
