using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TicketLog.Data;
using TicketLog.Models;

namespace TicketLog.Controllers
{
    [Produces("application/json")]
    [Route("api/StatisticsApi")]
    public class StatisticsApiController : Controller
    {
        private readonly ApplicationDbContext _context;

        public StatisticsApiController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/StatisticsApi
        [HttpGet]
        public IEnumerable<Statistic> GetStatistics()
        {
            return _context.Statistics;
        }

        // GET: api/StatisticsApi/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetStatistic([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var statistic = await _context.Statistics.SingleOrDefaultAsync(m => m.Id == id);

            if (statistic == null)
            {
                return NotFound();
            }

            return Ok(statistic);
        }

        // PUT: api/StatisticsApi/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStatistic([FromRoute] int id, [FromBody] Statistic statistic)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != statistic.Id)
            {
                return BadRequest();
            }

            _context.Entry(statistic).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StatisticExists(id))
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

        // POST: api/StatisticsApi
        [HttpPost]
        public async Task<IActionResult> PostStatistic([FromBody] Statistic statistic)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Statistics.Add(statistic);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetStatistic", new { id = statistic.Id }, statistic);
        }

        // DELETE: api/StatisticsApi/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStatistic([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var statistic = await _context.Statistics.SingleOrDefaultAsync(m => m.Id == id);
            if (statistic == null)
            {
                return NotFound();
            }

            _context.Statistics.Remove(statistic);
            await _context.SaveChangesAsync();

            return Ok(statistic);
        }

        private bool StatisticExists(int id)
        {
            return _context.Statistics.Any(e => e.Id == id);
        }
    }
}