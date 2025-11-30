
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
    public partial class ScheduleController : ControllerBase
    {
        // GET: api/<ScheduleController>
        [HttpGet]
        public IEnumerable<ScheduleView> Get()
        {
            //Console.WriteLine("Processing GET List");

            List<ScheduleView> schedules = ScheduleLogic.Create().select<ScheduleView>();

            return schedules;
        }

        // GET api/<ScheduleController>/5
        [HttpGet("{id}")]
        public Schedule Get(long id)
        {
            //Console.WriteLine($"Processing Schedule GET ID={id}");

            Schedule schedule = ScheduleLogic.Create().get(id);

            return schedule;
        }

        // GET api/<ScheduleController>/enum
        [HttpGet("enum")]
        public IEnumerable<EnumHelper> GetEnum()
        {
            //Console.WriteLine("Processing GET Enum");

            List<Schedule> schedules = ScheduleLogic.Create().select<Schedule>();

            return schedules.Select(schedule => new EnumHelper(schedule.id, schedule.getRwkString()));
        }

        // POST api/<ScheduleController>
        [HttpPost]
        public ScheduleView Post([FromBody] ScheduleView scheduleView)
        {
            //Console.WriteLine($"Processing Schedule POST: {schedule}");
            
            JsonHelper.ProcessJsonElements(scheduleView);
            
            // Process any JsonElement values to ensure proper type conversion
            Schedule schedule = new Schedule(scheduleView);

            
            
            ScheduleLogic.Create().put(schedule); 

            scheduleView.id = schedule.id;

            return scheduleView;
        }

        // PUT api/<ScheduleController>/5
        [HttpPut("{id}")]
        public ScheduleView Put(long id, [FromBody] ScheduleView scheduleView)
        {
            //Console.WriteLine($"Processing Schedule PUT: ID = {id}\n{schedule}");
            
            // Process any JsonElement values to ensure proper type conversion
            JsonHelper.ProcessJsonElements(scheduleView);
            
            Schedule schedule = new Schedule(scheduleView);

            ScheduleLogic.Create().update(id, schedule);

            scheduleView.id = schedule.id;

            return scheduleView;
        }

        // DELETE api/<ScheduleController>/5
        [HttpDelete("{id}")]
        public void Delete(long id)
        {
            ScheduleLogic.Create().delete(id);
        }

        // GET api/<ScheduleController>/5/history
        [HttpGet("{id}/history")]
        public IEnumerable<ScheduleHistory> GetHistory(long id)
        {
            //Console.WriteLine($"Processing GET History for ID={id}");

            List<ScheduleHistory> historyList = ScheduleLogic.Create().history(id);

            return historyList;
        }


        
    }
}
