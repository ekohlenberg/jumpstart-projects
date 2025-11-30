
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
    public partial class OpRoleController : ControllerBase
    {
        // GET: api/<OpRoleController>
        [HttpGet]
        public IEnumerable<OpRoleView> Get()
        {
            //Console.WriteLine("Processing GET List");

            List<OpRoleView> oproles = OpRoleLogic.Create().select<OpRoleView>();

            return oproles;
        }

        // GET api/<OpRoleController>/5
        [HttpGet("{id}")]
        public OpRole Get(long id)
        {
            //Console.WriteLine($"Processing OpRole GET ID={id}");

            OpRole oprole = OpRoleLogic.Create().get(id);

            return oprole;
        }

        // GET api/<OpRoleController>/enum
        [HttpGet("enum")]
        public IEnumerable<EnumHelper> GetEnum()
        {
            //Console.WriteLine("Processing GET Enum");

            List<OpRole> oproles = OpRoleLogic.Create().select<OpRole>();

            return oproles.Select(oprole => new EnumHelper(oprole.id, oprole.getRwkString()));
        }

        // POST api/<OpRoleController>
        [HttpPost]
        public OpRoleView Post([FromBody] OpRoleView oproleView)
        {
            //Console.WriteLine($"Processing OpRole POST: {oprole}");
            
            JsonHelper.ProcessJsonElements(oproleView);
            
            // Process any JsonElement values to ensure proper type conversion
            OpRole oprole = new OpRole(oproleView);

            
            
            OpRoleLogic.Create().put(oprole); 

            oproleView.id = oprole.id;

            return oproleView;
        }

        // PUT api/<OpRoleController>/5
        [HttpPut("{id}")]
        public OpRoleView Put(long id, [FromBody] OpRoleView oproleView)
        {
            //Console.WriteLine($"Processing OpRole PUT: ID = {id}\n{oprole}");
            
            // Process any JsonElement values to ensure proper type conversion
            JsonHelper.ProcessJsonElements(oproleView);
            
            OpRole oprole = new OpRole(oproleView);

            OpRoleLogic.Create().update(id, oprole);

            oproleView.id = oprole.id;

            return oproleView;
        }

        // DELETE api/<OpRoleController>/5
        [HttpDelete("{id}")]
        public void Delete(long id)
        {
            OpRoleLogic.Create().delete(id);
        }

        // GET api/<OpRoleController>/5/history
        [HttpGet("{id}/history")]
        public IEnumerable<OpRoleHistory> GetHistory(long id)
        {
            //Console.WriteLine($"Processing GET History for ID={id}");

            List<OpRoleHistory> historyList = OpRoleLogic.Create().history(id);

            return historyList;
        }


        
    }
}
