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
    public class ProjectsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProjectsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Projects
        public async Task<IActionResult> Index()
        {
            List<Project> projects = await _context.Project.ToListAsync();
            List<Customer> customers = await _context.Customer.ToListAsync();
            List<ListProjectViewModel> projectsViewModel = new List<ListProjectViewModel>();

            foreach(var project in projects)
            {
                projectsViewModel.Add(new ListProjectViewModel() { Project = project, Customer = customers.Find(x => x.Id == project.Customer.Id) });
            }
            return View(projectsViewModel);
        }

        // GET: Projects/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _context.Project == null)
            {
                return NotFound();
            }

            var project = await _context.Project
                .FirstOrDefaultAsync(m => m.Id == id);
            if (project == null)
            {
                return NotFound();
            }

            return View(project);
        }

        // GET: Projects/Create
        public async Task<IActionResult> Create()
        {
            List<Customer> customers = await _context.Customer.ToListAsync();
            ProjectViewModel projectViewmodel = new ProjectViewModel()
            {
                Project = new Project(),
                Customers = customers
            };
            return View(projectViewmodel);
        }

        // POST: Projects/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name")] Project project, [Bind("CustomerId")] Guid customerId)
        {
            Customer projectCustomer = await _context.Customer.FindAsync(customerId);

            if (projectCustomer != null)
            {
                project.Id = Guid.NewGuid();
                project.Customer = projectCustomer;
                _context.Add(project);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ProjectViewModel projectViewModel = new ProjectViewModel()
            {
                Project = project,
                Customers = await _context.Customer.ToListAsync()
            };
            return View(projectViewModel);
        }

        // GET: Projects/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null || _context.Project == null)
            {
                return NotFound();
            }

            var project = await _context.Project.FindAsync(id);
            if (project == null)
            {
                return NotFound();
            }

            ProjectViewModel projectViewmodel = new ProjectViewModel()
            {
                Project = project,
                Customers = await _context.Customer.ToListAsync()
            };
            return View(projectViewmodel);
        }

        // POST: Projects/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Name")] Project project, [Bind("customerId")] Guid customerId)
        {
            Customer customer = await _context.Customer.FindAsync(customerId);
            if (id != project.Id)
            {
                return NotFound();
            }

            if (project != null && customer != null)
            {
                project.Customer = customer;
                try
                {
                    _context.Update(project);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProjectExists(project.Id))
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
            return View(project);
        }

        // GET: Projects/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _context.Project == null)
            {
                return NotFound();
            }

            var project = await _context.Project
                .FirstOrDefaultAsync(m => m.Id == id);
            if (project == null)
            {
                return NotFound();
            }

            return View(project);
        }

        // POST: Projects/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (_context.Project == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Project'  is null.");
            }
            var project = await _context.Project.FindAsync(id);
            if (project != null)
            {
                _context.Project.Remove(project);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProjectExists(Guid id)
        {
          return _context.Project.Any(e => e.Id == id);
        }
    }
}
