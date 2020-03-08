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
    public class StatBlocksController : Controller
    {
        private readonly ApplicationDbContext _context;

        public StatBlocksController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: StatBlocks
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.StatBlock.Include(s => s.Character).Include(s => s.Charisma).Include(s => s.Constitution).Include(s => s.Dexterity).Include(s => s.Intelligence).Include(s => s.Strength).Include(s => s.Wisdom);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: StatBlocks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var statBlock = await _context.StatBlock
                .Include(s => s.Character)
                .Include(s => s.Charisma)
                .Include(s => s.Constitution)
                .Include(s => s.Dexterity)
                .Include(s => s.Intelligence)
                .Include(s => s.Strength)
                .Include(s => s.Wisdom)
                .FirstOrDefaultAsync(m => m.Statblockid == id);
            if (statBlock == null)
            {
                return NotFound();
            }

            return View(statBlock);
        }

        // GET: StatBlocks/Create
        public IActionResult Create()
        {
            ViewData["Characterid"] = new SelectList(_context.PlayerCharacter, "PlayerCharacterid", "PlayerCharacterid");
            ViewData["Charismaid"] = new SelectList(_context.Charisma, "Charismaid", "Charismaid");
            ViewData["Constitutionid"] = new SelectList(_context.Constitution, "Constitutionid", "Constitutionid");
            ViewData["Dexterityid"] = new SelectList(_context.Dexterity, "Dexterityid", "Dexterityid");
            ViewData["Intelligenceid"] = new SelectList(_context.Intelligence, "Intelligenceid", "Intelligenceid");
            ViewData["Strengthid"] = new SelectList(_context.Set<Strength>(), "Strengthid", "Strengthid");
            ViewData["Wisdomid"] = new SelectList(_context.Set<Wisdom>(), "Wisdomid", "Wisdomid");
            return View();
        }

        // POST: StatBlocks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Statblockid,Basehp,Speed,Level,Passiveperception,Vision,Characterid,Strengthid,Dexterityid,Constitutionid,Intelligenceid,Wisdomid,Charismaid")] StatBlock statBlock)
        {
            if (ModelState.IsValid)
            {
                _context.Add(statBlock);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Characterid"] = new SelectList(_context.PlayerCharacter, "PlayerCharacterid", "PlayerCharacterid", statBlock.Characterid);
            ViewData["Charismaid"] = new SelectList(_context.Charisma, "Charismaid", "Charismaid", statBlock.Charismaid);
            ViewData["Constitutionid"] = new SelectList(_context.Constitution, "Constitutionid", "Constitutionid", statBlock.Constitutionid);
            ViewData["Dexterityid"] = new SelectList(_context.Dexterity, "Dexterityid", "Dexterityid", statBlock.Dexterityid);
            ViewData["Intelligenceid"] = new SelectList(_context.Intelligence, "Intelligenceid", "Intelligenceid", statBlock.Intelligenceid);
            ViewData["Strengthid"] = new SelectList(_context.Set<Strength>(), "Strengthid", "Strengthid", statBlock.Strengthid);
            ViewData["Wisdomid"] = new SelectList(_context.Set<Wisdom>(), "Wisdomid", "Wisdomid", statBlock.Wisdomid);
            return View(statBlock);
        }

        // GET: StatBlocks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var statBlock = await _context.StatBlock.FindAsync(id);
            if (statBlock == null)
            {
                return NotFound();
            }
            ViewData["Characterid"] = new SelectList(_context.PlayerCharacter, "PlayerCharacterid", "PlayerCharacterid", statBlock.Characterid);
            ViewData["Charismaid"] = new SelectList(_context.Charisma, "Charismaid", "Charismaid", statBlock.Charismaid);
            ViewData["Constitutionid"] = new SelectList(_context.Constitution, "Constitutionid", "Constitutionid", statBlock.Constitutionid);
            ViewData["Dexterityid"] = new SelectList(_context.Dexterity, "Dexterityid", "Dexterityid", statBlock.Dexterityid);
            ViewData["Intelligenceid"] = new SelectList(_context.Intelligence, "Intelligenceid", "Intelligenceid", statBlock.Intelligenceid);
            ViewData["Strengthid"] = new SelectList(_context.Set<Strength>(), "Strengthid", "Strengthid", statBlock.Strengthid);
            ViewData["Wisdomid"] = new SelectList(_context.Set<Wisdom>(), "Wisdomid", "Wisdomid", statBlock.Wisdomid);
            return View(statBlock);
        }

        // POST: StatBlocks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Statblockid,Basehp,Speed,Level,Passiveperception,Vision,Characterid,Strengthid,Dexterityid,Constitutionid,Intelligenceid,Wisdomid,Charismaid")] StatBlock statBlock)
        {
            if (id != statBlock.Statblockid)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(statBlock);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StatBlockExists(statBlock.Statblockid))
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
            ViewData["Characterid"] = new SelectList(_context.PlayerCharacter, "PlayerCharacterid", "PlayerCharacterid", statBlock.Characterid);
            ViewData["Charismaid"] = new SelectList(_context.Charisma, "Charismaid", "Charismaid", statBlock.Charismaid);
            ViewData["Constitutionid"] = new SelectList(_context.Constitution, "Constitutionid", "Constitutionid", statBlock.Constitutionid);
            ViewData["Dexterityid"] = new SelectList(_context.Dexterity, "Dexterityid", "Dexterityid", statBlock.Dexterityid);
            ViewData["Intelligenceid"] = new SelectList(_context.Intelligence, "Intelligenceid", "Intelligenceid", statBlock.Intelligenceid);
            ViewData["Strengthid"] = new SelectList(_context.Set<Strength>(), "Strengthid", "Strengthid", statBlock.Strengthid);
            ViewData["Wisdomid"] = new SelectList(_context.Set<Wisdom>(), "Wisdomid", "Wisdomid", statBlock.Wisdomid);
            return View(statBlock);
        }

        // GET: StatBlocks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var statBlock = await _context.StatBlock
                .Include(s => s.Character)
                .Include(s => s.Charisma)
                .Include(s => s.Constitution)
                .Include(s => s.Dexterity)
                .Include(s => s.Intelligence)
                .Include(s => s.Strength)
                .Include(s => s.Wisdom)
                .FirstOrDefaultAsync(m => m.Statblockid == id);
            if (statBlock == null)
            {
                return NotFound();
            }

            return View(statBlock);
        }

        // POST: StatBlocks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var statBlock = await _context.StatBlock.FindAsync(id);
            _context.StatBlock.Remove(statBlock);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StatBlockExists(int id)
        {
            return _context.StatBlock.Any(e => e.Statblockid == id);
        }
    }
}
