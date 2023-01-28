using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TravelHub.Server.Data;
using TravelHub.Server.IRepository;
using TravelHub.Shared.Domain;

namespace TravelHub.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItinerariesController : Controller
    {
        
        private readonly IUnitOfWork _unitOfWork;

        public ItinerariesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IActionResult> GetItineraries()
        {
            var itineraries = await _unitOfWork.Itineraries.GetAll(includes:q=>q.Include(x=>x.Customer));
            return Ok(itineraries);
        }

        // GET: api/Itineraries/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetItinerary(int id)
        {
            var itinerary = await _unitOfWork.Itineraries.Get(q => q.ItineraryID == id);
            if (itinerary == null)
            {
                return NotFound();
            }

            return Ok(itinerary);
        }

        // PUT: api/Itineraries/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutItinerary(int id, Itinerary itinerary)
        {
            if (id != itinerary.ItineraryID)
            {
                return BadRequest();
            }

            _unitOfWork.Itineraries.Update(itinerary);

            try
            {
                await _unitOfWork.Save(HttpContext);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await ItineraryExists(id))
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

        // POST: api/Itineraries
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Itinerary>> PostItinerary(Itinerary itinerary)
        {
            await _unitOfWork.Itineraries.Insert(itinerary);
            await _unitOfWork.Save(HttpContext);

            return CreatedAtAction("GetItinerary", new { id = itinerary.ItineraryID }, itinerary);
        }

        // DELETE: api/Itineraries/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteItinerary(int id)
        {
            var itinerary = await _unitOfWork.Itineraries.Get(q => q.ItineraryID== id);   
            if (itinerary == null)
            {
                return NotFound();
            }

            await _unitOfWork.Itineraries.Delete(id);
            await _unitOfWork.Save(HttpContext);

            return NoContent();
        }

        private async Task<bool> ItineraryExists(int id)
        {
            var itinerary = await _unitOfWork.Itineraries.Get(q => q.ItineraryID == id);
            return itinerary != null;
        }
    }
}
