
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
    public partial class ScriptController : ControllerBase
    {
        // GET: api/<ScriptController>
        [HttpGet]
        public IEnumerable<ScriptView> Get()
        {
            //Console.WriteLine("Processing GET List");

            List<ScriptView> scripts = ScriptLogic.Create().select<ScriptView>();

            return scripts;
        }

        // GET api/<ScriptController>/5
        [HttpGet("{id}")]
        public Script Get(long id)
        {
            //Console.WriteLine($"Processing Script GET ID={id}");

            Script script = ScriptLogic.Create().get(id);

            return script;
        }

        // GET api/<ScriptController>/enum
        [HttpGet("enum")]
        public IEnumerable<EnumHelper> GetEnum()
        {
            //Console.WriteLine("Processing GET Enum");

            List<Script> scripts = ScriptLogic.Create().select<Script>();

            return scripts.Select(script => new EnumHelper(script.id, script.getRwkString()));
        }

        // POST api/<ScriptController>
        [HttpPost]
        public ScriptView Post([FromBody] ScriptView scriptView)
        {
            //Console.WriteLine($"Processing Script POST: {script}");
            
            JsonHelper.ProcessJsonElements(scriptView);
            
            // Process any JsonElement values to ensure proper type conversion
            Script script = new Script(scriptView);

            
            
            ScriptLogic.Create().put(script); 

            scriptView.id = script.id;

            return scriptView;
        }

        // PUT api/<ScriptController>/5
        [HttpPut("{id}")]
        public ScriptView Put(long id, [FromBody] ScriptView scriptView)
        {
            //Console.WriteLine($"Processing Script PUT: ID = {id}\n{script}");
            
            // Process any JsonElement values to ensure proper type conversion
            JsonHelper.ProcessJsonElements(scriptView);
            
            Script script = new Script(scriptView);

            ScriptLogic.Create().update(id, script);

            scriptView.id = script.id;

            return scriptView;
        }

        // DELETE api/<ScriptController>/5
        [HttpDelete("{id}")]
        public void Delete(long id)
        {
            ScriptLogic.Create().delete(id);
        }

        // GET api/<ScriptController>/5/history
        [HttpGet("{id}/history")]
        public IEnumerable<ScriptHistory> GetHistory(long id)
        {
            //Console.WriteLine($"Processing GET History for ID={id}");

            List<ScriptHistory> historyList = ScriptLogic.Create().history(id);

            return historyList;
        }


        
    }
}
