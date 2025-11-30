
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
    public partial class EventServiceController : ControllerBase
    {
        // GET: api/<EventServiceController>
        [HttpGet]
        public IEnumerable<EventServiceView> Get()
        {
            //Console.WriteLine("Processing GET List");

            List<EventServiceView> eventservices = EventServiceLogic.Create().select<EventServiceView>();

            return eventservices;
        }

        // GET api/<EventServiceController>/5
        [HttpGet("{id}")]
        public EventService Get(long id)
        {
            //Console.WriteLine($"Processing EventService GET ID={id}");

            EventService eventservice = EventServiceLogic.Create().get(id);

            return eventservice;
        }

        // GET api/<EventServiceController>/enum
        [HttpGet("enum")]
        public IEnumerable<EnumHelper> GetEnum()
        {
            //Console.WriteLine("Processing GET Enum");

            List<EventService> eventservices = EventServiceLogic.Create().select<EventService>();

            return eventservices.Select(eventservice => new EnumHelper(eventservice.id, eventservice.getRwkString()));
        }

        // POST api/<EventServiceController>
        [HttpPost]
        public EventServiceView Post([FromBody] EventServiceView eventserviceView)
        {
            //Console.WriteLine($"Processing EventService POST: {eventservice}");
            
            JsonHelper.ProcessJsonElements(eventserviceView);
            
            // Process any JsonElement values to ensure proper type conversion
            EventService eventservice = new EventService(eventserviceView);

            
            
            EventServiceLogic.Create().put(eventservice); 

            eventserviceView.id = eventservice.id;

            return eventserviceView;
        }

        // PUT api/<EventServiceController>/5
        [HttpPut("{id}")]
        public EventServiceView Put(long id, [FromBody] EventServiceView eventserviceView)
        {
            //Console.WriteLine($"Processing EventService PUT: ID = {id}\n{eventservice}");
            
            // Process any JsonElement values to ensure proper type conversion
            JsonHelper.ProcessJsonElements(eventserviceView);
            
            EventService eventservice = new EventService(eventserviceView);

            EventServiceLogic.Create().update(id, eventservice);

            eventserviceView.id = eventservice.id;

            return eventserviceView;
        }

        // DELETE api/<EventServiceController>/5
        [HttpDelete("{id}")]
        public void Delete(long id)
        {
            EventServiceLogic.Create().delete(id);
        }

        // GET api/<EventServiceController>/5/history
        [HttpGet("{id}/history")]
        public IEnumerable<EventServiceHistory> GetHistory(long id)
        {
            //Console.WriteLine($"Processing GET History for ID={id}");

            List<EventServiceHistory> historyList = EventServiceLogic.Create().history(id);

            return historyList;
        }


        
    }
}
