using GS1.Core.DTOs;
using GS1.Core.Entities;
using GS1.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GS1.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly GS1DbContext _context;

        public CustomerController(GS1DbContext context)
        {
            _context = context;
        }

        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CustomerDto>>> GetCustomers()
        {
            // Veritabanından çekip DTO'ya çeviriyoruz (Mapping)
            var customers = await _context.Customers
                .Select(c => new CustomerDto
                {
                    Id = c.Id,
                    Name = c.Name,
                    GLN = c.GLN,
                    Description = c.Description
                })
                .ToListAsync();

            return Ok(customers);
        }

       
        [HttpPost]
        public async Task<ActionResult<CustomerDto>> CreateCustomer(CustomerDto customerDto)
        {
            // DTO'dan Entity'ye çevir (Ters paketleme)
            var customer = new Customer
            {
                Name = customerDto.Name,
                GLN = customerDto.GLN,
                Description = customerDto.Description
            };

            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();

            
            customerDto.Id = customer.Id;

            return CreatedAtAction(nameof(GetCustomers), new { id = customer.Id }, customerDto);
        }
    }
}