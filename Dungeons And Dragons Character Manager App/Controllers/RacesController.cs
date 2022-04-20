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
    public class RacesController : Controller
    {
        private readonly CharacterManagerContext _context;

        public RacesController(CharacterManagerContext context)
        {
            _context = context;
        }

        // GET: Races
        public async Task<IActionResult> Index()
        {
            return View(await _context.Races.ToListAsync());
        }

        // GET: Races/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var race = await _context.Races
                .FirstOrDefaultAsync(m => m.ID == id);
            if (race == null)
            {
                return NotFound();
            }

            return View(race);
        }

    }
}
