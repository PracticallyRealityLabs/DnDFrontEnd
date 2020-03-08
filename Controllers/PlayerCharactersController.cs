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
    public class PlayerCharactersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PlayerCharactersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: PlayerCharacters
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.PlayerCharacter.Include(p => p.Campaign).Include(p => p.User);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: PlayerCharacters/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var playerCharacter = await _context.PlayerCharacter
                .Include(p => p.Campaign)
                .Include(p => p.User)
                .FirstOrDefaultAsync(m => m.PlayerCharacterid == id);
            if (playerCharacter == null)
            {
                return NotFound();
            }

            return View(playerCharacter);
        }

        // GET: PlayerCharacters/Create
        public IActionResult Create()
        {
            ViewData["Campaignid"] = new SelectList(_context.Campaign, "CampaignId", "CampaignId");
            ViewData["Userid"] = new SelectList(_context.Set<Users>(), "UsersId", "UsersId");
            return View();
        }

        // POST: PlayerCharacters/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PlayerCharacterid,Charactername,Class,Race,Alignment,Languages,Campaignid,Userid")] PlayerCharacter playerCharacter)
        {
            if (ModelState.IsValid)
            {
                _context.Add(playerCharacter);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Campaignid"] = new SelectList(_context.Campaign, "CampaignId", "CampaignId", playerCharacter.Campaignid);
            ViewData["Userid"] = new SelectList(_context.Set<Users>(), "UsersId", "UsersId", playerCharacter.Userid);
            return View(playerCharacter);
        }

        // GET: PlayerCharacters/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var playerCharacter = await _context.PlayerCharacter.FindAsync(id);
            if (playerCharacter == null)
            {
                return NotFound();
            }
            ViewData["Campaignid"] = new SelectList(_context.Campaign, "CampaignId", "CampaignId", playerCharacter.Campaignid);
            ViewData["Userid"] = new SelectList(_context.Set<Users>(), "UsersId", "UsersId", playerCharacter.Userid);
            return View(playerCharacter);
        }

        // POST: PlayerCharacters/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PlayerCharacterid,Charactername,Class,Race,Alignment,Languages,Campaignid,Userid")] PlayerCharacter playerCharacter)
        {
            if (id != playerCharacter.PlayerCharacterid)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(playerCharacter);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PlayerCharacterExists(playerCharacter.PlayerCharacterid))
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
            ViewData["Campaignid"] = new SelectList(_context.Campaign, "CampaignId", "CampaignId", playerCharacter.Campaignid);
            ViewData["Userid"] = new SelectList(_context.Set<Users>(), "UsersId", "UsersId", playerCharacter.Userid);
            return View(playerCharacter);
        }

        // GET: PlayerCharacters/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var playerCharacter = await _context.PlayerCharacter
                .Include(p => p.Campaign)
                .Include(p => p.User)
                .FirstOrDefaultAsync(m => m.PlayerCharacterid == id);
            if (playerCharacter == null)
            {
                return NotFound();
            }

            return View(playerCharacter);
        }

        // POST: PlayerCharacters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var playerCharacter = await _context.PlayerCharacter.FindAsync(id);
            _context.PlayerCharacter.Remove(playerCharacter);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PlayerCharacterExists(int id)
        {
            return _context.PlayerCharacter.Any(e => e.PlayerCharacterid == id);
        }
    }
}
