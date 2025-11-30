
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
    public partial class SchedulerController : ControllerBase
    {
        // GET: api/<SchedulerController>
        [HttpGet]
        public IEnumerable<SchedulerView> Get()
        {
            //Console.WriteLine("Processing GET List");

            List<SchedulerView> schedulers = SchedulerLogic.Create().select<SchedulerView>();

            return schedulers;
        }

        // GET api/<SchedulerController>/5
        [HttpGet("{id}")]
        public Scheduler Get(long id)
        {
            //Console.WriteLine($"Processing Scheduler GET ID={id}");

            Scheduler scheduler = SchedulerLogic.Create().get(id);

            return scheduler;
        }

        // GET api/<SchedulerController>/enum
        [HttpGet("enum")]
        public IEnumerable<EnumHelper> GetEnum()
        {
            //Console.WriteLine("Processing GET Enum");

            List<Scheduler> schedulers = SchedulerLogic.Create().select<Scheduler>();

            return schedulers.Select(scheduler => new EnumHelper(scheduler.id, scheduler.getRwkString()));
        }

        // POST api/<SchedulerController>
        [HttpPost]
        public SchedulerView Post([FromBody] SchedulerView schedulerView)
        {
            //Console.WriteLine($"Processing Scheduler POST: {scheduler}");
            
            JsonHelper.ProcessJsonElements(schedulerView);
            
            // Process any JsonElement values to ensure proper type conversion
            Scheduler scheduler = new Scheduler(schedulerView);

            
            
            SchedulerLogic.Create().put(scheduler); 

            schedulerView.id = scheduler.id;

            return schedulerView;
        }

        // PUT api/<SchedulerController>/5
        [HttpPut("{id}")]
        public SchedulerView Put(long id, [FromBody] SchedulerView schedulerView)
        {
            //Console.WriteLine($"Processing Scheduler PUT: ID = {id}\n{scheduler}");
            
            // Process any JsonElement values to ensure proper type conversion
            JsonHelper.ProcessJsonElements(schedulerView);
            
            Scheduler scheduler = new Scheduler(schedulerView);

            SchedulerLogic.Create().update(id, scheduler);

            schedulerView.id = scheduler.id;

            return schedulerView;
        }

        // DELETE api/<SchedulerController>/5
        [HttpDelete("{id}")]
        public void Delete(long id)
        {
            SchedulerLogic.Create().delete(id);
        }

        // GET api/<SchedulerController>/5/history
        [HttpGet("{id}/history")]
        public IEnumerable<SchedulerHistory> GetHistory(long id)
        {
            //Console.WriteLine($"Processing GET History for ID={id}");

            List<SchedulerHistory> historyList = SchedulerLogic.Create().history(id);

            return historyList;
        }


        
    }
}
