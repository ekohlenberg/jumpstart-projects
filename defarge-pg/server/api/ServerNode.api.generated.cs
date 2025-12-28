
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
    public partial class ServerNodeController : ControllerBase
    {
        // GET: api/<ServerNodeController>
        [HttpGet]
        public IEnumerable<ServerNodeView> Get()
        {
            //Console.WriteLine("Processing GET List");

            List<ServerNodeView> servernodes = ServerNodeLogic.Create().select<ServerNodeView>();

            return servernodes;
        }

        // GET api/<ServerNodeController>/5
        [HttpGet("{id}")]
        public ServerNode Get(long id)
        {
            //Console.WriteLine($"Processing ServerNode GET ID={id}");

            ServerNode servernode = ServerNodeLogic.Create().get(id);

            return servernode;
        }

        // GET api/<ServerNodeController>/enum
        [HttpGet("enum")]
        public IEnumerable<EnumHelper> GetEnum()
        {
            //Console.WriteLine("Processing GET Enum");

            List<ServerNode> servernodes = ServerNodeLogic.Create().select<ServerNode>();

            return servernodes.Select(servernode => new EnumHelper(servernode.id, servernode.getRwkString()));
        }

        // POST api/<ServerNodeController>
        [HttpPost]
        public ServerNodeView Post([FromBody] ServerNodeView servernodeView)
        {
            //Console.WriteLine($"Processing ServerNode POST: {servernode}");
            
            JsonHelper.ProcessJsonElements(servernodeView);
            
            // Process any JsonElement values to ensure proper type conversion
            ServerNode servernode = new ServerNode(servernodeView);

            
            
            ServerNodeLogic.Create().put(servernode); 

            servernodeView.id = servernode.id;

            return servernodeView;
        }

        // PUT api/<ServerNodeController>/5
        [HttpPut("{id}")]
        public ServerNodeView Put(long id, [FromBody] ServerNodeView servernodeView)
        {
            //Console.WriteLine($"Processing ServerNode PUT: ID = {id}\n{servernode}");
            
            // Process any JsonElement values to ensure proper type conversion
            JsonHelper.ProcessJsonElements(servernodeView);
            
            ServerNode servernode = new ServerNode(servernodeView);

            ServerNodeLogic.Create().update(id, servernode);

            servernodeView.id = servernode.id;

            return servernodeView;
        }

        // DELETE api/<ServerNodeController>/5
        [HttpDelete("{id}")]
        public void Delete(long id)
        {
            ServerNodeLogic.Create().delete(id);
        }

        // GET api/<ServerNodeController>/5/history
        [HttpGet("{id}/history")]
        public IEnumerable<ServerNodeHistory> GetHistory(long id)
        {
            //Console.WriteLine($"Processing GET History for ID={id}");

            List<ServerNodeHistory> historyList = ServerNodeLogic.Create().history(id);

            return historyList;
        }


        
    }
}
