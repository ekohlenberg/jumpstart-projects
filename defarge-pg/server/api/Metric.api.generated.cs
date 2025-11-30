
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
    public partial class MetricController : ControllerBase
    {
        // GET: api/<MetricController>
        [HttpGet]
        public IEnumerable<MetricView> Get()
        {
            //Console.WriteLine("Processing GET List");

            List<MetricView> metrics = MetricLogic.Create().select<MetricView>();

            return metrics;
        }

        // GET api/<MetricController>/5
        [HttpGet("{id}")]
        public Metric Get(long id)
        {
            //Console.WriteLine($"Processing Metric GET ID={id}");

            Metric metric = MetricLogic.Create().get(id);

            return metric;
        }

        // GET api/<MetricController>/enum
        [HttpGet("enum")]
        public IEnumerable<EnumHelper> GetEnum()
        {
            //Console.WriteLine("Processing GET Enum");

            List<Metric> metrics = MetricLogic.Create().select<Metric>();

            return metrics.Select(metric => new EnumHelper(metric.id, metric.getRwkString()));
        }

        // POST api/<MetricController>
        [HttpPost]
        public MetricView Post([FromBody] MetricView metricView)
        {
            //Console.WriteLine($"Processing Metric POST: {metric}");
            
            JsonHelper.ProcessJsonElements(metricView);
            
            // Process any JsonElement values to ensure proper type conversion
            Metric metric = new Metric(metricView);

            
            
            MetricLogic.Create().put(metric); 

            metricView.id = metric.id;

            return metricView;
        }

        // PUT api/<MetricController>/5
        [HttpPut("{id}")]
        public MetricView Put(long id, [FromBody] MetricView metricView)
        {
            //Console.WriteLine($"Processing Metric PUT: ID = {id}\n{metric}");
            
            // Process any JsonElement values to ensure proper type conversion
            JsonHelper.ProcessJsonElements(metricView);
            
            Metric metric = new Metric(metricView);

            MetricLogic.Create().update(id, metric);

            metricView.id = metric.id;

            return metricView;
        }

        // DELETE api/<MetricController>/5
        [HttpDelete("{id}")]
        public void Delete(long id)
        {
            MetricLogic.Create().delete(id);
        }

        // GET api/<MetricController>/5/history
        [HttpGet("{id}/history")]
        public IEnumerable<MetricHistory> GetHistory(long id)
        {
            //Console.WriteLine($"Processing GET History for ID={id}");

            List<MetricHistory> historyList = MetricLogic.Create().history(id);

            return historyList;
        }


        // GET api/<MetricController>/5/metricevent_metric
        [HttpGet("{id}/metricevent_metric")]
        public IEnumerable<MetricEventView> Getmetricevent_metric(long id)
        {
            //Console.WriteLine($"Processing GET Metric for Metric ID={id}");

            List<MetricEventView> metricevents = MetricLogic.Create().children<MetricEventView>(id, "metricevent-metric");

            return metricevents;
        }

            
        // GET api/<MetricController>/5/alertrule_metric
        [HttpGet("{id}/alertrule_metric")]
        public IEnumerable<AlertRuleView> Getalertrule_metric(long id)
        {
            //Console.WriteLine($"Processing GET Metric for Metric ID={id}");

            List<AlertRuleView> alertrules = MetricLogic.Create().children<AlertRuleView>(id, "alertrule-metric");

            return alertrules;
        }

            
        
    }
}
