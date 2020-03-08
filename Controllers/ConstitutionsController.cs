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
    public class ConstitutionsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ConstitutionsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Constitutions
        public async Task<IActionResult> Index()
        {
            return View(await _context.Constitution.ToListAsync());
        }

        // GET: Constitutions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var constitution = await _context.Constitution
                .FirstOrDefaultAsync(m => m.Constitutionid == id);
            if (constitution == null)
            {
                return NotFound();
            }

            return View(constitution);
        }

        // GET: Constitutions/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Constitutions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Constitutionid,Consaveprof,Convalue")] Constitution constitution)
        {
            if (ModelState.IsValid)
            {
                _context.Add(constitution);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(constitution);
        }

        // GET: Constitutions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var constitution = await _context.Constitution.FindAsync(id);
            if (constitution == null)
            {
                return NotFound();
            }
            return View(constitution);
        }

        // POST: Constitutions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Constitutionid,Consaveprof,Convalue")] Constitution constitution)
        {
            if (id != constitution.Constitutionid)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(constitution);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ConstitutionExists(constitution.Constitutionid))
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
            return View(constitution);
        }

        // GET: Constitutions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var constitution = await _context.Constitution
                .FirstOrDefaultAsync(m => m.Constitutionid == id);
            if (constitution == null)
            {
                return NotFound();
            }

            return View(constitution);
        }

        // POST: Constitutions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var constitution = await _context.Constitution.FindAsync(id);
            _context.Constitution.Remove(constitution);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ConstitutionExists(int id)
        {
            return _context.Constitution.Any(e => e.Constitutionid == id);
        }
    }
}
