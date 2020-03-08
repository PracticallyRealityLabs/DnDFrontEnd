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
    public class DexteritiesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DexteritiesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Dexterities
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Dexterity.Include(d => d.Acrobatics).Include(d => d.Sleight).Include(d => d.Stealth);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Dexterities/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dexterity = await _context.Dexterity
                .Include(d => d.Acrobatics)
                .Include(d => d.Sleight)
                .Include(d => d.Stealth)
                .FirstOrDefaultAsync(m => m.Dexterityid == id);
            if (dexterity == null)
            {
                return NotFound();
            }

            return View(dexterity);
        }

        // GET: Dexterities/Create
        public IActionResult Create()
        {
            ViewData["Acrobaticsid"] = new SelectList(_context.Acrobatics, "Acrobaticsid", "Acrobaticsid");
            ViewData["Sleightid"] = new SelectList(_context.Set<SleightOfHand>(), "Sleightofhandid", "Sleightofhandid");
            ViewData["Stealthid"] = new SelectList(_context.Set<Stealth>(), "Stealthid", "Stealthid");
            return View();
        }

        // POST: Dexterities/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Dexterityid,Dexsaveprof,Dexvalue,Acrobaticsid,Stealthid,Sleightid")] Dexterity dexterity)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dexterity);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Acrobaticsid"] = new SelectList(_context.Acrobatics, "Acrobaticsid", "Acrobaticsid", dexterity.Acrobaticsid);
            ViewData["Sleightid"] = new SelectList(_context.Set<SleightOfHand>(), "Sleightofhandid", "Sleightofhandid", dexterity.Sleightid);
            ViewData["Stealthid"] = new SelectList(_context.Set<Stealth>(), "Stealthid", "Stealthid", dexterity.Stealthid);
            return View(dexterity);
        }

        // GET: Dexterities/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dexterity = await _context.Dexterity.FindAsync(id);
            if (dexterity == null)
            {
                return NotFound();
            }
            ViewData["Acrobaticsid"] = new SelectList(_context.Acrobatics, "Acrobaticsid", "Acrobaticsid", dexterity.Acrobaticsid);
            ViewData["Sleightid"] = new SelectList(_context.Set<SleightOfHand>(), "Sleightofhandid", "Sleightofhandid", dexterity.Sleightid);
            ViewData["Stealthid"] = new SelectList(_context.Set<Stealth>(), "Stealthid", "Stealthid", dexterity.Stealthid);
            return View(dexterity);
        }

        // POST: Dexterities/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Dexterityid,Dexsaveprof,Dexvalue,Acrobaticsid,Stealthid,Sleightid")] Dexterity dexterity)
        {
            if (id != dexterity.Dexterityid)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dexterity);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DexterityExists(dexterity.Dexterityid))
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
            ViewData["Acrobaticsid"] = new SelectList(_context.Acrobatics, "Acrobaticsid", "Acrobaticsid", dexterity.Acrobaticsid);
            ViewData["Sleightid"] = new SelectList(_context.Set<SleightOfHand>(), "Sleightofhandid", "Sleightofhandid", dexterity.Sleightid);
            ViewData["Stealthid"] = new SelectList(_context.Set<Stealth>(), "Stealthid", "Stealthid", dexterity.Stealthid);
            return View(dexterity);
        }

        // GET: Dexterities/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dexterity = await _context.Dexterity
                .Include(d => d.Acrobatics)
                .Include(d => d.Sleight)
                .Include(d => d.Stealth)
                .FirstOrDefaultAsync(m => m.Dexterityid == id);
            if (dexterity == null)
            {
                return NotFound();
            }

            return View(dexterity);
        }

        // POST: Dexterities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dexterity = await _context.Dexterity.FindAsync(id);
            _context.Dexterity.Remove(dexterity);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DexterityExists(int id)
        {
            return _context.Dexterity.Any(e => e.Dexterityid == id);
        }
    }
}
