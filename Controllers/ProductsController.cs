using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using HelloWorld.Data;
using HelloWorld.Models;
using HelloWorld.Dtos;

namespace HelloWorld.Controllers
{
    [ApiController]
    [Route("api/products")]
    public class ProductsController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public ProductsController(AppDbContext context, IMapper mapper) {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDto>>> GetAll() {
            var products = await _context.Products.Include(p => p.Category).ToListAsync();
            var productDtos = _mapper.Map<List<ProductDto>>(products);

            return Ok(productDtos);
        }
        
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetById(int id)
        {
            var product = await _context.Products.Include(p => p.Category).FirstOrDefaultAsync(); 
            if (product == null) return NotFound();

            var productDto = _mapper.Map<ProductDto>(product);
            return Ok(productDto);
        }

        [HttpPost]
        public async Task<ActionResult<Product>> Create(Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = product.Id }, product);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Product updatedProduct)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null) return NotFound();

            try
            {
                product.Name = updatedProduct.Name;
                product.Price = updatedProduct.Price;

                await _context.SaveChangesAsync();

                return NoContent();
            }
            catch (DbUpdateConcurrencyException)
            {
                return StatusCode(500, "A conncurent error eccoured.");
            }
            catch (Exception e)
            {
                return StatusCode(500, $"Unexpected error: {e.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null) return NotFound();

            _context.Products.Remove(product);
            await _context.SaveChangesAsync(); 

            return NoContent();
        }
    }
}