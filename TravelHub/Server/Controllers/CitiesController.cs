using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TravelHub.Server.Data;
using TravelHub.Server.IRepository;
using TravelHub.Shared.Domain;

namespace TravelHub.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CitiesController : Controller
    {

        private readonly IUnitOfWork _unitofwork;

        public CitiesController(IUnitOfWork unitofwork)
        {
            _unitofwork = unitofwork;
        }

        [HttpGet]
        public async Task<IActionResult> getCities()
        {
            //returnNotFound();
            var cities = await _unitofwork.Cities.GetAll();
            return Ok(cities);
        }
        
        [HttpGet("{id}")]
        public async Task<IActionResult> getCity(int id)
        {
            var city = await _unitofwork.Cities.Get(q => q.CityID == id);
            if (city == null)
            {
                return NotFound();
            }
            return Ok(city);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> putCity(int id, City city)
        {
            if (id != city.CityID)
            {
                return BadRequest();
            }

            _unitofwork.Cities.Update(city);

            try
            {
                await _unitofwork.Save(HttpContext);
            }
            catch(DbUpdateConcurrencyException)
            {
                if(!await CityExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }


        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<ActionResult<City>> PostCity(City city)
        {
            await _unitofwork.Cities.Insert(city);
            await _unitofwork.Save(HttpContext);

            return CreatedAtAction("GetCity", new { id = city.CityID }, city);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCity(int id)
        {
            var city = await _unitofwork.Cities.Get(q => q.CityID == id);
            
            if (city == null)
            {
                return NotFound();
            }
            await _unitofwork.Cities.Delete(id);
            await _unitofwork.Save(HttpContext);

            return NoContent();
        }

        private async Task<bool> CityExists(int id)
        {
            var city = await _unitofwork.Cities.Get(q => q.CityID == id);
            return city != null;
        }
    }
}
