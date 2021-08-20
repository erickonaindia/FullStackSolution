using Microsoft.AspNetCore.Mvc;
using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Services.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParkingController : ControllerBase
    {
        private readonly IParkingService _context;
        public ParkingController(IParkingService context)
        {
            _context = context;
        }

        // GET: api/<ParkingController>
        [HttpGet]
        public ActionResult<IEnumerable<Parking>> GetAll()
        {
            try
            {
                var model = _context.GetAll();

                return model.ToList();
            }
            catch (Exception)
            {
                return BadRequest();

            }

        }

        // GET api/<ParkingController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Parking>> Get(int id)
        {
            try
            {
                return await _context.GetAsync(id);
            }
            catch (Exception)
            {
                return BadRequest();
            }

        }

        // POST api/<ParkingController>
        [HttpPost]
        public async Task<ActionResult<Parking>> Post([FromBody] Parking parking)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest();


                var result = await _context.AddAsync(parking);
                return result;
            }
            catch (Exception)
            {
                return BadRequest();
            }

        }

        // PUT api/<ParkingController>/5
        [HttpPut]
        public async Task<ActionResult<Parking>> Put([FromBody] Parking parking)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest();

                var result = await _context.UpdateAsync(parking);
                return result;
            }
            catch (Exception)
            {
                return BadRequest();
            }

        }

        // DELETE api/<ParkingController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Parking>> Delete(int id)
        {
            try
            {
                var result = await _context.DeleteAsync(id);

                return result;
            }
            catch (Exception)
            {
                return BadRequest();
            }

        }
    }
}
