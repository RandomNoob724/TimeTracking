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
    public class TimeSheetRowsController : BaseController
    {
        private readonly ApplicationDbContext _context;

        public TimeSheetRowsController(ApplicationDbContext context):base(context)
        {
            _context = context;
        }

        // GET: TimeSheetRows
        public async Task<IActionResult> Index()
        {
            TimeSheet activeTimeSheet = await GetActiveTimeSheet();
              return View(activeTimeSheet.TimeSheetRows);
        }

        // GET: TimeSheetRows/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _context.TimeSheetRow == null)
            {
                return NotFound();
            }

            var timeSheetRow = await _context.TimeSheetRow
                .FirstOrDefaultAsync(m => m.Id == id);
            if (timeSheetRow == null)
            {
                return NotFound();
            }

            return View(timeSheetRow);
        }

        // GET: TimeSheetRows/Create
        public async Task<IActionResult> Create()
        {
            TimeSheetRow timeSheetRow = new TimeSheetRow(String.Empty);
            List<Project> projects = await _context.Project.ToListAsync();
            TimeSheetRowViewModel viewModel = new TimeSheetRowViewModel()
            {
                TimeSheetRow = timeSheetRow,
                Projects = projects
            };
            return View(viewModel);
        }

        // POST: TimeSheetRows/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,HoursPerday")] TimeSheetRow timeSheetRow)
        {

            if (ModelState.IsValid)
            {
                timeSheetRow.Id = Guid.NewGuid();
                _context.Add(timeSheetRow);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(timeSheetRow);
        }

        // GET: TimeSheetRows/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null || _context.TimeSheetRow == null)
            {
                return NotFound();
            }

            var timeSheetRow = await _context.TimeSheetRow.FindAsync(id);
            if (timeSheetRow == null)
            {
                return NotFound();
            }
            return View(timeSheetRow);
        }

        // POST: TimeSheetRows/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Title,HoursPerday")] TimeSheetRow timeSheetRow)
        {
            if (id != timeSheetRow.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(timeSheetRow);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TimeSheetRowExists(timeSheetRow.Id))
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
            return View(timeSheetRow);
        }

        // GET: TimeSheetRows/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _context.TimeSheetRow == null)
            {
                return NotFound();
            }

            var timeSheetRow = await _context.TimeSheetRow
                .FirstOrDefaultAsync(m => m.Id == id);
            if (timeSheetRow == null)
            {
                return NotFound();
            }

            return View(timeSheetRow);
        }

        // POST: TimeSheetRows/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (_context.TimeSheetRow == null)
            {
                return Problem("Entity set 'ApplicationDbContext.TimeSheetRow'  is null.");
            }
            var timeSheetRow = await _context.TimeSheetRow.FindAsync(id);
            if (timeSheetRow != null)
            {
                _context.TimeSheetRow.Remove(timeSheetRow);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TimeSheetRowExists(Guid id)
        {
          return _context.TimeSheetRow.Any(e => e.Id == id);
        }
    }
}
