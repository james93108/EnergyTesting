using EnergyTest.DataContext;
using EnergyTest.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace EnergyTest.Controllers
{
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private CustomerDbContext _context;

        public CustomerController(CustomerDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("api/[controller]")]
        public ActionResult GetCustomers()
        {
            var customers = _context.Customers.ToList();
            return Ok(customers);
        }

        // Get a customer
        [HttpGet]
        [Route("api/[controller]/{id}")]
        public ActionResult GetCustomer(int id)
        {
            var customer = _context.Customers.FirstOrDefault(x => x.Id == id);
            if (customer != null)
            {
                return Ok(customer);
            }
            return NotFound();
        }

        [HttpPost]
        [Route("api/[controller]")]
        public ActionResult AddCustomer(Customer customer)
        {
            _context.Customers.Add(customer);
            return Ok(customer);
        }

        // Edit a customer
        [HttpPost]
        [Route("api/[controller]/{id}")]
        public ActionResult EditCustomer(int id, Customer customerNew)
        {
            var customer = _context.Customers.FirstOrDefault(x => x.Id == id);
            if (customer != null)
            {
                _context.Customers.Remove(customer);
                customer.FirstName = customerNew.FirstName;
                customer.LastName = customerNew.LastName;
                customer.DateofBirth = customerNew.DateofBirth;
                _context.Customers.Add(customer);
            }
            return Ok(customerNew);
        }

        // Delete a customer
        [HttpDelete]
        [Route("api/[controller]/{id}")]
        public ActionResult DeleteCustomer(int id)
        {
            var customer = _context.Customers.FirstOrDefault(x => x.Id == id);
            if (customer != null)
            {
                _context.Customers.Remove(customer);
                return Ok(customer);
            }
            return NotFound();
        }

        // Search a customer
        [HttpPost]
        [Route("api/[controller]/search/{name}")]
        public ActionResult SearchCustomer(string name)
        {
            var customers = _context.Customers.Where(x => x.FirstName == name || x.LastName == name);
            if (customers != null)
            {
                return Ok(customers.ToList());
            }
            return NotFound();
        }
    }
}
