
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
    public partial class AgentStatusController : ControllerBase
    {
        // GET: api/<AgentStatusController>
        [HttpGet]
        public IEnumerable<AgentStatusView> Get()
        {
            //Console.WriteLine("Processing GET List");

            List<AgentStatusView> agentstatuss = AgentStatusLogic.Create().select<AgentStatusView>();

            return agentstatuss;
        }

        // GET api/<AgentStatusController>/5
        [HttpGet("{id}")]
        public AgentStatus Get(long id)
        {
            //Console.WriteLine($"Processing AgentStatus GET ID={id}");

            AgentStatus agentstatus = AgentStatusLogic.Create().get(id);

            return agentstatus;
        }

        // GET api/<AgentStatusController>/enum
        [HttpGet("enum")]
        public IEnumerable<EnumHelper> GetEnum()
        {
            //Console.WriteLine("Processing GET Enum");

            List<AgentStatus> agentstatuss = AgentStatusLogic.Create().select<AgentStatus>();

            return agentstatuss.Select(agentstatus => new EnumHelper(agentstatus.id, agentstatus.getRwkString()));
        }

        // POST api/<AgentStatusController>
        [HttpPost]
        public AgentStatusView Post([FromBody] AgentStatusView agentstatusView)
        {
            //Console.WriteLine($"Processing AgentStatus POST: {agentstatus}");
            
            JsonHelper.ProcessJsonElements(agentstatusView);
            
            // Process any JsonElement values to ensure proper type conversion
            AgentStatus agentstatus = new AgentStatus(agentstatusView);

            
            
            AgentStatusLogic.Create().put(agentstatus); 

            agentstatusView.id = agentstatus.id;

            return agentstatusView;
        }

        // PUT api/<AgentStatusController>/5
        [HttpPut("{id}")]
        public AgentStatusView Put(long id, [FromBody] AgentStatusView agentstatusView)
        {
            //Console.WriteLine($"Processing AgentStatus PUT: ID = {id}\n{agentstatus}");
            
            // Process any JsonElement values to ensure proper type conversion
            JsonHelper.ProcessJsonElements(agentstatusView);
            
            AgentStatus agentstatus = new AgentStatus(agentstatusView);

            AgentStatusLogic.Create().update(id, agentstatus);

            agentstatusView.id = agentstatus.id;

            return agentstatusView;
        }

        // DELETE api/<AgentStatusController>/5
        [HttpDelete("{id}")]
        public void Delete(long id)
        {
            AgentStatusLogic.Create().delete(id);
        }

        // GET api/<AgentStatusController>/5/history
        [HttpGet("{id}/history")]
        public IEnumerable<AgentStatusHistory> GetHistory(long id)
        {
            //Console.WriteLine($"Processing GET History for ID={id}");

            List<AgentStatusHistory> historyList = AgentStatusLogic.Create().history(id);

            return historyList;
        }


        
    }
}
