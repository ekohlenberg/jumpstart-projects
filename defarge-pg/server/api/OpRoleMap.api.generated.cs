
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
    public partial class OpRoleMapController : ControllerBase
    {
        // GET: api/<OpRoleMapController>
        [HttpGet]
        public IEnumerable<OpRoleMapView> Get()
        {
            //Console.WriteLine("Processing GET List");

            List<OpRoleMapView> oprolemaps = OpRoleMapLogic.Create().select<OpRoleMapView>();

            return oprolemaps;
        }

        // GET api/<OpRoleMapController>/5
        [HttpGet("{id}")]
        public OpRoleMap Get(long id)
        {
            //Console.WriteLine($"Processing OpRoleMap GET ID={id}");

            OpRoleMap oprolemap = OpRoleMapLogic.Create().get(id);

            return oprolemap;
        }

        // GET api/<OpRoleMapController>/enum
        [HttpGet("enum")]
        public IEnumerable<EnumHelper> GetEnum()
        {
            //Console.WriteLine("Processing GET Enum");

            List<OpRoleMap> oprolemaps = OpRoleMapLogic.Create().select<OpRoleMap>();

            return oprolemaps.Select(oprolemap => new EnumHelper(oprolemap.id, oprolemap.getRwkString()));
        }

        // POST api/<OpRoleMapController>
        [HttpPost]
        public OpRoleMapView Post([FromBody] OpRoleMapView oprolemapView)
        {
            //Console.WriteLine($"Processing OpRoleMap POST: {oprolemap}");
            
            JsonHelper.ProcessJsonElements(oprolemapView);
            
            // Process any JsonElement values to ensure proper type conversion
            OpRoleMap oprolemap = new OpRoleMap(oprolemapView);

            
            
            OpRoleMapLogic.Create().put(oprolemap); 

            oprolemapView.id = oprolemap.id;

            return oprolemapView;
        }

        // PUT api/<OpRoleMapController>/5
        [HttpPut("{id}")]
        public OpRoleMapView Put(long id, [FromBody] OpRoleMapView oprolemapView)
        {
            //Console.WriteLine($"Processing OpRoleMap PUT: ID = {id}\n{oprolemap}");
            
            // Process any JsonElement values to ensure proper type conversion
            JsonHelper.ProcessJsonElements(oprolemapView);
            
            OpRoleMap oprolemap = new OpRoleMap(oprolemapView);

            OpRoleMapLogic.Create().update(id, oprolemap);

            oprolemapView.id = oprolemap.id;

            return oprolemapView;
        }

        // DELETE api/<OpRoleMapController>/5
        [HttpDelete("{id}")]
        public void Delete(long id)
        {
            OpRoleMapLogic.Create().delete(id);
        }

        // GET api/<OpRoleMapController>/5/history
        [HttpGet("{id}/history")]
        public IEnumerable<OpRoleMapHistory> GetHistory(long id)
        {
            //Console.WriteLine($"Processing GET History for ID={id}");

            List<OpRoleMapHistory> historyList = OpRoleMapLogic.Create().history(id);

            return historyList;
        }


        
    }
}
