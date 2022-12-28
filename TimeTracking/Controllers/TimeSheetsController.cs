using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TimeTracking.Data;
using TimeTracking.Models;
using TimeTracking.ViewModels;

namespace TimeTracking.Controllers
{
    public class TimeSheetsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TimeSheetsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: TimeSheets
        public async Task<IActionResult> Index()
        {
              return View(await _context.TimeSheet.ToListAsync());
        }

        // GET: TimeSheets/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _context.TimeSheet == null)
            {
                return NotFound();
            }

            var timeSheet = await _context.TimeSheet
                .FirstOrDefaultAsync(m => m.Id == id);
            if (timeSheet == null)
            {
                return NotFound();
            }

            return View(timeSheet);
        }

        // GET: TimeSheets/Create
        public async Task<IActionResult> Create()
        {
            var projects = await _context.Project.ToListAsync();
            TimeSheetsViewModel viewModel = new TimeSheetsViewModel()
            {
                TimeSheet = new TimeSheet(),
                Projects = projects
            };
            
            return View(viewModel);
        }

        // POST: TimeSheets/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,WeekNumber,Notes,StartDate,EndDate")] TimeSheet timeSheet)
        {
            if (ModelState.IsValid)
            {
                timeSheet.Id = Guid.NewGuid();
                _context.Add(timeSheet);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(timeSheet);
        }

        // GET: TimeSheets/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null || _context.TimeSheet == null)
            {
                return NotFound();
            }

            var timeSheet = await _context.TimeSheet.FindAsync(id);
            if (timeSheet == null)
            {
                return NotFound();
            }
            return View(timeSheet);
        }

        // POST: TimeSheets/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,WeekNumber,Notes,StartDate,EndDate")] TimeSheet timeSheet)
        {
            if (id != timeSheet.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(timeSheet);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TimeSheetExists(timeSheet.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(timeSheet);
        }

        // GET: TimeSheets/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _context.TimeSheet == null)
            {
                return NotFound();
            }

            var timeSheet = await _context.TimeSheet
                .FirstOrDefaultAsync(m => m.Id == id);
            if (timeSheet == null)
            {
                return NotFound();
            }

            return View(timeSheet);
        }

        // POST: TimeSheets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (_context.TimeSheet == null)
            {
                return Problem("Entity set 'ApplicationDbContext.TimeSheet'  is null.");
            }
            var timeSheet = await _context.TimeSheet.FindAsync(id);
            if (timeSheet != null)
            {
                _context.TimeSheet.Remove(timeSheet);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TimeSheetExists(Guid id)
        {
          return _context.TimeSheet.Any(e => e.Id == id);
        }
    }
}
