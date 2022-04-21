namespace Dungeons_And_Dragons_Character_Manager_App.Controllers;

using System;

using Microsoft.AspNetCore.Mvc;
using Dungeons_And_Dragons_Character_Manager_App.Data;
using Dungeons_And_Dragons_Character_Manager_App.Models;
using Dungeons_And_Dragons_Character_Manager_App.Inventory;
using System.Text.Json;

public class SpellsController : Controller {

    private readonly CharacterManagerContext _context;

    public SpellsController(CharacterManagerContext cont){
        _context = cont;

        if (_context.Spells.ToList().Count == 0) {
            SpellsInventory.Generate().ForEach((defaultData) => _context.Spells.Add(defaultData));
            _context.SaveChanges();
        }
    }

    [HttpGet]
    public IEnumerable<string> DetailAll(){
        List<string> details = new List<string>();
    
        foreach(Spell x in _context.Spells.ToList())
            details.Add(x.ToString());
        return details;
    }

    [HttpPost]
    public IActionResult DetailOne([FromBody] JsonElement data){
        string name = data.GetProperty("name").ToString();
        Spell? theSpell = _context.Spells.ToList().Find(
            (spell) => spell.Name == name
        );

        if (theSpell == null)
            return NotFound("Spell " + name + " not found");
        return new ObjectResult(theSpell.ToString());
    }

   // [HttpPost]
   // public IEnumerable<Spell> AssignSpells([FromBody] List<string> spells){
   //     List<Spell> selected = new List<Spell>();
   //     Character hero = _context.Characters.First();
    //
 //      if (hero.CharacterClass?.GetType() == typeof(Wizard)){
    //        selected = SpellsInventory.getSpecifiedSpells(spells);
      //      ((Wizard) hero.CharacterClass).SpellList = selected;
      //      _context.SaveChanges();
      //  }
      //  return selected;
   // }
}

