using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using application.vehicle.track.api.Data;
using application.vehicle.track.model.Models;

namespace application.vehicle.track.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistrationsController : ControllerBase
    {
        private readonly applicationvehicletrackapiContext _context;

        public RegistrationsController(applicationvehicletrackapiContext context)
        {
            _context = context;
        }

        // GET: api/Registrations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Registration>>> GetRegistration()
        {
            return await _context.Registration.ToListAsync();
        }

        // GET: api/Registrations/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Registration>> GetRegistration(Guid id)
        {
            var registration = await _context.Registration.FindAsync(id);

            if (registration == null)
            {
                return NotFound();
            }

            return registration;
        }

        // PUT: api/Registrations/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRegistration(Guid id, Registration registration)
        {
            if (id != registration.MyProperty)
            {
                return BadRequest();
            }

            _context.Entry(registration).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RegistrationExists(id))
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

        // POST: api/Registrations
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Registration>> PostRegistration(Registration registration)
        {
            _context.Registration.Add(registration);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRegistration", new { id = registration.MyProperty }, registration);
        }

        // DELETE: api/Registrations/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRegistration(Guid id)
        {
            var registration = await _context.Registration.FindAsync(id);
            if (registration == null)
            {
                return NotFound();
            }

            _context.Registration.Remove(registration);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RegistrationExists(Guid id)
        {
            return _context.Registration.Any(e => e.MyProperty == id);
        }
    }
}
