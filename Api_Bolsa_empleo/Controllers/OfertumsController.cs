using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Api_Bolsa_empleo.Entities;

namespace Api_Bolsa_empleo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OfertumsController : ControllerBase
    {
        private readonly empleoContext _context;

        public OfertumsController(empleoContext context)
        {
            _context = context;
        }

        // GET: api/Ofertums
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Ofertum>>> GetOferta()
        {
            return await _context.Oferta.ToListAsync();
        }

        // GET: api/Ofertums/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Ofertum>> GetOfertum(int id)
        {
            var ofertum = await _context.Oferta.FindAsync(id);

            if (ofertum == null)
            {
                return NotFound();
            }

            return ofertum;
        }

        // PUT: api/Ofertums/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOfertum(int id, Ofertum ofertum)
        {
            if (id != ofertum.Id)
            {
                return BadRequest();
            }

            _context.Entry(ofertum).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OfertumExists(id))
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

        // POST: api/Ofertums
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Ofertum>> PostOfertum(Ofertum ofertum)
        {
            _context.Oferta.Add(ofertum);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (OfertumExists(ofertum.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetOfertum", new { id = ofertum.Id }, ofertum);
        }

        // DELETE: api/Ofertums/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOfertum(int id)
        {
            var ofertum = await _context.Oferta.FindAsync(id);
            if (ofertum == null)
            {
                return NotFound();
            }

            _context.Oferta.Remove(ofertum);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool OfertumExists(int id)
        {
            return _context.Oferta.Any(e => e.Id == id);
        }
    }
}
