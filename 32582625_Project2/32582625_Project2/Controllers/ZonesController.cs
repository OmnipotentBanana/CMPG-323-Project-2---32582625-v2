using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using _32582625_Project2.Models;
using _32582625_Project2.Data;

namespace _32582625_Project2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ZonesController : ControllerBase
    {
        private readonly CMPG323_Project2Context _context;

        public ZonesController(CMPG323_Project2Context context)
        {
            _context = context;
        }

        // GET: api/Zones
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Zone>>> GetZones()
        {
          if (_context.Zones == null)
          {
              return NotFound();
          }
            return await _context.Zones.ToListAsync();
        }

        // GET: api/Zones/{Guid}
        [HttpGet("{id}")]
        public async Task<ActionResult<Zone>> GetZone(Guid id)
        {
          if (_context.Zones == null)
          {
              return NotFound();
          }
            var zone = await _context.Zones.FindAsync(id);

            if (zone == null)
            {
                return NotFound();
            }

            return zone;
        }

        // PUT: api/Zones/{Guid}
        [HttpPut("{id}")]
        public async Task<IActionResult> PutZone(Guid id, Zone zone)
        {
            if (id != zone.ZoneId)
            {
                return BadRequest();
            }

            _context.Entry(zone).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ZoneExists(id))
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

        // POST: api/Zones
        [HttpPost]
        public async Task<ActionResult<Zone>> PostZone(Zone zone)
        {
          if (_context.Zones == null)
          {
              return Problem("Entity set 'CMPG323_Project2Context.Zones'  is null.");
          }
            _context.Zones.Add(zone);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ZoneExists(zone.ZoneId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetZone", new { id = zone.ZoneId }, zone);
        }

        // DELETE: api/Zones/{Guid}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteZone(Guid id)
        {
            if (_context.Zones == null)
            {
                return NotFound();
            }
            var zone = await _context.Zones.FindAsync(id);
            if (!ZoneExists(id))
            {
                return NotFound();
            }

            _context.Zones.Remove(zone);
            await _context.SaveChangesAsync();

            return NoContent();
        }
        

        private bool ZoneExists(Guid id)
        {
            return (_context.Zones?.Any(e => e.ZoneId == id)).GetValueOrDefault();
        }
    }
}
