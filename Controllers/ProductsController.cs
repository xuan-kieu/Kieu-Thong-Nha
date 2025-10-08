
using Microsoft.AspNetCore.Mvc;
using ProductApi.Models;
using ProductApi.Services;

namespace ProductApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        // GET: /api/products
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(ProductService.GetAll());
        }

        // GET: /api/products/{id}
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var product = ProductService.GetById(id);
            if (product == null) return NotFound();
            return Ok(product);
        }

        // POST: /api/products
        [HttpPost]
        public IActionResult Create(Product product)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            ProductService.Add(product);
            return CreatedAtAction(nameof(GetById), new { id = product.Id }, product);
        }

        // PUT: /api/products/{id}
        [HttpPut("{id}")]
        public IActionResult Update(int id, Product product)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = ProductService.Update(id, product);
            if (!result) return NotFound();
            return NoContent();
        }

        // DELETE: /api/products/{id}
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var result = ProductService.Delete(id);
            if (!result) return NotFound();
            return NoContent();
        }

        // BONUS: GET /api/products/searchname=abc
        [HttpGet("search")]
        public IActionResult SearchByName([FromQuery] string name)
        {
            var results = ProductService.SearchByName(name);
            return Ok(results);
        }
    }
}