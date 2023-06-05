using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MarketProspection.Data;
using MarketProspection.Models;

namespace MarketProspection.Controllers
{
    public class ProjectLengthsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProjectLengthsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ProjectLengths
        public async Task<IActionResult> Index()
        {
              return View(await _context.ProjectLengths.ToListAsync());
        }

        // GET: ProjectLengths/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ProjectLengths == null)
            {
                return NotFound();
            }

            var projectLength = await _context.ProjectLengths
                .FirstOrDefaultAsync(m => m.Id == id);
            if (projectLength == null)
            {
                return NotFound();
            }

            return View(projectLength);
        }

        // GET: ProjectLengths/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ProjectLengths/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Length")] ProjectLength projectLength)
        {
            if (ModelState.IsValid)
            {
                _context.Add(projectLength);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(projectLength);
        }

        // GET: ProjectLengths/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ProjectLengths == null)
            {
                return NotFound();
            }

            var projectLength = await _context.ProjectLengths.FindAsync(id);
            if (projectLength == null)
            {
                return NotFound();
            }
            return View(projectLength);
        }

        // POST: ProjectLengths/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Length")] ProjectLength projectLength)
        {
            if (id != projectLength.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(projectLength);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProjectLengthExists(projectLength.Id))
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
            return View(projectLength);
        }

        // GET: ProjectLengths/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ProjectLengths == null)
            {
                return NotFound();
            }

            var projectLength = await _context.ProjectLengths
                .FirstOrDefaultAsync(m => m.Id == id);
            if (projectLength == null)
            {
                return NotFound();
            }

            return View(projectLength);
        }

        // POST: ProjectLengths/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ProjectLengths == null)
            {
                return Problem("Entity set 'ApplicationDbContext.ProjectLengths'  is null.");
            }
            var projectLength = await _context.ProjectLengths.FindAsync(id);
            if (projectLength != null)
            {
                _context.ProjectLengths.Remove(projectLength);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProjectLengthExists(int id)
        {
          return _context.ProjectLengths.Any(e => e.Id == id);
        }
    }
}
