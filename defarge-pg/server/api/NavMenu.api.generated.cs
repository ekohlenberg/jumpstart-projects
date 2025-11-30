
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using defarge;

namespace defarge.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public partial class NavMenuController : ControllerBase
    {
        // GET: api/<NavMenuController>
        [HttpGet]
        public IEnumerable<NavMenuView> Get()
        {
            //Console.WriteLine("Processing GET List");

            List<NavMenuView> navmenus = NavMenuLogic.Create().select<NavMenuView>();

            return navmenus;
        }

        // GET api/<NavMenuController>/5
        [HttpGet("{id}")]
        public NavMenu Get(long id)
        {
            //Console.WriteLine($"Processing NavMenu GET ID={id}");

            NavMenu navmenu = NavMenuLogic.Create().get(id);

            return navmenu;
        }

        // GET api/<NavMenuController>/enum
        [HttpGet("enum")]
        public IEnumerable<EnumHelper> GetEnum()
        {
            //Console.WriteLine("Processing GET Enum");

            List<NavMenu> navmenus = NavMenuLogic.Create().select<NavMenu>();

            return navmenus.Select(navmenu => new EnumHelper(navmenu.id, navmenu.getRwkString()));
        }

        // POST api/<NavMenuController>
        [HttpPost]
        public NavMenuView Post([FromBody] NavMenuView navmenuView)
        {
            //Console.WriteLine($"Processing NavMenu POST: {navmenu}");
            
            JsonHelper.ProcessJsonElements(navmenuView);
            
            // Process any JsonElement values to ensure proper type conversion
            NavMenu navmenu = new NavMenu(navmenuView);

            
            
            NavMenuLogic.Create().put(navmenu); 

            navmenuView.id = navmenu.id;

            return navmenuView;
        }

        // PUT api/<NavMenuController>/5
        [HttpPut("{id}")]
        public NavMenuView Put(long id, [FromBody] NavMenuView navmenuView)
        {
            //Console.WriteLine($"Processing NavMenu PUT: ID = {id}\n{navmenu}");
            
            // Process any JsonElement values to ensure proper type conversion
            JsonHelper.ProcessJsonElements(navmenuView);
            
            NavMenu navmenu = new NavMenu(navmenuView);

            NavMenuLogic.Create().update(id, navmenu);

            navmenuView.id = navmenu.id;

            return navmenuView;
        }

        // DELETE api/<NavMenuController>/5
        [HttpDelete("{id}")]
        public void Delete(long id)
        {
            NavMenuLogic.Create().delete(id);
        }

        // GET api/<NavMenuController>/5/history
        [HttpGet("{id}/history")]
        public IEnumerable<NavMenuHistory> GetHistory(long id)
        {
            //Console.WriteLine($"Processing GET History for ID={id}");

            List<NavMenuHistory> historyList = NavMenuLogic.Create().history(id);

            return historyList;
        }


        // GET api/<NavMenuController>/5/navmenu_parent
        [HttpGet("{id}/navmenu_parent")]
        public IEnumerable<NavMenuView> Getnavmenu_parent(long id)
        {
            //Console.WriteLine($"Processing GET Parent Menu ID for NavMenu ID={id}");

            List<NavMenuView> navmenus = NavMenuLogic.Create().children<NavMenuView>(id, "navmenu-parent");

            return navmenus;
        }

            
        
    }
}
