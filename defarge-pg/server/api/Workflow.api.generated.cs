
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
    public partial class WorkflowController : ControllerBase
    {
        // GET: api/<WorkflowController>
        [HttpGet]
        public IEnumerable<WorkflowView> Get()
        {
            //Console.WriteLine("Processing GET List");

            List<WorkflowView> workflows = WorkflowLogic.Create().select<WorkflowView>();

            return workflows;
        }

        // GET api/<WorkflowController>/5
        [HttpGet("{id}")]
        public Workflow Get(long id)
        {
            //Console.WriteLine($"Processing Workflow GET ID={id}");

            Workflow workflow = WorkflowLogic.Create().get(id);

            return workflow;
        }

        // GET api/<WorkflowController>/enum
        [HttpGet("enum")]
        public IEnumerable<EnumHelper> GetEnum()
        {
            //Console.WriteLine("Processing GET Enum");

            List<Workflow> workflows = WorkflowLogic.Create().select<Workflow>();

            return workflows.Select(workflow => new EnumHelper(workflow.id, workflow.getRwkString()));
        }

        // POST api/<WorkflowController>
        [HttpPost]
        public WorkflowView Post([FromBody] WorkflowView workflowView)
        {
            //Console.WriteLine($"Processing Workflow POST: {workflow}");
            
            JsonHelper.ProcessJsonElements(workflowView);
            
            // Process any JsonElement values to ensure proper type conversion
            Workflow workflow = new Workflow(workflowView);

            
            
            WorkflowLogic.Create().put(workflow); 

            workflowView.id = workflow.id;

            return workflowView;
        }

        // PUT api/<WorkflowController>/5
        [HttpPut("{id}")]
        public WorkflowView Put(long id, [FromBody] WorkflowView workflowView)
        {
            //Console.WriteLine($"Processing Workflow PUT: ID = {id}\n{workflow}");
            
            // Process any JsonElement values to ensure proper type conversion
            JsonHelper.ProcessJsonElements(workflowView);
            
            Workflow workflow = new Workflow(workflowView);

            WorkflowLogic.Create().update(id, workflow);

            workflowView.id = workflow.id;

            return workflowView;
        }

        // DELETE api/<WorkflowController>/5
        [HttpDelete("{id}")]
        public void Delete(long id)
        {
            WorkflowLogic.Create().delete(id);
        }

        // GET api/<WorkflowController>/5/history
        [HttpGet("{id}/history")]
        public IEnumerable<WorkflowHistory> GetHistory(long id)
        {
            //Console.WriteLine($"Processing GET History for ID={id}");

            List<WorkflowHistory> historyList = WorkflowLogic.Create().history(id);

            return historyList;
        }


        // GET api/<WorkflowController>/5/workflow_parent_workflow
        [HttpGet("{id}/workflow_parent_workflow")]
        public IEnumerable<WorkflowView> Getworkflow_parent_workflow(long id)
        {
            //Console.WriteLine($"Processing GET  for Workflow ID={id}");

            List<WorkflowView> workflows = WorkflowLogic.Create().children<WorkflowView>(id, "workflow-parent_workflow");

            return workflows;
        }

            
        
    }
}
