using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using defarge;

namespace defarge
{
    public partial class SchedulerStatusTest : BaseTest
    {
        public static async Task testInsert()
        {
            var schedulerstatus = new SchedulerStatus();


                    schedulerstatus.name = Convert.ToString(BaseTest.getTestData(schedulerstatus, "VARCHAR", TestDataType.random));
                    
                Console.WriteLine("Testing SchedulerStatus API insert: " + schedulerstatus.ToString());
                var createdSchedulerStatus = await PostAsyncReturn("SchedulerStatus", schedulerstatus);
                BaseTest.addLastId("schedulerstatus", createdSchedulerStatus.id);
                    }

        public static async Task testInsertRwkOnly()
        {
            var schedulerstatus = new SchedulerStatus();


                        schedulerstatus.name = Convert.ToString(BaseTest.getTestData(schedulerstatus, "VARCHAR", TestDataType.random));
                        
                Console.WriteLine("Testing SchedulerStatus API insert (RWK only): " + schedulerstatus.ToString());
                var createdSchedulerStatus = await PostAsyncReturn("SchedulerStatus", schedulerstatus);
                BaseTest.addLastId("schedulerstatus", createdSchedulerStatus.id);
                    }

        public static async Task testUpdate()
        {
            long lastId = BaseTest.getLastId("schedulerstatus");
            var schedulerstatusView = await GetByIdAsync<SchedulerStatusView>("SchedulerStatus", lastId);
            var schedulerstatus = new SchedulerStatus(schedulerstatusView);


                        schedulerstatus.name = (string) BaseTest.getTestData(schedulerstatus, "VARCHAR", TestDataType.random);
                    
                Console.WriteLine("Testing SchedulerStatus API update: " + schedulerstatus.ToString());
                await PutAsync("SchedulerStatus", lastId, schedulerstatus);
                    }

        public static async Task testPut()
        {
            long lastId = BaseTest.getLastId("schedulerstatus");
            var schedulerstatusView = await GetByIdAsync<SchedulerStatusView>("SchedulerStatus", lastId);
            var schedulerstatus = new SchedulerStatus(schedulerstatusView);


                        schedulerstatus.name = (string) BaseTest.getTestData(schedulerstatus, "VARCHAR", TestDataType.random);
                    
                Console.WriteLine("Testing SchedulerStatus API update: " + schedulerstatus.ToString());
                await PutAsync("SchedulerStatus", lastId, schedulerstatus);
                    }

        public static async Task testSelect()
        {
            Console.WriteLine("Testing SchedulerStatus API select (list):");
            
            try
            {
                var schedulerstatusList = await BaseTest.GetListAsync<SchedulerStatus>("SchedulerStatus");
                
                Console.WriteLine($"Retrieved {schedulerstatusList.Count} SchedulerStatus records");
                
                if (schedulerstatusList.Count > 0)
                {
                    Console.WriteLine("First record: " + schedulerstatusList[0].ToString());
                    
                    // Output all fields for each object, one per row
                    Console.WriteLine("\nDetailed SchedulerStatus records:");
                    Console.WriteLine("=" + new string('=', 50));
                    
                    for (int i = 0; i < schedulerstatusList.Count; i++)
                    {
                        var schedulerstatus = schedulerstatusList[i];
                        Console.WriteLine($"Record {i + 1}:");
                        Console.WriteLine($"  ID: {schedulerstatus.id}");

                        Console.WriteLine($"  name: {schedulerstatus.name}");
                                
                        Console.WriteLine($"  is_active: {schedulerstatus.is_active}");
                                
                        Console.WriteLine($"  created_by: {schedulerstatus.created_by}");
                                
                        Console.WriteLine($"  last_updated: {schedulerstatus.last_updated}");
                                
                        Console.WriteLine($"  last_updated_by: {schedulerstatus.last_updated_by}");
                                
                        Console.WriteLine($"  version: {schedulerstatus.version}");
                                                        Console.WriteLine();
                    }
                    
                    // Store the first record for potential use in other tests
                    BaseTest.addLastId("@(Model.TableName)", schedulerstatusList[0].id);
                }
                else
                {
                    Console.WriteLine("No SchedulerStatus records found in database");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error testing SchedulerStatus select: {ex.Message}");
                throw;
            }
        }
    }
}
