using GS1.Core.DTOs;
using GS1.Core.Entities;
using GS1.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GS1.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly GS1DbContext _context;

        public ProductController(GS1DbContext context)
        {
            _context = context;
        }

       
        [HttpPost]
        public async Task<ActionResult<ProductDto>> CreateProduct(ProductDto productDto)
        {
            var product = new Product
            {
                Name = productDto.Name,
                GTIN = productDto.GTIN, 
                CustomerId = productDto.CustomerId 
            };

            _context.Products.Add(product);
            await _context.SaveChangesAsync();

            productDto.Id = product.Id;
            return Ok(productDto);
        }

       
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDto>>> GetProducts()
        {
            var products = await _context.Products.Select(p => new ProductDto
            {
                Id = p.Id,
                Name = p.Name,
                GTIN = p.GTIN,
                CustomerId = p.CustomerId
            }).ToListAsync();

            return Ok(products);
        }
    }
}