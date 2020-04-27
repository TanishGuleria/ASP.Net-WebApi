using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ASP.NetWebApi.Model;
namespace ASP.NetWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LaptopController : ControllerBase
    {
        private LaptopContext context;
        public LaptopController(LaptopContext _context)
        {
            context = _context;
        }
       
        // GET: api/Laptop
        [HttpGet]
        public IEnumerable<Laptop> Get()
        {
            return context.Laptops;
        }

        // GET: api/Laptop/5
        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(int id)
        {
            var result = context.Laptops.SingleOrDefault(m => m.LaptopId== id);
           if(result == null)
            {
                return NotFound("not found");
            }
           else
                return Ok(result);
           
        }

        // POST: api/Laptop
        [HttpPost]
        public IActionResult Post([FromBody] Laptop laptop)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else
            {
                context.Laptops.Add(laptop);
                context.SaveChanges();
                return StatusCode(StatusCodes.Status201Created);

            }
            
        }

        // PUT: api/Laptop/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Laptop laptop)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if(id != laptop.LaptopId )
            {
                return BadRequest();
            }
            context.Laptops.Update(laptop);
            context.SaveChanges();
            return Ok("updated");
         
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var result = context.Laptops.SingleOrDefault(c => c.LaptopId == id);
            if (result == null)
            {
                return NotFound("not found");
            }
            else
            {
                context.Laptops.Remove(result);
                context.SaveChanges(true);
                return Ok("deleted..");

            }
        }
    }
}
