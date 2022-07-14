using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CRUD_App.Models;

namespace CRUD_App.Controllers
{
    public class AdhaarModelsController : Controller
    {
        private readonly AdhaarDBContext _context;

        public AdhaarModelsController(AdhaarDBContext context)
        {
            _context = context;
        }

        // GET: AdhaarModels
        public async Task<IActionResult> Index()
        {
              return _context.adhaar != null ? 
                          View(await _context.adhaar.ToListAsync()) :
                          Problem("Entity set 'AdhaarDBContext.adhaar'  is null.");
        }

        // GET: AdhaarModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.adhaar == null)
            {
                return NotFound();
            }

            var adhaarModel = await _context.adhaar
                .FirstOrDefaultAsync(m => m.AdhaarNumber == id);
            if (adhaarModel == null)
            {
                return NotFound();
            }

            return View(adhaarModel);
        }

        // GET: AdhaarModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AdhaarModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AdhaarNumber,Name,Age,Address")] AdhaarModel adhaarModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(adhaarModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(adhaarModel);
        }

        // GET: AdhaarModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.adhaar == null)
            {
                return NotFound();
            }

            var adhaarModel = await _context.adhaar.FindAsync(id);
            if (adhaarModel == null)
            {
                return NotFound();
            }
            return View(adhaarModel);
        }

        // POST: AdhaarModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AdhaarNumber,Name,Age,Address")] AdhaarModel adhaarModel)
        {
            if (id != adhaarModel.AdhaarNumber)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(adhaarModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AdhaarModelExists(adhaarModel.AdhaarNumber))
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
            return View(adhaarModel);
        }

        // GET: AdhaarModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.adhaar == null)
            {
                return NotFound();
            }

            var adhaarModel = await _context.adhaar
                .FirstOrDefaultAsync(m => m.AdhaarNumber == id);
            if (adhaarModel == null)
            {
                return NotFound();
            }

            return View(adhaarModel);
        }

        // POST: AdhaarModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.adhaar == null)
            {
                return Problem("Entity set 'AdhaarDBContext.adhaar'  is null.");
            }
            var adhaarModel = await _context.adhaar.FindAsync(id);
            if (adhaarModel != null)
            {
                _context.adhaar.Remove(adhaarModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AdhaarModelExists(int id)
        {
          return (_context.adhaar?.Any(e => e.AdhaarNumber == id)).GetValueOrDefault();
        }
    }
}
