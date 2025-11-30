
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
    public partial class ResourceTypeController : ControllerBase
    {
        // GET: api/<ResourceTypeController>
        [HttpGet]
        public IEnumerable<ResourceTypeView> Get()
        {
            //Console.WriteLine("Processing GET List");

            List<ResourceTypeView> resourcetypes = ResourceTypeLogic.Create().select<ResourceTypeView>();

            return resourcetypes;
        }

        // GET api/<ResourceTypeController>/5
        [HttpGet("{id}")]
        public ResourceType Get(long id)
        {
            //Console.WriteLine($"Processing ResourceType GET ID={id}");

            ResourceType resourcetype = ResourceTypeLogic.Create().get(id);

            return resourcetype;
        }

        // GET api/<ResourceTypeController>/enum
        [HttpGet("enum")]
        public IEnumerable<EnumHelper> GetEnum()
        {
            //Console.WriteLine("Processing GET Enum");

            List<ResourceType> resourcetypes = ResourceTypeLogic.Create().select<ResourceType>();

            return resourcetypes.Select(resourcetype => new EnumHelper(resourcetype.id, resourcetype.getRwkString()));
        }

        // POST api/<ResourceTypeController>
        [HttpPost]
        public ResourceTypeView Post([FromBody] ResourceTypeView resourcetypeView)
        {
            //Console.WriteLine($"Processing ResourceType POST: {resourcetype}");
            
            JsonHelper.ProcessJsonElements(resourcetypeView);
            
            // Process any JsonElement values to ensure proper type conversion
            ResourceType resourcetype = new ResourceType(resourcetypeView);

            
            
            ResourceTypeLogic.Create().put(resourcetype); 

            resourcetypeView.id = resourcetype.id;

            return resourcetypeView;
        }

        // PUT api/<ResourceTypeController>/5
        [HttpPut("{id}")]
        public ResourceTypeView Put(long id, [FromBody] ResourceTypeView resourcetypeView)
        {
            //Console.WriteLine($"Processing ResourceType PUT: ID = {id}\n{resourcetype}");
            
            // Process any JsonElement values to ensure proper type conversion
            JsonHelper.ProcessJsonElements(resourcetypeView);
            
            ResourceType resourcetype = new ResourceType(resourcetypeView);

            ResourceTypeLogic.Create().update(id, resourcetype);

            resourcetypeView.id = resourcetype.id;

            return resourcetypeView;
        }

        // DELETE api/<ResourceTypeController>/5
        [HttpDelete("{id}")]
        public void Delete(long id)
        {
            ResourceTypeLogic.Create().delete(id);
        }

        // GET api/<ResourceTypeController>/5/history
        [HttpGet("{id}/history")]
        public IEnumerable<ResourceTypeHistory> GetHistory(long id)
        {
            //Console.WriteLine($"Processing GET History for ID={id}");

            List<ResourceTypeHistory> historyList = ResourceTypeLogic.Create().history(id);

            return historyList;
        }


        
    }
}
