using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using defarge;

namespace defarge
{
    public partial class MetricTest : BaseTest
    {
        public static async Task testInsert()
        {
            var metric = new Metric();


                    metric.name = Convert.ToString(BaseTest.getTestData(metric, "VARCHAR", TestDataType.random));
                    
                    metric.category_id = BaseTest.getLastId("category");
                    
                    metric.uom_id = BaseTest.getLastId("uom");
                    
                Console.WriteLine("Testing Metric API insert: " + metric.ToString());
                await PostAsync("Metric", metric);
                BaseTest.addLastId("metric", metric.id);
                    }

        public static async Task testUpdate()
        {
            long lastId = BaseTest.getLastId("Metric");
            var metric = await GetByIdAsync<Metric>("Metric", lastId);


                        metric.name = (string) BaseTest.getTestData(metric, "VARCHAR", TestDataType.random);
                    
                            metric.category_id = BaseTest.getLastId("category");
                        
                            metric.uom_id = BaseTest.getLastId("uom");
                        
                Console.WriteLine("Testing Metric API update: " + metric.ToString());
                await PutAsync("Metric", lastId, metric);
                    }
    }
}
