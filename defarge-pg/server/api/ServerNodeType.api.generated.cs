
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
    public partial class ServerNodeTypeController : ControllerBase
    {
        // GET: api/<ServerNodeTypeController>
        [HttpGet]
        public IEnumerable<ServerNodeTypeView> Get()
        {
            //Console.WriteLine("Processing GET List");

            List<ServerNodeTypeView> servernodetypes = ServerNodeTypeLogic.Create().select<ServerNodeTypeView>();

            return servernodetypes;
        }

        // GET api/<ServerNodeTypeController>/5
        [HttpGet("{id}")]
        public ServerNodeType Get(long id)
        {
            //Console.WriteLine($"Processing ServerNodeType GET ID={id}");

            ServerNodeType servernodetype = ServerNodeTypeLogic.Create().get(id);

            return servernodetype;
        }

        // GET api/<ServerNodeTypeController>/enum
        [HttpGet("enum")]
        public IEnumerable<EnumHelper> GetEnum()
        {
            //Console.WriteLine("Processing GET Enum");

            List<ServerNodeType> servernodetypes = ServerNodeTypeLogic.Create().select<ServerNodeType>();

            return servernodetypes.Select(servernodetype => new EnumHelper(servernodetype.id, servernodetype.getRwkString()));
        }

        // POST api/<ServerNodeTypeController>
        [HttpPost]
        public ServerNodeTypeView Post([FromBody] ServerNodeTypeView servernodetypeView)
        {
            //Console.WriteLine($"Processing ServerNodeType POST: {servernodetype}");
            
            JsonHelper.ProcessJsonElements(servernodetypeView);
            
            // Process any JsonElement values to ensure proper type conversion
            ServerNodeType servernodetype = new ServerNodeType(servernodetypeView);

            
            
            ServerNodeTypeLogic.Create().put(servernodetype); 

            servernodetypeView.id = servernodetype.id;

            return servernodetypeView;
        }

        // PUT api/<ServerNodeTypeController>/5
        [HttpPut("{id}")]
        public ServerNodeTypeView Put(long id, [FromBody] ServerNodeTypeView servernodetypeView)
        {
            //Console.WriteLine($"Processing ServerNodeType PUT: ID = {id}\n{servernodetype}");
            
            // Process any JsonElement values to ensure proper type conversion
            JsonHelper.ProcessJsonElements(servernodetypeView);
            
            ServerNodeType servernodetype = new ServerNodeType(servernodetypeView);

            ServerNodeTypeLogic.Create().update(id, servernodetype);

            servernodetypeView.id = servernodetype.id;

            return servernodetypeView;
        }

        // DELETE api/<ServerNodeTypeController>/5
        [HttpDelete("{id}")]
        public void Delete(long id)
        {
            ServerNodeTypeLogic.Create().delete(id);
        }

        // GET api/<ServerNodeTypeController>/5/history
        [HttpGet("{id}/history")]
        public IEnumerable<ServerNodeTypeHistory> GetHistory(long id)
        {
            //Console.WriteLine($"Processing GET History for ID={id}");

            List<ServerNodeTypeHistory> historyList = ServerNodeTypeLogic.Create().history(id);

            return historyList;
        }


        
    }
}
