using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using _32582625_Project2.Models;
using Microsoft.Data.SqlClient;
using _32582625_Project2.Data;

namespace _32582625_Project2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly CMPG323_Project2Context _context;

        public CategoriesController(CMPG323_Project2Context context)
        {
            _context = context;
        }

        // GET: api/Categories
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Category>>> GetCategories()
        {
            if (_context.Categories == null)
            {
                return NotFound();
            }
            return await _context.Categories.ToListAsync();

        }

        // GET: api/Categories/{Guid}
        [HttpGet("{id}")]
        public async Task<ActionResult<Category>> GetCategory(Guid id)
        {
          if (_context.Categories == null)
          {
              return NotFound();
          }
            var category = await _context.Categories.FindAsync(id);

            if (category == null)
            {
                return NotFound();
            }

            return category;
        }

        // PUT: api/Categories/{Guid}
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCategory(Guid id, Category category)
        {
            if (id != category.CategoryId)
            {
                return BadRequest();
            }

            _context.Entry(category).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CategoryExists(id))
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

        // POST: api/Categories
        [HttpPost]
        public async Task<ActionResult<Category>> PostCategory(Category category)
        {
          if (_context.Categories == null)
          {
              return Problem("Entity set 'CMPG323_Project2Context.Categories'  is null.");
          }
            _context.Categories.Add(category);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (CategoryExists(category.CategoryId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetCategory", new { id = category.CategoryId }, category);
        }

        // DELETE: api/Categories/{Guid}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(Guid id)
        {
            if (_context.Categories == null)
            {
                return NotFound();
            }
            var category = await _context.Categories.FindAsync(id);
            if (!CategoryExists(id))
            {
                return NotFound();
            }

            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();

            return NoContent();
        }


        // GET: api/GetDeviceByCategory/{Guid}
        [HttpGet("GetDeviceByCategory/{id}")]
        public async Task<IEnumerable<Device>> GetDeviceByCategoryID(Guid id)
        {
            if (_context.Devices == null || _context.Categories == null)
            {
                return null;
            }
            var category = await _context.Categories.FindAsync(id);
            if (category == null)
            {
                return null;
            }
            var devices = from d in _context.Devices
                          where d.CategoryId.Equals(id)
                          select d; // get devices by category id
            
            return devices; // This is true beauty, seeing the data being successfully retreived. 😭
        }

        // GET: api/GetDeviceByCategory/{Guid}
        [HttpGet("GetNumberOfZones/{id}")]
        public async Task<int> GetNumberOfZones(Guid id)
        {
            if (_context.Zones == null || _context.Categories == null)
            {
                return 0;
            }
            var category = await _context.Categories.FindAsync(id);
            if (category == null)
            {
                return 0;
            }

            var categories = from z in _context.Zones
                             join d in _context.Devices on z.ZoneId equals d.ZoneId
                             join c in _context.Categories on d.CategoryId equals c.CategoryId
                             where c.CategoryId == d.CategoryId
                             &&  z.ZoneId == d.ZoneId
                             select d;
            return categories.Count(); // im going to cry. this is a million times better than SQL
        }

        private bool CategoryExists(Guid id)
        {
            return (_context.Categories?.Any(e => e.CategoryId == id)).GetValueOrDefault();
        }
    }
}
