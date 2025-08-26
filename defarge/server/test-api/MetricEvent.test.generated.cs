using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using defarge;

namespace defarge
{
    public partial class MetricEventTest : BaseTest
    {
        public static async Task testInsert()
        {
            var metricevent = new MetricEvent();


                    metricevent.metric_id = BaseTest.getLastId("metric");
                    
                    metricevent.event_time = Convert.ToDateTime(BaseTest.getTestData(metricevent, "TIMESTAMP", TestDataType.random));
                    
                    metricevent.value = Convert.ToDecimal(BaseTest.getTestData(metricevent, "NUMERIC(18,4)", TestDataType.random));
                    
                Console.WriteLine("Testing MetricEvent API insert: " + metricevent.ToString());
                await PostAsync("MetricEvent", metricevent);
                BaseTest.addLastId("metric_event", metricevent.id);
                    }

        public static async Task testUpdate()
        {
            long lastId = BaseTest.getLastId("MetricEvent");
            var metricevent = await GetByIdAsync<MetricEvent>("MetricEvent", lastId);


                            metricevent.metric_id = BaseTest.getLastId("metric");
                        
                        metricevent.event_time = (DateTime) BaseTest.getTestData(metricevent, "TIMESTAMP", TestDataType.random);
                    
                        metricevent.value = (object) BaseTest.getTestData(metricevent, "NUMERIC(18,4)", TestDataType.random);
                    
                Console.WriteLine("Testing MetricEvent API update: " + metricevent.ToString());
                await PutAsync("MetricEvent", lastId, metricevent);
                    }
    }
}
