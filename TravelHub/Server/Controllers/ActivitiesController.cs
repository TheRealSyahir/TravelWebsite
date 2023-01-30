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
    public class ActivitiesController : Controller
    {

        private readonly IUnitOfWork _unitofwork;

        public ActivitiesController(IUnitOfWork unitofwork)
        {
            _unitofwork = unitofwork;
        }

        [HttpGet]
        public async Task<IActionResult> getActivities()
        {
            var activities = await _unitofwork.Activities.GetAll(includes:q=>q.Include(x=>x.Location).Include(x=>x.Staff));
            return Ok(activities);
        }
        
        [HttpGet("{id}")]
        public async Task<IActionResult> getActivity(int id)
        {
            var activity = await _unitofwork.Activities.Get(q => q.ActivityID == id);
            if (activity == null)
            {
                return NotFound();
            }
            return Ok(activity);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> putActivity(int id, Activity activity)
        {
            if (id != activity.ActivityID)
            {
                return BadRequest();
            }

            _unitofwork.Activities.Update(activity);

            try
            {
                await _unitofwork.Save(HttpContext);
            }
            catch(DbUpdateConcurrencyException)
            {
                if(!await ActivityExists(id))
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
        public async Task<ActionResult<Activity>> PostActivity(Activity activity)
        {
            await _unitofwork.Activities.Insert(activity);
            await _unitofwork.Save(HttpContext);

            return CreatedAtAction("GetActivity", new { id = activity.ActivityID }, activity);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteActivity(int id)
        {
            var activity = await _unitofwork.Activities.Get(q => q.ActivityID == id);
            
            if (activity == null)
            {
                return NotFound();
            }
            await _unitofwork.Activities.Delete(id);
            await _unitofwork.Save(HttpContext);

            return NoContent();
        }

        private async Task<bool> ActivityExists(int id)
        {
            var activity = await _unitofwork.Activities.Get(q => q.ActivityID == id);
            return activity != null;
        }
    }
}
