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
    public class lam1Controller : Controller
    {
        private readonly ApplicationDbContext _context;

        public lam1Controller(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: lam1
        public async Task<IActionResult> Index()
        {
            return View(await _context.lam1.ToListAsync());
        }

        // GET: lam1/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lam1 = await _context.lam1
                .FirstOrDefaultAsync(m => m.Id == id);
            if (lam1 == null)
            {
                return NotFound();
            }

            return View(lam1);
        }

        // GET: lam1/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: lam1/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Amount")] lam1 lam1)
        {
            if (ModelState.IsValid)
            {
                _context.Add(lam1);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(lam1);
        }

        // GET: lam1/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lam1 = await _context.lam1.FindAsync(id);
            if (lam1 == null)
            {
                return NotFound();
            }
            return View(lam1);
        }

        // POST: lam1/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Amount")] lam1 lam1)
        {
            if (id != lam1.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(lam1);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!lam1Exists(lam1.Id))
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
            return View(lam1);
        }

        // GET: lam1/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lam1 = await _context.lam1
                .FirstOrDefaultAsync(m => m.Id == id);
            if (lam1 == null)
            {
                return NotFound();
            }

            return View(lam1);
        }

        // POST: lam1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var lam1 = await _context.lam1.FindAsync(id);
            if (lam1 != null)
            {
                _context.lam1.Remove(lam1);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool lam1Exists(int id)
        {
            return _context.lam1.Any(e => e.Id == id);
        }
    }
}
