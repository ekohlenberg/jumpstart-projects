using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using defarge;

namespace defarge
{
    public partial class MetricEventTest : BaseTest
    {
        public static void testInsert()
        {
            var metricevent = new MetricEvent();


                    metricevent.metric_id = BaseTest.getLastId("metric");
                    
                    metricevent.event_time = Convert.ToDateTime(BaseTest.getTestData(metricevent, "TIMESTAMP", TestDataType.random));
                    
                    metricevent.value = Convert.ToDecimal(BaseTest.getTestData(metricevent, "NUMERIC(18,4)", TestDataType.random));
                    
                Logger.Info("Testing MetricEventLogic insert: " + metricevent.ToString());
                MetricEventLogic.Create().insert(metricevent);
                BaseTest.addLastId("metricevent", metricevent.id);
                    }

        public static void testUpdate()
        {
            long lastId = BaseTest.getLastId("metricevent");
            var metriceventView  = MetricEventLogic.Create().get(lastId);

            MetricEvent metricevent = new MetricEvent(metriceventView);

                            metricevent.metric_id = BaseTest.getLastId("metric");
                        
                        metricevent.event_time = (DateTime) BaseTest.getTestData(metricevent, "TIMESTAMP", TestDataType.random);
                    
                        metricevent.value = (decimal) BaseTest.getTestData(metricevent, "NUMERIC(18,4)", TestDataType.random);
                    
                Logger.Info("Testing MetricEventLogic update: " + metricevent.ToString());
                MetricEventLogic.Create().update(lastId, metricevent);
                    }
    }
}
