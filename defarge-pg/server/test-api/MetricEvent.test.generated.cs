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


                    metricevent.metric_id = BaseTest.getLastId("Metric");
                    
                    metricevent.event_time = Convert.ToDateTime(BaseTest.getTestData(metricevent, "TIMESTAMP", TestDataType.random));
                    
                    metricevent.value = Convert.ToDecimal(BaseTest.getTestData(metricevent, "NUMERIC(18,4)", TestDataType.random));
                    
                Console.WriteLine("Testing MetricEvent API insert: " + metricevent.ToString());
                var createdMetricEvent = await PostAsyncReturn("MetricEvent", metricevent);
                BaseTest.addLastId("metricevent", createdMetricEvent.id);
                    }

        public static async Task testInsertRwkOnly()
        {
            var metricevent = new MetricEvent();


                        metricevent.metric_id = BaseTest.getLastId("Metric");
                        
                        metricevent.event_time = Convert.ToDateTime(BaseTest.getTestData(metricevent, "TIMESTAMP", TestDataType.random));
                        
                Console.WriteLine("Testing MetricEvent API insert (RWK only): " + metricevent.ToString());
                var createdMetricEvent = await PostAsyncReturn("MetricEvent", metricevent);
                BaseTest.addLastId("metricevent", createdMetricEvent.id);
                    }

        public static async Task testUpdate()
        {
            long lastId = BaseTest.getLastId("metricevent");
            var metriceventView = await GetByIdAsync<MetricEventView>("MetricEvent", lastId);
            var metricevent = new MetricEvent(metriceventView);


                            metricevent.metric_id = BaseTest.getLastId("Metric");
                        
                        metricevent.event_time = (DateTime) BaseTest.getTestData(metricevent, "TIMESTAMP", TestDataType.random);
                    
                        metricevent.value = (decimal) BaseTest.getTestData(metricevent, "NUMERIC(18,4)", TestDataType.random);
                    
                Console.WriteLine("Testing MetricEvent API update: " + metricevent.ToString());
                await PutAsync("MetricEvent", lastId, metricevent);
                    }

        public static async Task testPut()
        {
            long lastId = BaseTest.getLastId("metricevent");
            var metriceventView = await GetByIdAsync<MetricEventView>("MetricEvent", lastId);
            var metricevent = new MetricEvent(metriceventView);


                            metricevent.metric_id = BaseTest.getLastId("Metric");
                        
                        metricevent.event_time = (DateTime) BaseTest.getTestData(metricevent, "TIMESTAMP", TestDataType.random);
                    
                        metricevent.value = (decimal) BaseTest.getTestData(metricevent, "NUMERIC(18,4)", TestDataType.random);
                    
                Console.WriteLine("Testing MetricEvent API update: " + metricevent.ToString());
                await PutAsync("MetricEvent", lastId, metricevent);
                    }

        public static async Task testSelect()
        {
            Console.WriteLine("Testing MetricEvent API select (list):");
            
            try
            {
                var metriceventList = await BaseTest.GetListAsync<MetricEvent>("MetricEvent");
                
                Console.WriteLine($"Retrieved {metriceventList.Count} MetricEvent records");
                
                if (metriceventList.Count > 0)
                {
                    Console.WriteLine("First record: " + metriceventList[0].ToString());
                    
                    // Output all fields for each object, one per row
                    Console.WriteLine("\nDetailed MetricEvent records:");
                    Console.WriteLine("=" + new string('=', 50));
                    
                    for (int i = 0; i < metriceventList.Count; i++)
                    {
                        var metricevent = metriceventList[i];
                        Console.WriteLine($"Record {i + 1}:");
                        Console.WriteLine($"  ID: {metricevent.id}");

                        Console.WriteLine($"  metric_id: {metricevent.metric_id}");
                                
                        Console.WriteLine($"  event_time: {metricevent.event_time}");
                                
                        Console.WriteLine($"  value: {metricevent.value}");
                                
                        Console.WriteLine($"  is_active: {metricevent.is_active}");
                                
                        Console.WriteLine($"  created_by: {metricevent.created_by}");
                                
                        Console.WriteLine($"  last_updated: {metricevent.last_updated}");
                                
                        Console.WriteLine($"  last_updated_by: {metricevent.last_updated_by}");
                                
                        Console.WriteLine($"  version: {metricevent.version}");
                                                        Console.WriteLine();
                    }
                    
                    // Store the first record for potential use in other tests
                    BaseTest.addLastId("@(Model.TableName)", metriceventList[0].id);
                }
                else
                {
                    Console.WriteLine("No MetricEvent records found in database");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error testing MetricEvent select: {ex.Message}");
                throw;
            }
        }
    }
}
