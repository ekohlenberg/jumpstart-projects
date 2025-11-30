
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
    public partial class AlertController : ControllerBase
    {
        // GET: api/<AlertController>
        [HttpGet]
        public IEnumerable<AlertView> Get()
        {
            //Console.WriteLine("Processing GET List");

            List<AlertView> alerts = AlertLogic.Create().select<AlertView>();

            return alerts;
        }

        // GET api/<AlertController>/5
        [HttpGet("{id}")]
        public Alert Get(long id)
        {
            //Console.WriteLine($"Processing Alert GET ID={id}");

            Alert alert = AlertLogic.Create().get(id);

            return alert;
        }

        // GET api/<AlertController>/enum
        [HttpGet("enum")]
        public IEnumerable<EnumHelper> GetEnum()
        {
            //Console.WriteLine("Processing GET Enum");

            List<Alert> alerts = AlertLogic.Create().select<Alert>();

            return alerts.Select(alert => new EnumHelper(alert.id, alert.getRwkString()));
        }

        // POST api/<AlertController>
        [HttpPost]
        public AlertView Post([FromBody] AlertView alertView)
        {
            //Console.WriteLine($"Processing Alert POST: {alert}");
            
            JsonHelper.ProcessJsonElements(alertView);
            
            // Process any JsonElement values to ensure proper type conversion
            Alert alert = new Alert(alertView);

            
            
            AlertLogic.Create().put(alert); 

            alertView.id = alert.id;

            return alertView;
        }

        // PUT api/<AlertController>/5
        [HttpPut("{id}")]
        public AlertView Put(long id, [FromBody] AlertView alertView)
        {
            //Console.WriteLine($"Processing Alert PUT: ID = {id}\n{alert}");
            
            // Process any JsonElement values to ensure proper type conversion
            JsonHelper.ProcessJsonElements(alertView);
            
            Alert alert = new Alert(alertView);

            AlertLogic.Create().update(id, alert);

            alertView.id = alert.id;

            return alertView;
        }

        // DELETE api/<AlertController>/5
        [HttpDelete("{id}")]
        public void Delete(long id)
        {
            AlertLogic.Create().delete(id);
        }

        // GET api/<AlertController>/5/history
        [HttpGet("{id}/history")]
        public IEnumerable<AlertHistory> GetHistory(long id)
        {
            //Console.WriteLine($"Processing GET History for ID={id}");

            List<AlertHistory> historyList = AlertLogic.Create().history(id);

            return historyList;
        }


        
    }
}
