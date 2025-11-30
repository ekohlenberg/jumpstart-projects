
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
    public partial class ExecutionController : ControllerBase
    {
        // GET: api/<ExecutionController>
        [HttpGet]
        public IEnumerable<ExecutionView> Get()
        {
            //Console.WriteLine("Processing GET List");

            List<ExecutionView> executions = ExecutionLogic.Create().select<ExecutionView>();

            return executions;
        }

        // GET api/<ExecutionController>/5
        [HttpGet("{id}")]
        public Execution Get(long id)
        {
            //Console.WriteLine($"Processing Execution GET ID={id}");

            Execution execution = ExecutionLogic.Create().get(id);

            return execution;
        }

        // GET api/<ExecutionController>/enum
        [HttpGet("enum")]
        public IEnumerable<EnumHelper> GetEnum()
        {
            //Console.WriteLine("Processing GET Enum");

            List<Execution> executions = ExecutionLogic.Create().select<Execution>();

            return executions.Select(execution => new EnumHelper(execution.id, execution.getRwkString()));
        }

        // POST api/<ExecutionController>
        [HttpPost]
        public ExecutionView Post([FromBody] ExecutionView executionView)
        {
            //Console.WriteLine($"Processing Execution POST: {execution}");
            
            JsonHelper.ProcessJsonElements(executionView);
            
            // Process any JsonElement values to ensure proper type conversion
            Execution execution = new Execution(executionView);

            
            
            ExecutionLogic.Create().put(execution); 

            executionView.id = execution.id;

            return executionView;
        }

        // PUT api/<ExecutionController>/5
        [HttpPut("{id}")]
        public ExecutionView Put(long id, [FromBody] ExecutionView executionView)
        {
            //Console.WriteLine($"Processing Execution PUT: ID = {id}\n{execution}");
            
            // Process any JsonElement values to ensure proper type conversion
            JsonHelper.ProcessJsonElements(executionView);
            
            Execution execution = new Execution(executionView);

            ExecutionLogic.Create().update(id, execution);

            executionView.id = execution.id;

            return executionView;
        }

        // DELETE api/<ExecutionController>/5
        [HttpDelete("{id}")]
        public void Delete(long id)
        {
            ExecutionLogic.Create().delete(id);
        }

        // GET api/<ExecutionController>/5/history
        [HttpGet("{id}/history")]
        public IEnumerable<ExecutionHistory> GetHistory(long id)
        {
            //Console.WriteLine($"Processing GET History for ID={id}");

            List<ExecutionHistory> historyList = ExecutionLogic.Create().history(id);

            return historyList;
        }


        
    }
}
