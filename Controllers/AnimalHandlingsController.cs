using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DnDFrontEnd.Data;
using DnDFrontEnd.Models;

namespace DnDFrontEnd.Controllers
{
    public class AnimalHandlingsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AnimalHandlingsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: AnimalHandlings
        public async Task<IActionResult> Index()
        {
            return View(await _context.AnimalHandling.ToListAsync());
        }

        // GET: AnimalHandlings/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var animalHandling = await _context.AnimalHandling
                .FirstOrDefaultAsync(m => m.AnimalHandlingId == id);
            if (animalHandling == null)
            {
                return NotFound();
            }

            return View(animalHandling);
        }

        // GET: AnimalHandlings/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AnimalHandlings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AnimalHandlingId,Animalhandprof")] AnimalHandling animalHandling)
        {
            if (ModelState.IsValid)
            {
                _context.Add(animalHandling);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(animalHandling);
        }

        // GET: AnimalHandlings/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var animalHandling = await _context.AnimalHandling.FindAsync(id);
            if (animalHandling == null)
            {
                return NotFound();
            }
            return View(animalHandling);
        }

        // POST: AnimalHandlings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AnimalHandlingId,Animalhandprof")] AnimalHandling animalHandling)
        {
            if (id != animalHandling.AnimalHandlingId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(animalHandling);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AnimalHandlingExists(animalHandling.AnimalHandlingId))
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
            return View(animalHandling);
        }

        // GET: AnimalHandlings/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var animalHandling = await _context.AnimalHandling
                .FirstOrDefaultAsync(m => m.AnimalHandlingId == id);
            if (animalHandling == null)
            {
                return NotFound();
            }

            return View(animalHandling);
        }

        // POST: AnimalHandlings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var animalHandling = await _context.AnimalHandling.FindAsync(id);
            _context.AnimalHandling.Remove(animalHandling);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AnimalHandlingExists(int id)
        {
            return _context.AnimalHandling.Any(e => e.AnimalHandlingId == id);
        }
    }
}
