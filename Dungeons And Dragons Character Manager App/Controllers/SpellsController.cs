namespace Dungeons_And_Dragons_Character_Manager_App.Controllers;

using System;


// using System.Collections.Generic;
// using System.Linq;
// using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
// using Microsoft.AspNetCore.Mvc.Rendering;
// using Microsoft.EntityFrameworkCore;
using Dungeons_And_Dragons_Character_Manager_App.Data;
using Dungeons_And_Dragons_Character_Manager_App.Models;
using Dungeons_And_Dragons_Character_Manager_App.Inventory;

public class SpellsController : Controller {

    private readonly CharacterManagerContext _context;

    public SpellsController(CharacterManagerContext cont){
        _context = cont;

        SpellsInventory.Generate().ForEach((defaultData) => _context.Spells.Add(defaultData));
        _context.SaveChanges();
    }

    [HttpGet]
    public IEnumerable<string> DetailAll(){
        List<string> details = new List<string>();
    
        foreach(Spell x in _context.Spells.ToList())
            details.Add(x.ToString());
        return details;
    }

    [HttpGet]
    public IActionResult Detail([FromBody] string name){
        Spell? theSpell = _context.Spells.ToList().Find(
            (spell) => spell.Name == name
        );
        
        if (theSpell == null)
            return NotFound();
        return new ObjectResult(theSpell.ToString());
    }

    [HttpPost]
    public IEnumerable<Spell> AssignSpells([FromBody] List<string> spells){
        List<Spell> selected = new List<Spell>();
        Character hero = _context.Characters.First();

        if (hero.CharacterClass?.GetType() == typeof(Wizard)){
            selected = SpellsInventory.getSpecifiedSpells(spells);
            ((Wizard) hero.CharacterClass).SpellList = selected;
        }
        return selected;
    }
}

