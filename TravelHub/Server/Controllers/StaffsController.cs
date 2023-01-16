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
    public class StaffsController : Controller
    {

        private readonly IUnitOfWork _unitofwork;

        public StaffsController(IUnitOfWork unitofwork)
        {
            _unitofwork = unitofwork;
        }

        [HttpGet]
        public async Task<IActionResult> getStaffs()
        {
            var staffs = await _unitofwork.Staffs.GetAll();
            return Ok(staffs);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> getStaff(int id)
        {
            var staff = await _unitofwork.Staffs.Get(q => q.StaffID == id);
            if (staff == null)
            {
                return NotFound();
            }
            return Ok(staff);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> putStaff(int id, Staff staff)
        {
            if (id != staff.StaffID)
            {
                return BadRequest();
            }

            _unitofwork.Staffs.Update(staff);

            try
            {
                await _unitofwork.Save(HttpContext);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await StaffExists(id))
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
        public async Task<ActionResult<Staff>> PostStaff(Staff staff)
        {
            await _unitofwork.Staffs.Insert(staff);
            await _unitofwork.Save(HttpContext);

            return CreatedAtAction("GetStaff", new { id = staff.StaffID }, staff);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStaff(int id)
        {
            var staff = await _unitofwork.Staffs.Get(q => q.StaffID == id);

            if (staff == null)
            {
                return NotFound();
            }
            await _unitofwork.Staffs.Delete(id);
            await _unitofwork.Save(HttpContext);

            return NoContent();
        }

        private async Task<bool> StaffExists(int id)
        {
            var staff = await _unitofwork.Staffs.Get(q => q.StaffID == id);
            return staff != null;
        }
    }
}
