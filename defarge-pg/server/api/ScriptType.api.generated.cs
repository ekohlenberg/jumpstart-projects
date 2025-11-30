
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
    public partial class ScriptTypeController : ControllerBase
    {
        // GET: api/<ScriptTypeController>
        [HttpGet]
        public IEnumerable<ScriptTypeView> Get()
        {
            //Console.WriteLine("Processing GET List");

            List<ScriptTypeView> scripttypes = ScriptTypeLogic.Create().select<ScriptTypeView>();

            return scripttypes;
        }

        // GET api/<ScriptTypeController>/5
        [HttpGet("{id}")]
        public ScriptType Get(long id)
        {
            //Console.WriteLine($"Processing ScriptType GET ID={id}");

            ScriptType scripttype = ScriptTypeLogic.Create().get(id);

            return scripttype;
        }

        // GET api/<ScriptTypeController>/enum
        [HttpGet("enum")]
        public IEnumerable<EnumHelper> GetEnum()
        {
            //Console.WriteLine("Processing GET Enum");

            List<ScriptType> scripttypes = ScriptTypeLogic.Create().select<ScriptType>();

            return scripttypes.Select(scripttype => new EnumHelper(scripttype.id, scripttype.getRwkString()));
        }

        // POST api/<ScriptTypeController>
        [HttpPost]
        public ScriptTypeView Post([FromBody] ScriptTypeView scripttypeView)
        {
            //Console.WriteLine($"Processing ScriptType POST: {scripttype}");
            
            JsonHelper.ProcessJsonElements(scripttypeView);
            
            // Process any JsonElement values to ensure proper type conversion
            ScriptType scripttype = new ScriptType(scripttypeView);

            
            
            ScriptTypeLogic.Create().put(scripttype); 

            scripttypeView.id = scripttype.id;

            return scripttypeView;
        }

        // PUT api/<ScriptTypeController>/5
        [HttpPut("{id}")]
        public ScriptTypeView Put(long id, [FromBody] ScriptTypeView scripttypeView)
        {
            //Console.WriteLine($"Processing ScriptType PUT: ID = {id}\n{scripttype}");
            
            // Process any JsonElement values to ensure proper type conversion
            JsonHelper.ProcessJsonElements(scripttypeView);
            
            ScriptType scripttype = new ScriptType(scripttypeView);

            ScriptTypeLogic.Create().update(id, scripttype);

            scripttypeView.id = scripttype.id;

            return scripttypeView;
        }

        // DELETE api/<ScriptTypeController>/5
        [HttpDelete("{id}")]
        public void Delete(long id)
        {
            ScriptTypeLogic.Create().delete(id);
        }

        // GET api/<ScriptTypeController>/5/history
        [HttpGet("{id}/history")]
        public IEnumerable<ScriptTypeHistory> GetHistory(long id)
        {
            //Console.WriteLine($"Processing GET History for ID={id}");

            List<ScriptTypeHistory> historyList = ScriptTypeLogic.Create().history(id);

            return historyList;
        }


        
    }
}
