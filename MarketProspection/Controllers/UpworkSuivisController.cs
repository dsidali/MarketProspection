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
    public class UpworkSuivisController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UpworkSuivisController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: UpworkSuivis
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.UpworkSuivis.Include(u => u.PricingType).Include(u => u.ProjectLength).Include(u => u.SubmittingProfile).Include(u => u.Technology);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: UpworkSuivis/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.UpworkSuivis == null)
            {
                return NotFound();
            }

            var upworkSuivi = await _context.UpworkSuivis
                .Include(u => u.PricingType)
                .Include(u => u.ProjectLength)
                .Include(u => u.SubmittingProfile)
                .Include(u => u.Technology)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (upworkSuivi == null)
            {
                return NotFound();
            }

            return View(upworkSuivi);
        }

        // GET: UpworkSuivis/Create
        public IActionResult Create()
        {
            ViewData["PricingTypeId"] = new SelectList(_context.PricingTypes, "Id", "Id");
            ViewData["ProjectLengthId"] = new SelectList(_context.ProjectLengths, "Id", "Id");
            ViewData["SubmittingProfileId"] = new SelectList(_context.SubmittingProfiles, "Id", "Id");
            ViewData["TechnologyId"] = new SelectList(_context.Technologies, "Id", "Id");
            return View();
        }

        // POST: UpworkSuivis/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ProposalDate,JobTitle,RequiredConnects,Bid,ProjectLengthId,PricingTypeId,ClientPricing,Pricing,SubmittingProfileId,JobLink,TechnologyId,Viewed,ViewDate,Response,ResponseDate,Interview,InterviewDate,Hired,HireDate")] UpworkSuivi upworkSuivi)
        {
            if (ModelState.IsValid)
            {
                _context.Add(upworkSuivi);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PricingTypeId"] = new SelectList(_context.PricingTypes, "Id", "Id", upworkSuivi.PricingTypeId);
            ViewData["ProjectLengthId"] = new SelectList(_context.ProjectLengths, "Id", "Id", upworkSuivi.ProjectLengthId);
            ViewData["SubmittingProfileId"] = new SelectList(_context.SubmittingProfiles, "Id", "Id", upworkSuivi.SubmittingProfileId);
            ViewData["TechnologyId"] = new SelectList(_context.Technologies, "Id", "Id", upworkSuivi.TechnologyId);
            return View(upworkSuivi);
        }

        // GET: UpworkSuivis/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.UpworkSuivis == null)
            {
                return NotFound();
            }

            var upworkSuivi = await _context.UpworkSuivis.FindAsync(id);
            if (upworkSuivi == null)
            {
                return NotFound();
            }
            ViewData["PricingTypeId"] = new SelectList(_context.PricingTypes, "Id", "Id", upworkSuivi.PricingTypeId);
            ViewData["ProjectLengthId"] = new SelectList(_context.ProjectLengths, "Id", "Id", upworkSuivi.ProjectLengthId);
            ViewData["SubmittingProfileId"] = new SelectList(_context.SubmittingProfiles, "Id", "Id", upworkSuivi.SubmittingProfileId);
            ViewData["TechnologyId"] = new SelectList(_context.Technologies, "Id", "Id", upworkSuivi.TechnologyId);
            return View(upworkSuivi);
        }

        // POST: UpworkSuivis/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ProposalDate,JobTitle,RequiredConnects,Bid,ProjectLengthId,PricingTypeId,ClientPricing,Pricing,SubmittingProfileId,JobLink,TechnologyId,Viewed,ViewDate,Response,ResponseDate,Interview,InterviewDate,Hired,HireDate")] UpworkSuivi upworkSuivi)
        {
            if (id != upworkSuivi.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(upworkSuivi);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UpworkSuiviExists(upworkSuivi.Id))
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
            ViewData["PricingTypeId"] = new SelectList(_context.PricingTypes, "Id", "Id", upworkSuivi.PricingTypeId);
            ViewData["ProjectLengthId"] = new SelectList(_context.ProjectLengths, "Id", "Id", upworkSuivi.ProjectLengthId);
            ViewData["SubmittingProfileId"] = new SelectList(_context.SubmittingProfiles, "Id", "Id", upworkSuivi.SubmittingProfileId);
            ViewData["TechnologyId"] = new SelectList(_context.Technologies, "Id", "Id", upworkSuivi.TechnologyId);
            return View(upworkSuivi);
        }

        // GET: UpworkSuivis/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.UpworkSuivis == null)
            {
                return NotFound();
            }

            var upworkSuivi = await _context.UpworkSuivis
                .Include(u => u.PricingType)
                .Include(u => u.ProjectLength)
                .Include(u => u.SubmittingProfile)
                .Include(u => u.Technology)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (upworkSuivi == null)
            {
                return NotFound();
            }

            return View(upworkSuivi);
        }

        // POST: UpworkSuivis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.UpworkSuivis == null)
            {
                return Problem("Entity set 'ApplicationDbContext.UpworkSuivis'  is null.");
            }
            var upworkSuivi = await _context.UpworkSuivis.FindAsync(id);
            if (upworkSuivi != null)
            {
                _context.UpworkSuivis.Remove(upworkSuivi);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UpworkSuiviExists(int id)
        {
          return _context.UpworkSuivis.Any(e => e.Id == id);
        }
    }
}
