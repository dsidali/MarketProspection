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
    public class PricingTypesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PricingTypesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: PricingTypes
        public async Task<IActionResult> Index()
        {
              return View(await _context.PricingTypes.ToListAsync());
        }

        // GET: PricingTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.PricingTypes == null)
            {
                return NotFound();
            }

            var pricingType = await _context.PricingTypes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pricingType == null)
            {
                return NotFound();
            }

            return View(pricingType);
        }

        // GET: PricingTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PricingTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Pricingtype")] PricingType pricingType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pricingType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pricingType);
        }

        // GET: PricingTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.PricingTypes == null)
            {
                return NotFound();
            }

            var pricingType = await _context.PricingTypes.FindAsync(id);
            if (pricingType == null)
            {
                return NotFound();
            }
            return View(pricingType);
        }

        // POST: PricingTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Pricingtype")] PricingType pricingType)
        {
            if (id != pricingType.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pricingType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PricingTypeExists(pricingType.Id))
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
            return View(pricingType);
        }

        // GET: PricingTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.PricingTypes == null)
            {
                return NotFound();
            }

            var pricingType = await _context.PricingTypes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pricingType == null)
            {
                return NotFound();
            }

            return View(pricingType);
        }

        // POST: PricingTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.PricingTypes == null)
            {
                return Problem("Entity set 'ApplicationDbContext.PricingTypes'  is null.");
            }
            var pricingType = await _context.PricingTypes.FindAsync(id);
            if (pricingType != null)
            {
                _context.PricingTypes.Remove(pricingType);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PricingTypeExists(int id)
        {
          return _context.PricingTypes.Any(e => e.Id == id);
        }
    }
}
