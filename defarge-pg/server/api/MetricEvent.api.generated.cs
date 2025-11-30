
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
    public partial class MetricEventController : ControllerBase
    {
        // GET: api/<MetricEventController>
        [HttpGet]
        public IEnumerable<MetricEventView> Get()
        {
            //Console.WriteLine("Processing GET List");

            List<MetricEventView> metricevents = MetricEventLogic.Create().select<MetricEventView>();

            return metricevents;
        }

        // GET api/<MetricEventController>/5
        [HttpGet("{id}")]
        public MetricEvent Get(long id)
        {
            //Console.WriteLine($"Processing MetricEvent GET ID={id}");

            MetricEvent metricevent = MetricEventLogic.Create().get(id);

            return metricevent;
        }

        // GET api/<MetricEventController>/enum
        [HttpGet("enum")]
        public IEnumerable<EnumHelper> GetEnum()
        {
            //Console.WriteLine("Processing GET Enum");

            List<MetricEvent> metricevents = MetricEventLogic.Create().select<MetricEvent>();

            return metricevents.Select(metricevent => new EnumHelper(metricevent.id, metricevent.getRwkString()));
        }

        // POST api/<MetricEventController>
        [HttpPost]
        public MetricEventView Post([FromBody] MetricEventView metriceventView)
        {
            //Console.WriteLine($"Processing MetricEvent POST: {metricevent}");
            
            JsonHelper.ProcessJsonElements(metriceventView);
            
            // Process any JsonElement values to ensure proper type conversion
            MetricEvent metricevent = new MetricEvent(metriceventView);

            
            
            MetricEventLogic.Create().put(metricevent); 

            metriceventView.id = metricevent.id;

            return metriceventView;
        }

        // PUT api/<MetricEventController>/5
        [HttpPut("{id}")]
        public MetricEventView Put(long id, [FromBody] MetricEventView metriceventView)
        {
            //Console.WriteLine($"Processing MetricEvent PUT: ID = {id}\n{metricevent}");
            
            // Process any JsonElement values to ensure proper type conversion
            JsonHelper.ProcessJsonElements(metriceventView);
            
            MetricEvent metricevent = new MetricEvent(metriceventView);

            MetricEventLogic.Create().update(id, metricevent);

            metriceventView.id = metricevent.id;

            return metriceventView;
        }

        // DELETE api/<MetricEventController>/5
        [HttpDelete("{id}")]
        public void Delete(long id)
        {
            MetricEventLogic.Create().delete(id);
        }

        // GET api/<MetricEventController>/5/history
        [HttpGet("{id}/history")]
        public IEnumerable<MetricEventHistory> GetHistory(long id)
        {
            //Console.WriteLine($"Processing GET History for ID={id}");

            List<MetricEventHistory> historyList = MetricEventLogic.Create().history(id);

            return historyList;
        }


        
    }
}
