﻿using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DipsApi.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DipsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MeasurementsController : ControllerBase
    {

        private readonly BpContext _context;

        public MeasurementsController(BpContext context)
        {
            _context = context;
        }

        // GET: api/Measurements
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Measurement>>> GetMeasurements()
        {
            return await _context.Measurements.ToListAsync();
        }

        // GET: api/Measurements/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Measurement>> GetTodoItem(int id)
        {
            var measurement = await _context.Measurements.FindAsync(id);

            if (measurement == null)
            {
                return NotFound();
            }

            return measurement;
        }

        // PUT: api/Measurements/{id}
        
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTodoItem(int id, Measurement measurement)
        {
            if (id != measurement.Id)
            {
                return BadRequest();
            }

            _context.Entry(measurement).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MeasurementExists(id))
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

        // POST: api/Measurements
                [HttpPost]
        public async Task<ActionResult<Measurement>> PostTodoItem(Measurement measurement)
        {
            _context.Measurements.Add(measurement);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetTodoItem), new { id = measurement.Id }, measurement);
        }

        // DELETE: api/Measurements/{id}
        //[EnableCors("AllowAnyOrigin")]
        [HttpDelete("{id}")]
        public async Task<ActionResult<Measurement>> DeleteMeasurement(int id)
        {
            var measurement = await _context.Measurements.FindAsync(id);
            if (measurement == null)
            {
                return NotFound();
            }

            _context.Measurements.Remove(measurement);
            await _context.SaveChangesAsync();

            return measurement;
        }

        private bool MeasurementExists(int id)
        {
            return _context.Measurements.Any(e => e.Id == id);
        }
    }
}
