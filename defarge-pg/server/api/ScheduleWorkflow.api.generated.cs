
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
    public partial class ScheduleWorkflowController : ControllerBase
    {
        // GET: api/<ScheduleWorkflowController>
        [HttpGet]
        public IEnumerable<ScheduleWorkflowView> Get()
        {
            //Console.WriteLine("Processing GET List");

            List<ScheduleWorkflowView> scheduleworkflows = ScheduleWorkflowLogic.Create().select<ScheduleWorkflowView>();

            return scheduleworkflows;
        }

        // GET api/<ScheduleWorkflowController>/5
        [HttpGet("{id}")]
        public ScheduleWorkflow Get(long id)
        {
            //Console.WriteLine($"Processing ScheduleWorkflow GET ID={id}");

            ScheduleWorkflow scheduleworkflow = ScheduleWorkflowLogic.Create().get(id);

            return scheduleworkflow;
        }

        // GET api/<ScheduleWorkflowController>/enum
        [HttpGet("enum")]
        public IEnumerable<EnumHelper> GetEnum()
        {
            //Console.WriteLine("Processing GET Enum");

            List<ScheduleWorkflow> scheduleworkflows = ScheduleWorkflowLogic.Create().select<ScheduleWorkflow>();

            return scheduleworkflows.Select(scheduleworkflow => new EnumHelper(scheduleworkflow.id, scheduleworkflow.getRwkString()));
        }

        // POST api/<ScheduleWorkflowController>
        [HttpPost]
        public ScheduleWorkflowView Post([FromBody] ScheduleWorkflowView scheduleworkflowView)
        {
            //Console.WriteLine($"Processing ScheduleWorkflow POST: {scheduleworkflow}");
            
            JsonHelper.ProcessJsonElements(scheduleworkflowView);
            
            // Process any JsonElement values to ensure proper type conversion
            ScheduleWorkflow scheduleworkflow = new ScheduleWorkflow(scheduleworkflowView);

            
            
            ScheduleWorkflowLogic.Create().put(scheduleworkflow); 

            scheduleworkflowView.id = scheduleworkflow.id;

            return scheduleworkflowView;
        }

        // PUT api/<ScheduleWorkflowController>/5
        [HttpPut("{id}")]
        public ScheduleWorkflowView Put(long id, [FromBody] ScheduleWorkflowView scheduleworkflowView)
        {
            //Console.WriteLine($"Processing ScheduleWorkflow PUT: ID = {id}\n{scheduleworkflow}");
            
            // Process any JsonElement values to ensure proper type conversion
            JsonHelper.ProcessJsonElements(scheduleworkflowView);
            
            ScheduleWorkflow scheduleworkflow = new ScheduleWorkflow(scheduleworkflowView);

            ScheduleWorkflowLogic.Create().update(id, scheduleworkflow);

            scheduleworkflowView.id = scheduleworkflow.id;

            return scheduleworkflowView;
        }

        // DELETE api/<ScheduleWorkflowController>/5
        [HttpDelete("{id}")]
        public void Delete(long id)
        {
            ScheduleWorkflowLogic.Create().delete(id);
        }

        // GET api/<ScheduleWorkflowController>/5/history
        [HttpGet("{id}/history")]
        public IEnumerable<ScheduleWorkflowHistory> GetHistory(long id)
        {
            //Console.WriteLine($"Processing GET History for ID={id}");

            List<ScheduleWorkflowHistory> historyList = ScheduleWorkflowLogic.Create().history(id);

            return historyList;
        }


        
    }
}
