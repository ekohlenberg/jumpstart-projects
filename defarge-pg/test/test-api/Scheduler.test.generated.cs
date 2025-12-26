using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using defarge;

namespace defarge
{
    public partial class SchedulerTest : BaseTest
    {
        public static async Task testInsert()
        {
            var scheduler = new Scheduler();


                    scheduler.hostname = Convert.ToString(BaseTest.getTestData(scheduler, "VARCHAR", TestDataType.random));
                    
                    scheduler.ip_address = Convert.ToString(BaseTest.getTestData(scheduler, "VARCHAR", TestDataType.random));
                    
                    scheduler.port = Convert.ToInt32(BaseTest.getTestData(scheduler, "INTEGER", TestDataType.random));
                    
                    scheduler.username = Convert.ToString(BaseTest.getTestData(scheduler, "VARCHAR", TestDataType.random));
                    
                    scheduler.url = Convert.ToString(BaseTest.getTestData(scheduler, "VARCHAR", TestDataType.random));
                    
                    scheduler.user_domain = Convert.ToString(BaseTest.getTestData(scheduler, "VARCHAR", TestDataType.random));
                    
                    scheduler.os_name = Convert.ToString(BaseTest.getTestData(scheduler, "VARCHAR", TestDataType.random));
                    
                    scheduler.os_version = Convert.ToString(BaseTest.getTestData(scheduler, "VARCHAR", TestDataType.random));
                    
                    scheduler.architecture = Convert.ToString(BaseTest.getTestData(scheduler, "VARCHAR", TestDataType.random));
                    
                    scheduler.registered_at = Convert.ToDateTime(BaseTest.getTestData(scheduler, "TIMESTAMP", TestDataType.random));
                    
                    scheduler.scheduler_status_id = BaseTest.getLastId("SchedulerStatus");
                    
                Console.WriteLine("Testing Scheduler API insert: " + scheduler.ToString());
                var createdScheduler = await PostAsyncReturn("Scheduler", scheduler);
                BaseTest.addLastId("scheduler", createdScheduler.id);
                    }

        public static async Task testInsertRwkOnly()
        {
            var scheduler = new Scheduler();


                        scheduler.hostname = Convert.ToString(BaseTest.getTestData(scheduler, "VARCHAR", TestDataType.random));
                        
                        scheduler.ip_address = Convert.ToString(BaseTest.getTestData(scheduler, "VARCHAR", TestDataType.random));
                        
                        scheduler.port = Convert.ToInt32(BaseTest.getTestData(scheduler, "INTEGER", TestDataType.random));
                        
                Console.WriteLine("Testing Scheduler API insert (RWK only): " + scheduler.ToString());
                var createdScheduler = await PostAsyncReturn("Scheduler", scheduler);
                BaseTest.addLastId("scheduler", createdScheduler.id);
                    }

        public static async Task testUpdate()
        {
            long lastId = BaseTest.getLastId("scheduler");
            var schedulerView = await GetByIdAsync<SchedulerView>("Scheduler", lastId);
            var scheduler = new Scheduler(schedulerView);


                        scheduler.hostname = (string) BaseTest.getTestData(scheduler, "VARCHAR", TestDataType.random);
                    
                        scheduler.ip_address = (string) BaseTest.getTestData(scheduler, "VARCHAR", TestDataType.random);
                    
                        scheduler.port = (int) BaseTest.getTestData(scheduler, "INTEGER", TestDataType.random);
                    
                        scheduler.username = (string) BaseTest.getTestData(scheduler, "VARCHAR", TestDataType.random);
                    
                        scheduler.url = (string) BaseTest.getTestData(scheduler, "VARCHAR", TestDataType.random);
                    
                        scheduler.user_domain = (string) BaseTest.getTestData(scheduler, "VARCHAR", TestDataType.random);
                    
                        scheduler.os_name = (string) BaseTest.getTestData(scheduler, "VARCHAR", TestDataType.random);
                    
                        scheduler.os_version = (string) BaseTest.getTestData(scheduler, "VARCHAR", TestDataType.random);
                    
                        scheduler.architecture = (string) BaseTest.getTestData(scheduler, "VARCHAR", TestDataType.random);
                    
                        scheduler.registered_at = (DateTime) BaseTest.getTestData(scheduler, "TIMESTAMP", TestDataType.random);
                    
                            scheduler.scheduler_status_id = BaseTest.getLastId("SchedulerStatus");
                        
                Console.WriteLine("Testing Scheduler API update: " + scheduler.ToString());
                await PutAsync("Scheduler", lastId, scheduler);
                    }

        public static async Task testPut()
        {
            long lastId = BaseTest.getLastId("scheduler");
            var schedulerView = await GetByIdAsync<SchedulerView>("Scheduler", lastId);
            var scheduler = new Scheduler(schedulerView);


                        scheduler.hostname = (string) BaseTest.getTestData(scheduler, "VARCHAR", TestDataType.random);
                    
                        scheduler.ip_address = (string) BaseTest.getTestData(scheduler, "VARCHAR", TestDataType.random);
                    
                        scheduler.port = (int) BaseTest.getTestData(scheduler, "INTEGER", TestDataType.random);
                    
                        scheduler.username = (string) BaseTest.getTestData(scheduler, "VARCHAR", TestDataType.random);
                    
                        scheduler.url = (string) BaseTest.getTestData(scheduler, "VARCHAR", TestDataType.random);
                    
                        scheduler.user_domain = (string) BaseTest.getTestData(scheduler, "VARCHAR", TestDataType.random);
                    
                        scheduler.os_name = (string) BaseTest.getTestData(scheduler, "VARCHAR", TestDataType.random);
                    
                        scheduler.os_version = (string) BaseTest.getTestData(scheduler, "VARCHAR", TestDataType.random);
                    
                        scheduler.architecture = (string) BaseTest.getTestData(scheduler, "VARCHAR", TestDataType.random);
                    
                        scheduler.registered_at = (DateTime) BaseTest.getTestData(scheduler, "TIMESTAMP", TestDataType.random);
                    
                            scheduler.scheduler_status_id = BaseTest.getLastId("SchedulerStatus");
                        
                Console.WriteLine("Testing Scheduler API update: " + scheduler.ToString());
                await PutAsync("Scheduler", lastId, scheduler);
                    }

        public static async Task testSelect()
        {
            Console.WriteLine("Testing Scheduler API select (list):");
            
            try
            {
                var schedulerList = await BaseTest.GetListAsync<Scheduler>("Scheduler");
                
                Console.WriteLine($"Retrieved {schedulerList.Count} Scheduler records");
                
                if (schedulerList.Count > 0)
                {
                    Console.WriteLine("First record: " + schedulerList[0].ToString());
                    
                    // Output all fields for each object, one per row
                    Console.WriteLine("\nDetailed Scheduler records:");
                    Console.WriteLine("=" + new string('=', 50));
                    
                    for (int i = 0; i < schedulerList.Count; i++)
                    {
                        var scheduler = schedulerList[i];
                        Console.WriteLine($"Record {i + 1}:");
                        Console.WriteLine($"  ID: {scheduler.id}");

                        Console.WriteLine($"  hostname: {scheduler.hostname}");
                                
                        Console.WriteLine($"  ip_address: {scheduler.ip_address}");
                                
                        Console.WriteLine($"  port: {scheduler.port}");
                                
                        Console.WriteLine($"  username: {scheduler.username}");
                                
                        Console.WriteLine($"  url: {scheduler.url}");
                                
                        Console.WriteLine($"  user_domain: {scheduler.user_domain}");
                                
                        Console.WriteLine($"  os_name: {scheduler.os_name}");
                                
                        Console.WriteLine($"  os_version: {scheduler.os_version}");
                                
                        Console.WriteLine($"  architecture: {scheduler.architecture}");
                                
                        Console.WriteLine($"  registered_at: {scheduler.registered_at}");
                                
                        Console.WriteLine($"  scheduler_status_id: {scheduler.scheduler_status_id}");
                                
                        Console.WriteLine($"  is_active: {scheduler.is_active}");
                                
                        Console.WriteLine($"  created_by: {scheduler.created_by}");
                                
                        Console.WriteLine($"  last_updated: {scheduler.last_updated}");
                                
                        Console.WriteLine($"  last_updated_by: {scheduler.last_updated_by}");
                                
                        Console.WriteLine($"  version: {scheduler.version}");
                                                        Console.WriteLine();
                    }
                    
                    // Store the first record for potential use in other tests
                    BaseTest.addLastId("@(Model.TableName)", schedulerList[0].id);
                }
                else
                {
                    Console.WriteLine("No Scheduler records found in database");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error testing Scheduler select: {ex.Message}");
                throw;
            }
        }
    }
}
