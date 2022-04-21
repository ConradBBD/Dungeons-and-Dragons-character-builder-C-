#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Dungeons_And_Dragons_Character_Manager_App.Data;
using Dungeons_And_Dragons_Character_Manager_App.Models;

namespace Dungeons_And_Dragons_Character_Manager_App.Controllers
{
    public class CharactersController : Controller
    {
        private readonly CharacterManagerContext _context;

        public CharactersController(CharacterManagerContext context)
        {
            _context = context;
        }

        // GET: Characters
        public async Task<IActionResult> Index()
        {
            return View(await _context.Characters.ToListAsync());
        }

        // GET: Characters/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var character = await _context.Characters
                .FirstOrDefaultAsync(m => m.ID == id);
            if (character == null)
            {
                return NotFound();
            }

            return View(character);
        }

        // POST: Characters/CreateJSON
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult<Character>> CreateJSON([Bind("ID,name,currentHitPoints,temporaryHitPoints,maxHitPoints,proficiencyBonus,armourClass,currentHitDice,totalHitDice,numGold,numSilver,numCopper,numPlatinum,numElectrum")] Character character)
        {
            _context.Add(character);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(Index), new { id = character.ID }, character);
        }

        // GET: Characters/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Characters/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,name,currentHitPoints,temporaryHitPoints,maxHitPoints,proficiencyBonus,armourClass,currentHitDice,totalHitDice,numGold,numSilver,numCopper,numPlatinum,numElectrum")] Character character)
        {
            if (ModelState.IsValid)
            {
                _context.Add(character);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(character);
        }

        // GET: Characters/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var character = await _context.Characters.FindAsync(id);
            if (character == null)
            {
                return NotFound();
            }
            return View(character);
        }

        // POST: Characters/AddClass/
        public async Task<IActionResult> AddClass(int id, [FromBody] string classname)
        {
            var character = await _context.Characters.FindAsync(id);
            if (ModelState.IsValid)
            {
                try
                {
                    if (classname.Equals("Fighter"))
                    {
                        character.CharacterClass = new Fighter();
                    }
                    else if (classname.Equals("Wizard"))
                    {
                        character.CharacterClass = new Wizard();
                    }
                    _context.Update(character);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CharacterExists(character.ID))
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
            return CreatedAtAction(nameof(Index), new { id = character.ID }, character);
        }

        // POST: Characters/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,name,playerName,currentHitPoints,temporaryHitPoints,maxHitPoints,proficiencyBonus,armourClass,experiencePoints,currentHitDice,totalHitDice,numGold,numSilver,numCopper,numPlatinum,numElectrum")] Character character)
        {
            if (id != character.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(character);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CharacterExists(character.ID))
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
            return View(character);
        }

        // GET: Characters/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var character = await _context.Characters
                .FirstOrDefaultAsync(m => m.ID == id);
            if (character == null)
            {
                return NotFound();
            }

            return View(character);
        }

        // POST: Characters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var character = await _context.Characters.FindAsync(id);
            _context.Characters.Remove(character);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CharacterExists(int id)
        {
            return _context.Characters.Any(e => e.ID == id);
        }
    }
}
