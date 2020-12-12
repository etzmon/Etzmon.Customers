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

        [HttpGet]
        public IActionResult List()
        {
            List<Customer> data = new List<Customer>();
            var reader = _config.Query<Customer>("GetAllCustomers",
                    commandType: CommandType.StoredProcedure);

            data = reader.ToList();

            return View(data);
        }

        [HttpPost]
        public IActionResult Insert([FromBody] Customer customer)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@CustomerID", customer.CustomerID);
            parameters.Add("@LastName", customer.LastName);
            parameters.Add("@FirstName", customer.FirstName);
            parameters.Add("@Phone", customer.Phone);
            
            

            int count = _config.Execute("InsertByCustomer",
                parameters,
                commandType: CommandType.StoredProcedure);

            //int trainingID = parameters.Get<int>("@CustomerID");    
            return View(customer);

        }
    }
}
