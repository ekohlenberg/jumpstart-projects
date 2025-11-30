
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
    public partial class AgentController : ControllerBase
    {
        // GET: api/<AgentController>
        [HttpGet]
        public IEnumerable<AgentView> Get()
        {
            //Console.WriteLine("Processing GET List");

            List<AgentView> agents = AgentLogic.Create().select<AgentView>();

            return agents;
        }

        // GET api/<AgentController>/5
        [HttpGet("{id}")]
        public Agent Get(long id)
        {
            //Console.WriteLine($"Processing Agent GET ID={id}");

            Agent agent = AgentLogic.Create().get(id);

            return agent;
        }

        // GET api/<AgentController>/enum
        [HttpGet("enum")]
        public IEnumerable<EnumHelper> GetEnum()
        {
            //Console.WriteLine("Processing GET Enum");

            List<Agent> agents = AgentLogic.Create().select<Agent>();

            return agents.Select(agent => new EnumHelper(agent.id, agent.getRwkString()));
        }

        // POST api/<AgentController>
        [HttpPost]
        public AgentView Post([FromBody] AgentView agentView)
        {
            //Console.WriteLine($"Processing Agent POST: {agent}");
            
            JsonHelper.ProcessJsonElements(agentView);
            
            // Process any JsonElement values to ensure proper type conversion
            Agent agent = new Agent(agentView);

            
            
            AgentLogic.Create().put(agent); 

            agentView.id = agent.id;

            return agentView;
        }

        // PUT api/<AgentController>/5
        [HttpPut("{id}")]
        public AgentView Put(long id, [FromBody] AgentView agentView)
        {
            //Console.WriteLine($"Processing Agent PUT: ID = {id}\n{agent}");
            
            // Process any JsonElement values to ensure proper type conversion
            JsonHelper.ProcessJsonElements(agentView);
            
            Agent agent = new Agent(agentView);

            AgentLogic.Create().update(id, agent);

            agentView.id = agent.id;

            return agentView;
        }

        // DELETE api/<AgentController>/5
        [HttpDelete("{id}")]
        public void Delete(long id)
        {
            AgentLogic.Create().delete(id);
        }

        // GET api/<AgentController>/5/history
        [HttpGet("{id}/history")]
        public IEnumerable<AgentHistory> GetHistory(long id)
        {
            //Console.WriteLine($"Processing GET History for ID={id}");

            List<AgentHistory> historyList = AgentLogic.Create().history(id);

            return historyList;
        }


        
    }
}
