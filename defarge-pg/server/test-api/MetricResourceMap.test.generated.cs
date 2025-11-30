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


                    metricresourcemap.resource_id = BaseTest.getLastId("Resource");
                    
                    metricresourcemap.metric_id = BaseTest.getLastId("Metric");
                    
                Console.WriteLine("Testing MetricResourceMap API insert: " + metricresourcemap.ToString());
                var createdMetricResourceMap = await PostAsyncReturn("MetricResourceMap", metricresourcemap);
                BaseTest.addLastId("metricresourcemap", createdMetricResourceMap.id);
                    }

        public static async Task testInsertRwkOnly()
        {
            var metricresourcemap = new MetricResourceMap();


                        metricresourcemap.resource_id = BaseTest.getLastId("Resource");
                        
                        metricresourcemap.metric_id = BaseTest.getLastId("Metric");
                        
                Console.WriteLine("Testing MetricResourceMap API insert (RWK only): " + metricresourcemap.ToString());
                var createdMetricResourceMap = await PostAsyncReturn("MetricResourceMap", metricresourcemap);
                BaseTest.addLastId("metricresourcemap", createdMetricResourceMap.id);
                    }

        public static async Task testUpdate()
        {
            long lastId = BaseTest.getLastId("metricresourcemap");
            var metricresourcemapView = await GetByIdAsync<MetricResourceMapView>("MetricResourceMap", lastId);
            var metricresourcemap = new MetricResourceMap(metricresourcemapView);


                            metricresourcemap.resource_id = BaseTest.getLastId("Resource");
                        
                            metricresourcemap.metric_id = BaseTest.getLastId("Metric");
                        
                Console.WriteLine("Testing MetricResourceMap API update: " + metricresourcemap.ToString());
                await PutAsync("MetricResourceMap", lastId, metricresourcemap);
                    }

        public static async Task testPut()
        {
            long lastId = BaseTest.getLastId("metricresourcemap");
            var metricresourcemapView = await GetByIdAsync<MetricResourceMapView>("MetricResourceMap", lastId);
            var metricresourcemap = new MetricResourceMap(metricresourcemapView);


                            metricresourcemap.resource_id = BaseTest.getLastId("Resource");
                        
                            metricresourcemap.metric_id = BaseTest.getLastId("Metric");
                        
                Console.WriteLine("Testing MetricResourceMap API update: " + metricresourcemap.ToString());
                await PutAsync("MetricResourceMap", lastId, metricresourcemap);
                    }

        public static async Task testSelect()
        {
            Console.WriteLine("Testing MetricResourceMap API select (list):");
            
            try
            {
                var metricresourcemapList = await BaseTest.GetListAsync<MetricResourceMap>("MetricResourceMap");
                
                Console.WriteLine($"Retrieved {metricresourcemapList.Count} MetricResourceMap records");
                
                if (metricresourcemapList.Count > 0)
                {
                    Console.WriteLine("First record: " + metricresourcemapList[0].ToString());
                    
                    // Output all fields for each object, one per row
                    Console.WriteLine("\nDetailed MetricResourceMap records:");
                    Console.WriteLine("=" + new string('=', 50));
                    
                    for (int i = 0; i < metricresourcemapList.Count; i++)
                    {
                        var metricresourcemap = metricresourcemapList[i];
                        Console.WriteLine($"Record {i + 1}:");
                        Console.WriteLine($"  ID: {metricresourcemap.id}");

                        Console.WriteLine($"  resource_id: {metricresourcemap.resource_id}");
                                
                        Console.WriteLine($"  metric_id: {metricresourcemap.metric_id}");
                                
                        Console.WriteLine($"  is_active: {metricresourcemap.is_active}");
                                
                        Console.WriteLine($"  created_by: {metricresourcemap.created_by}");
                                
                        Console.WriteLine($"  last_updated: {metricresourcemap.last_updated}");
                                
                        Console.WriteLine($"  last_updated_by: {metricresourcemap.last_updated_by}");
                                
                        Console.WriteLine($"  version: {metricresourcemap.version}");
                                                        Console.WriteLine();
                    }
                    
                    // Store the first record for potential use in other tests
                    BaseTest.addLastId("@(Model.TableName)", metricresourcemapList[0].id);
                }
                else
                {
                    Console.WriteLine("No MetricResourceMap records found in database");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error testing MetricResourceMap select: {ex.Message}");
                throw;
            }
        }
    }
}
