using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using defarge;

namespace defarge
{
    public partial class MetricResourceMapTest : BaseTest
    {
        public static async Task testInsert()
        {
            var metricresourcemap = new MetricResourceMap();


                    metricresourcemap.resource_id = BaseTest.getLastId("resource");
                    
                    metricresourcemap.metric_id = BaseTest.getLastId("metric");
                    
                Console.WriteLine("Testing MetricResourceMap API insert: " + metricresourcemap.ToString());
                await PostAsync("MetricResourceMap", metricresourcemap);
                BaseTest.addLastId("metric_resource_map", metricresourcemap.id);
                    }

        public static async Task testUpdate()
        {
            long lastId = BaseTest.getLastId("MetricResourceMap");
            var metricresourcemap = await GetByIdAsync<MetricResourceMap>("MetricResourceMap", lastId);


                            metricresourcemap.resource_id = BaseTest.getLastId("resource");
                        
                            metricresourcemap.metric_id = BaseTest.getLastId("metric");
                        
                Console.WriteLine("Testing MetricResourceMap API update: " + metricresourcemap.ToString());
                await PutAsync("MetricResourceMap", lastId, metricresourcemap);
                    }
    }
}
