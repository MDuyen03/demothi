using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using demothi.Data;
using demothi.Models;

namespace demothi.Controllers
{
    public class lam2Controller : Controller
    {
        private readonly ApplicationDbContext _context;

        public lam2Controller(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: lam2
        public async Task<IActionResult> Index()
        {
            return View(await _context.lam2.ToListAsync());
        }

        // GET: lam2/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lam2 = await _context.lam2
                .FirstOrDefaultAsync(m => m.Id == id);
            if (lam2 == null)
            {
                return NotFound();
            }

            return View(lam2);
        }

        // GET: lam2/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: lam2/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Age")] lam2 lam2)
        {
            if (ModelState.IsValid)
            {
                _context.Add(lam2);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(lam2);
        }

        // GET: lam2/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lam2 = await _context.lam2.FindAsync(id);
            if (lam2 == null)
            {
                return NotFound();
            }
            return View(lam2);
        }

        // POST: lam2/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Age")] lam2 lam2)
        {
            if (id != lam2.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(lam2);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!lam2Exists(lam2.Id))
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
            return View(lam2);
        }

        // GET: lam2/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lam2 = await _context.lam2
                .FirstOrDefaultAsync(m => m.Id == id);
            if (lam2 == null)
            {
                return NotFound();
            }

            return View(lam2);
        }

        // POST: lam2/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var lam2 = await _context.lam2.FindAsync(id);
            if (lam2 != null)
            {
                _context.lam2.Remove(lam2);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool lam2Exists(int id)
        {
            return _context.lam2.Any(e => e.Id == id);
        }
    }
}
