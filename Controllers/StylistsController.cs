using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Proiect_web_Frizerie.Data;
using Proiect_web_Frizerie.Models;

namespace Proiect_web_Frizerie.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StylistsController : ControllerBase
    {
        private readonly Proiect_web_FrizerieContext _context;

        public StylistsController(Proiect_web_FrizerieContext context)
        {
            _context = context;
        }

        // GET: api/Stylists
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Stylist>>> GetStylist()
        {
            return await _context.Stylist.ToListAsync();
        }

        // GET: api/Stylists/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Stylist>> GetStylist(int id)
        {
            var stylist = await _context.Stylist.FindAsync(id);

            if (stylist == null)
            {
                return NotFound();
            }

            return stylist;
        }

        // PUT: api/Stylists/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStylist(int id, Stylist stylist)
        {
            if (id != stylist.ID)
            {
                return BadRequest();
            }

            _context.Entry(stylist).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StylistExists(id))
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

        // POST: api/Stylists
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Stylist>> PostStylist(Stylist stylist)
        {
            _context.Stylist.Add(stylist);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetStylist", new { id = stylist.ID }, stylist);
        }

        // DELETE: api/Stylists/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStylist(int id)
        {
            var stylist = await _context.Stylist.FindAsync(id);
            if (stylist == null)
            {
                return NotFound();
            }

            _context.Stylist.Remove(stylist);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool StylistExists(int id)
        {
            return _context.Stylist.Any(e => e.ID == id);
        }
    }
}
