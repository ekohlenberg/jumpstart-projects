
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
    public partial class MetricResourceMapController : ControllerBase
    {
        // GET: api/<MetricResourceMapController>
        [HttpGet]
        public IEnumerable<MetricResourceMapView> Get()
        {
            //Console.WriteLine("Processing GET List");

            List<MetricResourceMapView> metricresourcemaps = MetricResourceMapLogic.Create().select<MetricResourceMapView>();

            return metricresourcemaps;
        }

        // GET api/<MetricResourceMapController>/5
        [HttpGet("{id}")]
        public MetricResourceMap Get(long id)
        {
            //Console.WriteLine($"Processing MetricResourceMap GET ID={id}");

            MetricResourceMap metricresourcemap = MetricResourceMapLogic.Create().get(id);

            return metricresourcemap;
        }

        // GET api/<MetricResourceMapController>/enum
        [HttpGet("enum")]
        public IEnumerable<EnumHelper> GetEnum()
        {
            //Console.WriteLine("Processing GET Enum");

            List<MetricResourceMap> metricresourcemaps = MetricResourceMapLogic.Create().select<MetricResourceMap>();

            return metricresourcemaps.Select(metricresourcemap => new EnumHelper(metricresourcemap.id, metricresourcemap.getRwkString()));
        }

        // POST api/<MetricResourceMapController>
        [HttpPost]
        public MetricResourceMapView Post([FromBody] MetricResourceMapView metricresourcemapView)
        {
            //Console.WriteLine($"Processing MetricResourceMap POST: {metricresourcemap}");
            
            JsonHelper.ProcessJsonElements(metricresourcemapView);
            
            // Process any JsonElement values to ensure proper type conversion
            MetricResourceMap metricresourcemap = new MetricResourceMap(metricresourcemapView);

            
            
            MetricResourceMapLogic.Create().put(metricresourcemap); 

            metricresourcemapView.id = metricresourcemap.id;

            return metricresourcemapView;
        }

        // PUT api/<MetricResourceMapController>/5
        [HttpPut("{id}")]
        public MetricResourceMapView Put(long id, [FromBody] MetricResourceMapView metricresourcemapView)
        {
            //Console.WriteLine($"Processing MetricResourceMap PUT: ID = {id}\n{metricresourcemap}");
            
            // Process any JsonElement values to ensure proper type conversion
            JsonHelper.ProcessJsonElements(metricresourcemapView);
            
            MetricResourceMap metricresourcemap = new MetricResourceMap(metricresourcemapView);

            MetricResourceMapLogic.Create().update(id, metricresourcemap);

            metricresourcemapView.id = metricresourcemap.id;

            return metricresourcemapView;
        }

        // DELETE api/<MetricResourceMapController>/5
        [HttpDelete("{id}")]
        public void Delete(long id)
        {
            MetricResourceMapLogic.Create().delete(id);
        }

        // GET api/<MetricResourceMapController>/5/history
        [HttpGet("{id}/history")]
        public IEnumerable<MetricResourceMapHistory> GetHistory(long id)
        {
            //Console.WriteLine($"Processing GET History for ID={id}");

            List<MetricResourceMapHistory> historyList = MetricResourceMapLogic.Create().history(id);

            return historyList;
        }


        
    }
}
