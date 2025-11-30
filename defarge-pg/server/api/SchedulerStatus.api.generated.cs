
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
    public partial class SchedulerStatusController : ControllerBase
    {
        // GET: api/<SchedulerStatusController>
        [HttpGet]
        public IEnumerable<SchedulerStatusView> Get()
        {
            //Console.WriteLine("Processing GET List");

            List<SchedulerStatusView> schedulerstatuss = SchedulerStatusLogic.Create().select<SchedulerStatusView>();

            return schedulerstatuss;
        }

        // GET api/<SchedulerStatusController>/5
        [HttpGet("{id}")]
        public SchedulerStatus Get(long id)
        {
            //Console.WriteLine($"Processing SchedulerStatus GET ID={id}");

            SchedulerStatus schedulerstatus = SchedulerStatusLogic.Create().get(id);

            return schedulerstatus;
        }

        // GET api/<SchedulerStatusController>/enum
        [HttpGet("enum")]
        public IEnumerable<EnumHelper> GetEnum()
        {
            //Console.WriteLine("Processing GET Enum");

            List<SchedulerStatus> schedulerstatuss = SchedulerStatusLogic.Create().select<SchedulerStatus>();

            return schedulerstatuss.Select(schedulerstatus => new EnumHelper(schedulerstatus.id, schedulerstatus.getRwkString()));
        }

        // POST api/<SchedulerStatusController>
        [HttpPost]
        public SchedulerStatusView Post([FromBody] SchedulerStatusView schedulerstatusView)
        {
            //Console.WriteLine($"Processing SchedulerStatus POST: {schedulerstatus}");
            
            JsonHelper.ProcessJsonElements(schedulerstatusView);
            
            // Process any JsonElement values to ensure proper type conversion
            SchedulerStatus schedulerstatus = new SchedulerStatus(schedulerstatusView);

            
            
            SchedulerStatusLogic.Create().put(schedulerstatus); 

            schedulerstatusView.id = schedulerstatus.id;

            return schedulerstatusView;
        }

        // PUT api/<SchedulerStatusController>/5
        [HttpPut("{id}")]
        public SchedulerStatusView Put(long id, [FromBody] SchedulerStatusView schedulerstatusView)
        {
            //Console.WriteLine($"Processing SchedulerStatus PUT: ID = {id}\n{schedulerstatus}");
            
            // Process any JsonElement values to ensure proper type conversion
            JsonHelper.ProcessJsonElements(schedulerstatusView);
            
            SchedulerStatus schedulerstatus = new SchedulerStatus(schedulerstatusView);

            SchedulerStatusLogic.Create().update(id, schedulerstatus);

            schedulerstatusView.id = schedulerstatus.id;

            return schedulerstatusView;
        }

        // DELETE api/<SchedulerStatusController>/5
        [HttpDelete("{id}")]
        public void Delete(long id)
        {
            SchedulerStatusLogic.Create().delete(id);
        }

        // GET api/<SchedulerStatusController>/5/history
        [HttpGet("{id}/history")]
        public IEnumerable<SchedulerStatusHistory> GetHistory(long id)
        {
            //Console.WriteLine($"Processing GET History for ID={id}");

            List<SchedulerStatusHistory> historyList = SchedulerStatusLogic.Create().history(id);

            return historyList;
        }


        
    }
}
