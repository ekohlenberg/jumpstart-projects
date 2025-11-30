using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using defarge;

namespace defarge
{
    public partial class MetricTest : BaseTest
    {
        public static void testInsert()
        {
            var metric = new Metric();


                    metric.name = Convert.ToString(BaseTest.getTestData(metric, "VARCHAR", TestDataType.random));
                    
                    metric.category_id = BaseTest.getLastId("category");
                    
                    metric.uom_id = BaseTest.getLastId("uom");
                    
                Logger.Info("Testing MetricLogic insert: " + metric.ToString());
                MetricLogic.Create().insert(metric);
                BaseTest.addLastId("metric", metric.id);
                    }

        public static void testUpdate()
        {
            long lastId = BaseTest.getLastId("metric");
            var metricView  = MetricLogic.Create().get(lastId);

            Metric metric = new Metric(metricView);

                        metric.name = (string) BaseTest.getTestData(metric, "VARCHAR", TestDataType.random);
                    
                            metric.category_id = BaseTest.getLastId("category");
                        
                            metric.uom_id = BaseTest.getLastId("uom");
                        
                Logger.Info("Testing MetricLogic update: " + metric.ToString());
                MetricLogic.Create().update(lastId, metric);
                    }
    }
}
