
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
    public partial class ServerNodeStatusController : ControllerBase
    {
        // GET: api/<ServerNodeStatusController>
        [HttpGet]
        public IEnumerable<ServerNodeStatusView> Get()
        {
            //Console.WriteLine("Processing GET List");

            List<ServerNodeStatusView> servernodestatuss = ServerNodeStatusLogic.Create().select<ServerNodeStatusView>();

            return servernodestatuss;
        }

        // GET api/<ServerNodeStatusController>/5
        [HttpGet("{id}")]
        public ServerNodeStatus Get(long id)
        {
            //Console.WriteLine($"Processing ServerNodeStatus GET ID={id}");

            ServerNodeStatus servernodestatus = ServerNodeStatusLogic.Create().get(id);

            return servernodestatus;
        }

        // GET api/<ServerNodeStatusController>/enum
        [HttpGet("enum")]
        public IEnumerable<EnumHelper> GetEnum()
        {
            //Console.WriteLine("Processing GET Enum");

            List<ServerNodeStatus> servernodestatuss = ServerNodeStatusLogic.Create().select<ServerNodeStatus>();

            return servernodestatuss.Select(servernodestatus => new EnumHelper(servernodestatus.id, servernodestatus.getRwkString()));
        }

        // POST api/<ServerNodeStatusController>
        [HttpPost]
        public ServerNodeStatusView Post([FromBody] ServerNodeStatusView servernodestatusView)
        {
            //Console.WriteLine($"Processing ServerNodeStatus POST: {servernodestatus}");
            
            JsonHelper.ProcessJsonElements(servernodestatusView);
            
            // Process any JsonElement values to ensure proper type conversion
            ServerNodeStatus servernodestatus = new ServerNodeStatus(servernodestatusView);

            
            
            ServerNodeStatusLogic.Create().put(servernodestatus); 

            servernodestatusView.id = servernodestatus.id;

            return servernodestatusView;
        }

        // PUT api/<ServerNodeStatusController>/5
        [HttpPut("{id}")]
        public ServerNodeStatusView Put(long id, [FromBody] ServerNodeStatusView servernodestatusView)
        {
            //Console.WriteLine($"Processing ServerNodeStatus PUT: ID = {id}\n{servernodestatus}");
            
            // Process any JsonElement values to ensure proper type conversion
            JsonHelper.ProcessJsonElements(servernodestatusView);
            
            ServerNodeStatus servernodestatus = new ServerNodeStatus(servernodestatusView);

            ServerNodeStatusLogic.Create().update(id, servernodestatus);

            servernodestatusView.id = servernodestatus.id;

            return servernodestatusView;
        }

        // DELETE api/<ServerNodeStatusController>/5
        [HttpDelete("{id}")]
        public void Delete(long id)
        {
            ServerNodeStatusLogic.Create().delete(id);
        }

        // GET api/<ServerNodeStatusController>/5/history
        [HttpGet("{id}/history")]
        public IEnumerable<ServerNodeStatusHistory> GetHistory(long id)
        {
            //Console.WriteLine($"Processing GET History for ID={id}");

            List<ServerNodeStatusHistory> historyList = ServerNodeStatusLogic.Create().history(id);

            return historyList;
        }


        
    }
}
