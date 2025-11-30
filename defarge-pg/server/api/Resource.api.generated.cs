
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
    public partial class ResourceController : ControllerBase
    {
        // GET: api/<ResourceController>
        [HttpGet]
        public IEnumerable<ResourceView> Get()
        {
            //Console.WriteLine("Processing GET List");

            List<ResourceView> resources = ResourceLogic.Create().select<ResourceView>();

            return resources;
        }

        // GET api/<ResourceController>/5
        [HttpGet("{id}")]
        public Resource Get(long id)
        {
            //Console.WriteLine($"Processing Resource GET ID={id}");

            Resource resource = ResourceLogic.Create().get(id);

            return resource;
        }

        // GET api/<ResourceController>/enum
        [HttpGet("enum")]
        public IEnumerable<EnumHelper> GetEnum()
        {
            //Console.WriteLine("Processing GET Enum");

            List<Resource> resources = ResourceLogic.Create().select<Resource>();

            return resources.Select(resource => new EnumHelper(resource.id, resource.getRwkString()));
        }

        // POST api/<ResourceController>
        [HttpPost]
        public ResourceView Post([FromBody] ResourceView resourceView)
        {
            //Console.WriteLine($"Processing Resource POST: {resource}");
            
            JsonHelper.ProcessJsonElements(resourceView);
            
            // Process any JsonElement values to ensure proper type conversion
            Resource resource = new Resource(resourceView);

            
            
            ResourceLogic.Create().put(resource); 

            resourceView.id = resource.id;

            return resourceView;
        }

        // PUT api/<ResourceController>/5
        [HttpPut("{id}")]
        public ResourceView Put(long id, [FromBody] ResourceView resourceView)
        {
            //Console.WriteLine($"Processing Resource PUT: ID = {id}\n{resource}");
            
            // Process any JsonElement values to ensure proper type conversion
            JsonHelper.ProcessJsonElements(resourceView);
            
            Resource resource = new Resource(resourceView);

            ResourceLogic.Create().update(id, resource);

            resourceView.id = resource.id;

            return resourceView;
        }

        // DELETE api/<ResourceController>/5
        [HttpDelete("{id}")]
        public void Delete(long id)
        {
            ResourceLogic.Create().delete(id);
        }

        // GET api/<ResourceController>/5/history
        [HttpGet("{id}/history")]
        public IEnumerable<ResourceHistory> GetHistory(long id)
        {
            //Console.WriteLine($"Processing GET History for ID={id}");

            List<ResourceHistory> historyList = ResourceLogic.Create().history(id);

            return historyList;
        }


        // GET api/<ResourceController>/5/metricresourcemap_resource
        [HttpGet("{id}/metricresourcemap_resource")]
        public IEnumerable<MetricResourceMapView> Getmetricresourcemap_resource(long id)
        {
            //Console.WriteLine($"Processing GET Resource for Resource ID={id}");

            List<MetricResourceMapView> metricresourcemaps = ResourceLogic.Create().children<MetricResourceMapView>(id, "metricresourcemap-resource");

            return metricresourcemaps;
        }

            
        
    }
}
