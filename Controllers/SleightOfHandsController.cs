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
    public class SleightOfHandsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SleightOfHandsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: SleightOfHands
        public async Task<IActionResult> Index()
        {
            return View(await _context.SleightOfHand.ToListAsync());
        }

        // GET: SleightOfHands/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sleightOfHand = await _context.SleightOfHand
                .FirstOrDefaultAsync(m => m.Sleightofhandid == id);
            if (sleightOfHand == null)
            {
                return NotFound();
            }

            return View(sleightOfHand);
        }

        // GET: SleightOfHands/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SleightOfHands/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Sleightofhandid,Sleightprof")] SleightOfHand sleightOfHand)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sleightOfHand);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(sleightOfHand);
        }

        // GET: SleightOfHands/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sleightOfHand = await _context.SleightOfHand.FindAsync(id);
            if (sleightOfHand == null)
            {
                return NotFound();
            }
            return View(sleightOfHand);
        }

        // POST: SleightOfHands/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Sleightofhandid,Sleightprof")] SleightOfHand sleightOfHand)
        {
            if (id != sleightOfHand.Sleightofhandid)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sleightOfHand);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SleightOfHandExists(sleightOfHand.Sleightofhandid))
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
            return View(sleightOfHand);
        }

        // GET: SleightOfHands/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sleightOfHand = await _context.SleightOfHand
                .FirstOrDefaultAsync(m => m.Sleightofhandid == id);
            if (sleightOfHand == null)
            {
                return NotFound();
            }

            return View(sleightOfHand);
        }

        // POST: SleightOfHands/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sleightOfHand = await _context.SleightOfHand.FindAsync(id);
            _context.SleightOfHand.Remove(sleightOfHand);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SleightOfHandExists(int id)
        {
            return _context.SleightOfHand.Any(e => e.Sleightofhandid == id);
        }
    }
}
