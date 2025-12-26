using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using defarge;

namespace defarge
{
    public partial class MetricResourceMapTest : BaseTest
    {
        public static void testInsert()
        {
            var metricresourcemap = new MetricResourceMap();


                    metricresourcemap.resource_id = BaseTest.getLastId("resource");
                    
                    metricresourcemap.metric_id = BaseTest.getLastId("metric");
                    
                Logger.Info("Testing MetricResourceMapLogic insert: " + metricresourcemap.ToString());
                MetricResourceMapLogic.Create().insert(metricresourcemap);
                BaseTest.addLastId("metricresourcemap", metricresourcemap.id);
                    }

        public static void testUpdate()
        {
            long lastId = BaseTest.getLastId("metricresourcemap");
            var metricresourcemapView  = MetricResourceMapLogic.Create().get(lastId);

            MetricResourceMap metricresourcemap = new MetricResourceMap(metricresourcemapView);

                            metricresourcemap.resource_id = BaseTest.getLastId("resource");
                        
                            metricresourcemap.metric_id = BaseTest.getLastId("metric");
                        
                Logger.Info("Testing MetricResourceMapLogic update: " + metricresourcemap.ToString());
                MetricResourceMapLogic.Create().update(lastId, metricresourcemap);
                    }
    }
}
