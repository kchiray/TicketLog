using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TicketLog.Data;
using TicketLog.Models;

namespace TicketLog.Controllers
{
    public class StatisticsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public StatisticsController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: Statistics
        public async Task<IActionResult> Index(string sortOrder)
        {
            ViewData["EmailsSortParm"] = string.IsNullOrEmpty(sortOrder) ? "emails" : "Emails";
            ViewData["AppsSortparm"] = string.IsNullOrEmpty(sortOrder) ? "applications" : "Applications";
            ViewData["ToDoSortparm"] = string.IsNullOrEmpty(sortOrder) ? "todo" : "ToDo";
            ViewData["DateSortParm"] = sortOrder == "EDate" ? "edate" : "";

            var statistics = from s in _context.Statistics
                             select s;

            switch (sortOrder)
            {
                case "emails":
                    statistics = statistics.OrderByDescending(s => s.Emails);
                        break;
                case "Emails":
                    statistics = statistics.OrderBy(s => s.Emails);
                        break;
                case "applications":
                    statistics = statistics.OrderByDescending(s => s.NewApplicaitons);
                        break;
                case "Applications":
                    statistics = statistics.OrderBy(s => s.NewApplicaitons);
                        break;
                case "todo":
                    statistics = statistics.OrderByDescending(s => s.ToDo);
                        break;
                case "ToDo":
                    statistics = statistics.OrderBy(s => s.ToDo);
                        break;
                case "EDate":
                    statistics = statistics.OrderBy(s => s.EntryDate);
                        break;
                default:
                    statistics = statistics.OrderByDescending(s => s.EntryDate);
                    break;
            }

            return View(await statistics.AsNoTracking().ToListAsync());
        }

        // GET: Statistics/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var statistic = await _context.Statistics
                .SingleOrDefaultAsync(m => m.Id == id);
            if (statistic == null)
            {
                return NotFound();
            }

            return View(statistic);
        }

        // GET: Statistics/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Statistics/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,EntryDate,Emails,NewApplicaitons,ToDo,YearToDate,IncompleteApplications")] Statistic statistic)
        {
            if (ModelState.IsValid)
            {
                _context.Add(statistic);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(statistic);
        }

        // GET: Statistics/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var statistic = await _context.Statistics.SingleOrDefaultAsync(m => m.Id == id);
            if (statistic == null)
            {
                return NotFound();
            }
            return View(statistic);
        }

        // POST: Statistics/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,EntryDate,Emails,NewApplicaitons,ToDo,YearToDate,IncompleteApplications")] Statistic statistic)
        {
            if (id != statistic.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(statistic);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StatisticExists(statistic.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            return View(statistic);
        }

        // GET: Statistics/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var statistic = await _context.Statistics
                .SingleOrDefaultAsync(m => m.Id == id);
            if (statistic == null)
            {
                return NotFound();
            }

            return View(statistic);
        }

        // POST: Statistics/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var statistic = await _context.Statistics.SingleOrDefaultAsync(m => m.Id == id);
            _context.Statistics.Remove(statistic);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool StatisticExists(int id)
        {
            return _context.Statistics.Any(e => e.Id == id);
        }
    }
}
