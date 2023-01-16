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
    public class LocationsController : Controller
    {

        private readonly IUnitOfWork _unitofwork;

        public LocationsController(IUnitOfWork unitofwork)
        {
            _unitofwork = unitofwork;
        }

        [HttpGet]
        public async Task<IActionResult> getLocations()
        {
            var locations = await _unitofwork.Locations.GetAll(includes:q=>q.Include(x=>x.City));
            return Ok(locations);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> getLocation(int id)
        {
            var location = await _unitofwork.Locations.Get(q => q.LocationID == id);
            if (location == null)
            {
                return NotFound();
            }
            return Ok(location);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> putLocation(int id, Location location)
        {
            if (id != location.LocationID)
            {
                return BadRequest();
            }

            _unitofwork.Locations.Update(location);

            try
            {
                await _unitofwork.Save(HttpContext);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await LocationExists(id))
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
        public async Task<ActionResult<Location>> PostLocation(Location location)
        {
            await _unitofwork.Locations.Insert(location);
            await _unitofwork.Save(HttpContext);

            return CreatedAtAction("GetLocation", new { id = location.LocationID }, location);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLocation(int id)
        {
            var location = await _unitofwork.Locations.Get(q => q.LocationID == id);

            if (location == null)
            {
                return NotFound();
            }
            await _unitofwork.Locations.Delete(id);
            await _unitofwork.Save(HttpContext);

            return NoContent();
        }

        private async Task<bool> LocationExists(int id)
        {
            var location = await _unitofwork.Locations.Get(q => q.LocationID == id);
            return location != null;
        }
    }
}
