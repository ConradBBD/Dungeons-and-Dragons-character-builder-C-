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

    public IEnumerable<Spell> SpellList(){
        return _context.Spells.ToList();
    }
}