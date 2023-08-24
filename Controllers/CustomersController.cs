using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyApi.Models;
using MyApi.Persistence;
using MyApi.Resources;

namespace MyApi.Controllers
{
    [ApiController]
    [Route("api/customers")]
    public class CustomersController : Controller
    {
        public MyApiContext context { get; }
        private readonly IMapper mapper;

        public CustomersController(MyApiContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> CreateCustomer([FromBody] SaveCustomerResource customerResource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var customer = mapper.Map<SaveCustomerResource, Customer>(customerResource);
            await context.Customers.AddAsync(customer);
            await context.SaveChangesAsync();

            return Ok(customer);
        }
        [HttpGet]
        public async Task<IEnumerable<CustomerResource>> GetCustomers()
        {
            var customers = await context.Customers.Include(c => c.MembershipType).ToListAsync();
            return mapper.Map<IEnumerable<Customer>, IEnumerable<CustomerResource>>(customers);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCustomer(int id)
        {
            var customer = await context.Customers.Include(c => c.MembershipType).SingleOrDefaultAsync(c => c.Id == id);
            if (customer == null)
            {
                return NotFound();
            }
            var customerResource = mapper.Map<Customer, CustomerResource>(customer);
            return Ok(customerResource);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCustomer(int id, [FromBody] SaveCustomerResource customerResource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var customer = await context.Customers.FindAsync(id);
            if (customer == null)
            {
                return NotFound();
            }
            customer.Age = customerResource.Age;
            customer.Name = customerResource.Name;
            customer.MembershipTypeId = customerResource.MembershipTypeId;

            await context.SaveChangesAsync();
            return Ok(customer);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            var customer = await context.Customers.FindAsync(id);
            if (customer == null)
            {
                return NotFound();
            }
            context.Customers.Remove(customer);
            await context.SaveChangesAsync();
            return Ok(id);
        }
    }
}