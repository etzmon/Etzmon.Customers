using Dapper;
using Etzmon.Customers.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Etzmon.Customers.Web.Controllers
{
    public class CustomersController : Controller
    {
        private readonly IDbConnection _config;

        public CustomersController(IDbConnection config)
        {
            _config = config;
        }

        public IActionResult List()
        {
            List<Customer> data = new List<Customer>();
            var reader = _config.Query<Customer>("GetAllCustomers",
                    commandType: CommandType.StoredProcedure);

            data = reader.ToList();

            return View(data);
        }
    }
}
