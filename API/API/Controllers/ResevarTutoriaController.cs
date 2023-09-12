﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API.Models;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResevarTutoriaController : ControllerBase
    {
        private readonly T5sContext _context;

        public ResevarTutoriaController(T5sContext context)
        {
            _context = context;
        }

        // GET: api/ResevarTutoriums
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ResevarTutoria>>> GetResevarTutoria()
        {
          if (_context.ResevarTutoria == null)
          {
              return NotFound();
          }
            return await _context.ResevarTutoria.ToListAsync();
        }

        // GET: api/ResevarTutoriums/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ResevarTutoria>> GetResevarTutorium(int id)
        {
          if (_context.ResevarTutoria == null)
          {
              return NotFound();
          }
            var resevarTutorium = await _context.ResevarTutoria.FindAsync(id);

            if (resevarTutorium == null)
            {
                return NotFound();
            }

            return resevarTutorium;
        }

        // PUT: api/ResevarTutoriums/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutResevarTutorium(int id, ResevarTutoria resevarTutorium)
        {
            if (id != resevarTutorium.IdReserva)
            {
                return BadRequest();
            }

            _context.Entry(resevarTutorium).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ResevarTutoriumExists(id))
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

        // POST: api/ResevarTutoriums
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ResevarTutoria>> PostResevarTutorium(ResevarTutoria resevarTutorium)
        {
          if (_context.ResevarTutoria == null)
          {
              return Problem("Entity set 'T5sContext.ResevarTutoria'  is null.");
          }
            _context.ResevarTutoria.Add(resevarTutorium);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ResevarTutoriumExists(resevarTutorium.IdReserva))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetResevarTutorium", new { id = resevarTutorium.IdReserva }, resevarTutorium);
        }

        // DELETE: api/ResevarTutoriums/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteResevarTutorium(int id)
        {
            if (_context.ResevarTutoria == null)
            {
                return NotFound();
            }
            var resevarTutorium = await _context.ResevarTutoria.FindAsync(id);
            if (resevarTutorium == null)
            {
                return NotFound();
            }

            _context.ResevarTutoria.Remove(resevarTutorium);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ResevarTutoriumExists(int id)
        {
            return (_context.ResevarTutoria?.Any(e => e.IdReserva == id)).GetValueOrDefault();
        }
    }
}
