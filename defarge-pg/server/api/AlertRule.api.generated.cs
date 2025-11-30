
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
    public partial class AlertRuleController : ControllerBase
    {
        // GET: api/<AlertRuleController>
        [HttpGet]
        public IEnumerable<AlertRuleView> Get()
        {
            //Console.WriteLine("Processing GET List");

            List<AlertRuleView> alertrules = AlertRuleLogic.Create().select<AlertRuleView>();

            return alertrules;
        }

        // GET api/<AlertRuleController>/5
        [HttpGet("{id}")]
        public AlertRule Get(long id)
        {
            //Console.WriteLine($"Processing AlertRule GET ID={id}");

            AlertRule alertrule = AlertRuleLogic.Create().get(id);

            return alertrule;
        }

        // GET api/<AlertRuleController>/enum
        [HttpGet("enum")]
        public IEnumerable<EnumHelper> GetEnum()
        {
            //Console.WriteLine("Processing GET Enum");

            List<AlertRule> alertrules = AlertRuleLogic.Create().select<AlertRule>();

            return alertrules.Select(alertrule => new EnumHelper(alertrule.id, alertrule.getRwkString()));
        }

        // POST api/<AlertRuleController>
        [HttpPost]
        public AlertRuleView Post([FromBody] AlertRuleView alertruleView)
        {
            //Console.WriteLine($"Processing AlertRule POST: {alertrule}");
            
            JsonHelper.ProcessJsonElements(alertruleView);
            
            // Process any JsonElement values to ensure proper type conversion
            AlertRule alertrule = new AlertRule(alertruleView);

            
            
            AlertRuleLogic.Create().put(alertrule); 

            alertruleView.id = alertrule.id;

            return alertruleView;
        }

        // PUT api/<AlertRuleController>/5
        [HttpPut("{id}")]
        public AlertRuleView Put(long id, [FromBody] AlertRuleView alertruleView)
        {
            //Console.WriteLine($"Processing AlertRule PUT: ID = {id}\n{alertrule}");
            
            // Process any JsonElement values to ensure proper type conversion
            JsonHelper.ProcessJsonElements(alertruleView);
            
            AlertRule alertrule = new AlertRule(alertruleView);

            AlertRuleLogic.Create().update(id, alertrule);

            alertruleView.id = alertrule.id;

            return alertruleView;
        }

        // DELETE api/<AlertRuleController>/5
        [HttpDelete("{id}")]
        public void Delete(long id)
        {
            AlertRuleLogic.Create().delete(id);
        }

        // GET api/<AlertRuleController>/5/history
        [HttpGet("{id}/history")]
        public IEnumerable<AlertRuleHistory> GetHistory(long id)
        {
            //Console.WriteLine($"Processing GET History for ID={id}");

            List<AlertRuleHistory> historyList = AlertRuleLogic.Create().history(id);

            return historyList;
        }


        
    }
}
