#nullable disable
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Dungeons_And_Dragons_Character_Manager_App.Data;
using Dungeons_And_Dragons_Character_Manager_App.Models;
using Dungeons_And_Dragons_Character_Manager_App.Inventory;

namespace Dungeons_And_Dragons_Character_Manager_App.Controllers
{
    public class ItemController : Controller
    {
        private readonly CharacterManagerContext _context;

        public ItemController(CharacterManagerContext cont)
        {
            _context = cont;
            ItemInventory.Generate().ForEach((defaultData) => _context.Items.Add(defaultData));
            _context.SaveChanges();
        }

        [HttpGet]
        public IEnumerable<string> DetailAll(){
            List<string> details = new List<string>();
        
            foreach(Item x in _context.Items.ToList())
                details.Add(x.ToString());
            return details;
        }

    [HttpGet]
    public IActionResult Detail([FromBody] string name){
        Item item = _context.Items.ToList().Find(
            (thing) => thing.Name == name
        );
        
        if (item == null)
            return NotFound();
        return new ObjectResult(item.ToString());
    }
    }
}
