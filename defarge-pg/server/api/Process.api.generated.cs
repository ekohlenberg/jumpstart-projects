
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
    public partial class ProcessController : ControllerBase
    {
        // GET: api/<ProcessController>
        [HttpGet]
        public IEnumerable<ProcessView> Get()
        {
            //Console.WriteLine("Processing GET List");

            List<ProcessView> processs = ProcessLogic.Create().select<ProcessView>();

            return processs;
        }

        // GET api/<ProcessController>/5
        [HttpGet("{id}")]
        public Process Get(long id)
        {
            //Console.WriteLine($"Processing Process GET ID={id}");

            Process process = ProcessLogic.Create().get(id);

            return process;
        }

        // GET api/<ProcessController>/enum
        [HttpGet("enum")]
        public IEnumerable<EnumHelper> GetEnum()
        {
            //Console.WriteLine("Processing GET Enum");

            List<Process> processs = ProcessLogic.Create().select<Process>();

            return processs.Select(process => new EnumHelper(process.id, process.getRwkString()));
        }

        // POST api/<ProcessController>
        [HttpPost]
        public ProcessView Post([FromBody] ProcessView processView)
        {
            //Console.WriteLine($"Processing Process POST: {process}");
            
            JsonHelper.ProcessJsonElements(processView);
            
            // Process any JsonElement values to ensure proper type conversion
            Process process = new Process(processView);

            
            
            ProcessLogic.Create().put(process); 

            processView.id = process.id;

            return processView;
        }

        // PUT api/<ProcessController>/5
        [HttpPut("{id}")]
        public ProcessView Put(long id, [FromBody] ProcessView processView)
        {
            //Console.WriteLine($"Processing Process PUT: ID = {id}\n{process}");
            
            // Process any JsonElement values to ensure proper type conversion
            JsonHelper.ProcessJsonElements(processView);
            
            Process process = new Process(processView);

            ProcessLogic.Create().update(id, process);

            processView.id = process.id;

            return processView;
        }

        // DELETE api/<ProcessController>/5
        [HttpDelete("{id}")]
        public void Delete(long id)
        {
            ProcessLogic.Create().delete(id);
        }

        // GET api/<ProcessController>/5/history
        [HttpGet("{id}/history")]
        public IEnumerable<ProcessHistory> GetHistory(long id)
        {
            //Console.WriteLine($"Processing GET History for ID={id}");

            List<ProcessHistory> historyList = ProcessLogic.Create().history(id);

            return historyList;
        }


        
    }
}
