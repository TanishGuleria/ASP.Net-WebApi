using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ASP.NetWebApi.Model;
using ASP.NetWebApi.Services;
namespace ASP.NetWebApi.Controllers
    
{
    [ApiVersion("1.0")]
    [Route("api/laptop")]
    [ApiController]
    public class LaptopController : ControllerBase
    {
       private Ilaptop laptopRepository;

       public LaptopController(Ilaptop _laptopRepository)
        {
            laptopRepository = _laptopRepository;
        }
        // GET: api/Laptop
        [HttpGet]
       /* public IEnumerable<Laptop> Get()
        {
            return context.Laptops;
        }*/

            //implement concept of pageing to show less data
        public IEnumerable<Laptop> Get(int? PageNo , int? PageSize)

        {
            var result = laptopRepository.GetLaptop(PageNo,PageSize);

            return result;

        }

        // GET: api/Laptop/5
        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(int id)
        {
            var result = laptopRepository.GetLaptopbyid(id);
           if(result == null)
            {
                return NotFound("not found");
            }
           else
                return Ok(result);
           
        }
        //Sort the list By price
        [HttpGet("sort")]
        public IEnumerable<Laptop> Getsort(string sort)
        {

            var result = laptopRepository.Getsort(sort);
            return result;
        }
        //Serach laptop by  Brand Name
        [HttpGet("search")]
        public IEnumerable<Laptop> Getsearch(string s)
        {
            var result = laptopRepository.Getsearch(s);
            return result;
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
                laptopRepository.AddLaptop(laptop);
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
            laptopRepository.UpdateLaptop(laptop);
            return Ok("updated");
         
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            laptopRepository.DeleteLaptop(id);
                return Ok("deleted..");

            }
        }
    }

