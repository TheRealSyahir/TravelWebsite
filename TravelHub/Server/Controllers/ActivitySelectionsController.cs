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
    public class ActivitySelectionsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public ActivitySelectionsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: api/ActivitySelections
        [HttpGet]
        public async Task<IActionResult> GetActivitySelections()
        {
            var activityselections = await _unitOfWork.ActivitySelections.GetAll(includes: q => q.Include(x => x.Itinerary).Include(x=>x.Activity));
            return Ok(activityselections);
        }

        // GET: api/ActivitySelections/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetActivitySelection(int id)
        {
            var activityselection = await _unitOfWork.ActivitySelections.Get(q => q.ActivitySelectionID == id);
            if (activityselection == null)
            {
                return NotFound();
            }

            return Ok(activityselection);
        }

        // PUT: api/ActivitySelections/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutActivitySelection(int id, ActivitySelection activityselection)
        {
            if (id != activityselection.ActivitySelectionID)
            {
                return BadRequest();
            }

            //_context.Entry(activitySelection).State = EntityState.Modified;
            _unitOfWork.ActivitySelections.Update(activityselection);

            try
            {
                await _unitOfWork.Save(HttpContext);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await ActivitySelectionExists(id))
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

        // POST: api/ActivitySelections
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ActivitySelection>> PostActivitySelection(ActivitySelection activityselection)
        {
            await _unitOfWork.ActivitySelections.Insert(activityselection);
            await _unitOfWork.Save(HttpContext);

            return CreatedAtAction("GetActivitySelection", new { id = activityselection.ActivitySelectionID }, activityselection);
        }

        // DELETE: api/ActivitySelections/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteActivitySelection(int id)
        {
            var activityselection = await _unitOfWork.ActivitySelections.Get(q => q.ActivitySelectionID == id);
            if (activityselection == null)
            {
                return NotFound();
            }

            await _unitOfWork.ActivitySelections.Delete(id);
            await _unitOfWork.Save(HttpContext);

            return NoContent();
        }

        private async Task<bool> ActivitySelectionExists(int id)
        {
            var activityselection = await _unitOfWork.ActivitySelections.Get(q => q.ActivitySelectionID == id);
            return activityselection != null;
        }
    }
}
