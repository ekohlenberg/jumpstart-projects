
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
    public partial class WorkflowProcessController : ControllerBase
    {
        // GET: api/<WorkflowProcessController>
        [HttpGet]
        public IEnumerable<WorkflowProcessView> Get()
        {
            //Console.WriteLine("Processing GET List");

            List<WorkflowProcessView> workflowprocesss = WorkflowProcessLogic.Create().select<WorkflowProcessView>();

            return workflowprocesss;
        }

        // GET api/<WorkflowProcessController>/5
        [HttpGet("{id}")]
        public WorkflowProcess Get(long id)
        {
            //Console.WriteLine($"Processing WorkflowProcess GET ID={id}");

            WorkflowProcess workflowprocess = WorkflowProcessLogic.Create().get(id);

            return workflowprocess;
        }

        // GET api/<WorkflowProcessController>/enum
        [HttpGet("enum")]
        public IEnumerable<EnumHelper> GetEnum()
        {
            //Console.WriteLine("Processing GET Enum");

            List<WorkflowProcess> workflowprocesss = WorkflowProcessLogic.Create().select<WorkflowProcess>();

            return workflowprocesss.Select(workflowprocess => new EnumHelper(workflowprocess.id, workflowprocess.getRwkString()));
        }

        // POST api/<WorkflowProcessController>
        [HttpPost]
        public WorkflowProcessView Post([FromBody] WorkflowProcessView workflowprocessView)
        {
            //Console.WriteLine($"Processing WorkflowProcess POST: {workflowprocess}");
            
            JsonHelper.ProcessJsonElements(workflowprocessView);
            
            // Process any JsonElement values to ensure proper type conversion
            WorkflowProcess workflowprocess = new WorkflowProcess(workflowprocessView);

            
            
            WorkflowProcessLogic.Create().put(workflowprocess); 

            workflowprocessView.id = workflowprocess.id;

            return workflowprocessView;
        }

        // PUT api/<WorkflowProcessController>/5
        [HttpPut("{id}")]
        public WorkflowProcessView Put(long id, [FromBody] WorkflowProcessView workflowprocessView)
        {
            //Console.WriteLine($"Processing WorkflowProcess PUT: ID = {id}\n{workflowprocess}");
            
            // Process any JsonElement values to ensure proper type conversion
            JsonHelper.ProcessJsonElements(workflowprocessView);
            
            WorkflowProcess workflowprocess = new WorkflowProcess(workflowprocessView);

            WorkflowProcessLogic.Create().update(id, workflowprocess);

            workflowprocessView.id = workflowprocess.id;

            return workflowprocessView;
        }

        // DELETE api/<WorkflowProcessController>/5
        [HttpDelete("{id}")]
        public void Delete(long id)
        {
            WorkflowProcessLogic.Create().delete(id);
        }

        // GET api/<WorkflowProcessController>/5/history
        [HttpGet("{id}/history")]
        public IEnumerable<WorkflowProcessHistory> GetHistory(long id)
        {
            //Console.WriteLine($"Processing GET History for ID={id}");

            List<WorkflowProcessHistory> historyList = WorkflowProcessLogic.Create().history(id);

            return historyList;
        }


        
    }
}
