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
    public class TicketsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private string subdate;

        public TicketsController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: Tickets
        public async Task<IActionResult> Index(string sortOrder, string searchString)
        {
            Ticket ticket = new Ticket();
            subdate = ticket.SubmissionDate.ToString();

            ViewData["IssueSortParm"] = String.IsNullOrEmpty(sortOrder) ? "issue_desc" : "";
            ViewData["SevSortParm"] = String.IsNullOrEmpty(sortOrder) ? "sev_desc" : "severity";
            ViewData["DateSortParm"] = sortOrder == "Date" ? "date_desc" : "Date";

            ViewData["CurrentFilter"] = searchString;

            var tickets = from t in _context.Tickets
                          select t;

            if (!String.IsNullOrEmpty(searchString))
            {
                tickets = tickets.Where(t => t.Issue.Contains(searchString) 
                          || t.Severity.Contains(searchString) || subdate.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "issue_desc":
                    tickets = tickets.OrderByDescending(t => t.Issue);
                    break;
                case "severity":
                    tickets = tickets.OrderBy(t => t.Severity);
                    break;
                case "sev_desc":
                    tickets = tickets.OrderByDescending(t => t.Severity);
                    break;
                case "date_desc":
                    tickets = tickets.OrderByDescending(t => t.SubmissionDate);
                    break;
                default:
                    tickets = tickets.OrderBy(t => t.Issue);
                    break;
            }
            return View(await _context.Tickets.ToListAsync());
        }

        // GET: Tickets/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ticket = await _context.Tickets
                .SingleOrDefaultAsync(m => m.ID == id);
            if (ticket == null)
            {
                return NotFound();
            }

            return View(ticket);
        }

        // GET: Tickets/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Tickets/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,SubmissionDate,Issue,Description,TimesOccured,Severity")] Ticket ticket)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ticket);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(ticket);
        }

        // GET: Tickets/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ticket = await _context.Tickets.SingleOrDefaultAsync(m => m.ID == id);
            if (ticket == null)
            {
                return NotFound();
            }
            return View(ticket);
        }

        // POST: Tickets/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,SubmissionDate,Issue,Description,TimesOccured,Severity")] Ticket ticket)
        {
            if (id != ticket.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ticket);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TicketExists(ticket.ID))
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
            return View(ticket);
        }

        // GET: Tickets/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ticket = await _context.Tickets
                .SingleOrDefaultAsync(m => m.ID == id);
            if (ticket == null)
            {
                return NotFound();
            }

            return View(ticket);
        }

        // POST: Tickets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ticket = await _context.Tickets.SingleOrDefaultAsync(m => m.ID == id);
            _context.Tickets.Remove(ticket);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool TicketExists(int id)
        {
            return _context.Tickets.Any(e => e.ID == id);
        }
    }
}
