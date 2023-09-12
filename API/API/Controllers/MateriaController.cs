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
    public class MateriaController : ControllerBase
    {
        private readonly T5sContext _context;

        public MateriaController(T5sContext context)
        {
            _context = context;
        }

        // GET: api/Materiums
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Materia>>> GetMateria()
        {
          if (_context.Materia == null)
          {
              return NotFound();
          }
            return await _context.Materia.ToListAsync();
        }

        // GET: api/Materiums/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Materia>> GetMaterium(int id)
        {
          if (_context.Materia == null)
          {
              return NotFound();
          }
            var materium = await _context.Materia.FindAsync(id);

            if (materium == null)
            {
                return NotFound();
            }

            return materium;
        }

        // PUT: api/Materiums/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMaterium(int id, Materia materium)
        {
            if (id != materium.IdMateria)
            {
                return BadRequest();
            }

            _context.Entry(materium).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MateriumExists(id))
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

        // POST: api/Materiums
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Materia>> PostMaterium(Materia materium)
        {
          if (_context.Materia == null)
          {
              return Problem("Entity set 'T5sContext.Materia'  is null.");
          }
            _context.Materia.Add(materium);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (MateriumExists(materium.IdMateria))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetMaterium", new { id = materium.IdMateria }, materium);
        }

        // DELETE: api/Materiums/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMaterium(int id)
        {
            if (_context.Materia == null)
            {
                return NotFound();
            }
            var materium = await _context.Materia.FindAsync(id);
            if (materium == null)
            {
                return NotFound();
            }

            _context.Materia.Remove(materium);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MateriumExists(int id)
        {
            return (_context.Materia?.Any(e => e.IdMateria == id)).GetValueOrDefault();
        }
    }
}
