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
    public class SubmittingProfilesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SubmittingProfilesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: SubmittingProfiles
        public async Task<IActionResult> Index()
        {
              return View(await _context.SubmittingProfiles.ToListAsync());
        }

        // GET: SubmittingProfiles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.SubmittingProfiles == null)
            {
                return NotFound();
            }

            var submittingProfile = await _context.SubmittingProfiles
                .FirstOrDefaultAsync(m => m.Id == id);
            if (submittingProfile == null)
            {
                return NotFound();
            }

            return View(submittingProfile);
        }

        // GET: SubmittingProfiles/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SubmittingProfiles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Profile")] SubmittingProfile submittingProfile)
        {
            if (ModelState.IsValid)
            {
                _context.Add(submittingProfile);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(submittingProfile);
        }

        // GET: SubmittingProfiles/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.SubmittingProfiles == null)
            {
                return NotFound();
            }

            var submittingProfile = await _context.SubmittingProfiles.FindAsync(id);
            if (submittingProfile == null)
            {
                return NotFound();
            }
            return View(submittingProfile);
        }

        // POST: SubmittingProfiles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Profile")] SubmittingProfile submittingProfile)
        {
            if (id != submittingProfile.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(submittingProfile);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SubmittingProfileExists(submittingProfile.Id))
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
            return View(submittingProfile);
        }

        // GET: SubmittingProfiles/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.SubmittingProfiles == null)
            {
                return NotFound();
            }

            var submittingProfile = await _context.SubmittingProfiles
                .FirstOrDefaultAsync(m => m.Id == id);
            if (submittingProfile == null)
            {
                return NotFound();
            }

            return View(submittingProfile);
        }

        // POST: SubmittingProfiles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.SubmittingProfiles == null)
            {
                return Problem("Entity set 'ApplicationDbContext.SubmittingProfiles'  is null.");
            }
            var submittingProfile = await _context.SubmittingProfiles.FindAsync(id);
            if (submittingProfile != null)
            {
                _context.SubmittingProfiles.Remove(submittingProfile);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SubmittingProfileExists(int id)
        {
          return _context.SubmittingProfiles.Any(e => e.Id == id);
        }
    }
}
