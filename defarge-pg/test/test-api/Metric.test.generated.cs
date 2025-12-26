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
                    
                    metric.category_id = BaseTest.getLastId("Category");
                    
                    metric.uom_id = BaseTest.getLastId("Uom");
                    
                Console.WriteLine("Testing Metric API insert: " + metric.ToString());
                var createdMetric = await PostAsyncReturn("Metric", metric);
                BaseTest.addLastId("metric", createdMetric.id);
                    }

        public static async Task testInsertRwkOnly()
        {
            var metric = new Metric();


                        metric.name = Convert.ToString(BaseTest.getTestData(metric, "VARCHAR", TestDataType.random));
                        
                        metric.category_id = BaseTest.getLastId("Category");
                        
                Console.WriteLine("Testing Metric API insert (RWK only): " + metric.ToString());
                var createdMetric = await PostAsyncReturn("Metric", metric);
                BaseTest.addLastId("metric", createdMetric.id);
                    }

        public static async Task testUpdate()
        {
            long lastId = BaseTest.getLastId("metric");
            var metricView = await GetByIdAsync<MetricView>("Metric", lastId);
            var metric = new Metric(metricView);


                        metric.name = (string) BaseTest.getTestData(metric, "VARCHAR", TestDataType.random);
                    
                            metric.category_id = BaseTest.getLastId("Category");
                        
                            metric.uom_id = BaseTest.getLastId("Uom");
                        
                Console.WriteLine("Testing Metric API update: " + metric.ToString());
                await PutAsync("Metric", lastId, metric);
                    }

        public static async Task testPut()
        {
            long lastId = BaseTest.getLastId("metric");
            var metricView = await GetByIdAsync<MetricView>("Metric", lastId);
            var metric = new Metric(metricView);


                        metric.name = (string) BaseTest.getTestData(metric, "VARCHAR", TestDataType.random);
                    
                            metric.category_id = BaseTest.getLastId("Category");
                        
                            metric.uom_id = BaseTest.getLastId("Uom");
                        
                Console.WriteLine("Testing Metric API update: " + metric.ToString());
                await PutAsync("Metric", lastId, metric);
                    }

        public static async Task testSelect()
        {
            Console.WriteLine("Testing Metric API select (list):");
            
            try
            {
                var metricList = await BaseTest.GetListAsync<Metric>("Metric");
                
                Console.WriteLine($"Retrieved {metricList.Count} Metric records");
                
                if (metricList.Count > 0)
                {
                    Console.WriteLine("First record: " + metricList[0].ToString());
                    
                    // Output all fields for each object, one per row
                    Console.WriteLine("\nDetailed Metric records:");
                    Console.WriteLine("=" + new string('=', 50));
                    
                    for (int i = 0; i < metricList.Count; i++)
                    {
                        var metric = metricList[i];
                        Console.WriteLine($"Record {i + 1}:");
                        Console.WriteLine($"  ID: {metric.id}");

                        Console.WriteLine($"  name: {metric.name}");
                                
                        Console.WriteLine($"  category_id: {metric.category_id}");
                                
                        Console.WriteLine($"  uom_id: {metric.uom_id}");
                                
                        Console.WriteLine($"  is_active: {metric.is_active}");
                                
                        Console.WriteLine($"  created_by: {metric.created_by}");
                                
                        Console.WriteLine($"  last_updated: {metric.last_updated}");
                                
                        Console.WriteLine($"  last_updated_by: {metric.last_updated_by}");
                                
                        Console.WriteLine($"  version: {metric.version}");
                                                        Console.WriteLine();
                    }
                    
                    // Store the first record for potential use in other tests
                    BaseTest.addLastId("@(Model.TableName)", metricList[0].id);
                }
                else
                {
                    Console.WriteLine("No Metric records found in database");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error testing Metric select: {ex.Message}");
                throw;
            }
        }
    }
}
