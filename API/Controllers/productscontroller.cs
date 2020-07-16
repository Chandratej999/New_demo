using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class productscontroller : ControllerBase
    {
        private readonly DataContext _context;
        public productscontroller(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Products>>> GetProducts() // Asyncronouse running and no need to wait till the result, thread entity
        {
           var products = await _context.products.ToListAsync(); // Core entity

           return Ok(products);

        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Products>> GetProduct(int id)
        {

            return await _context.products.FindAsync(id);
        }

    }
}