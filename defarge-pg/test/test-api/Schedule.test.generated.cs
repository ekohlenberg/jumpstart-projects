using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using defarge;

namespace defarge
{
    public partial class ScheduleTest : BaseTest
    {
        public static async Task testInsert()
        {
            var schedule = new Schedule();


                    schedule.cron_expression = Convert.ToString(BaseTest.getTestData(schedule, "VARCHAR", TestDataType.random));
                    
                    schedule.next_run_time = Convert.ToDateTime(BaseTest.getTestData(schedule, "TIMESTAMP", TestDataType.random));
                    
                    schedule.last_run_time = Convert.ToDateTime(BaseTest.getTestData(schedule, "TIMESTAMP", TestDataType.random));
                    
                    schedule.status = Convert.ToString(BaseTest.getTestData(schedule, "VARCHAR", TestDataType.random));
                    
                Console.WriteLine("Testing Schedule API insert: " + schedule.ToString());
                var createdSchedule = await PostAsyncReturn("Schedule", schedule);
                BaseTest.addLastId("schedule", createdSchedule.id);
                    }

        public static async Task testInsertRwkOnly()
        {
            var schedule = new Schedule();


                        schedule.cron_expression = Convert.ToString(BaseTest.getTestData(schedule, "VARCHAR", TestDataType.random));
                        
                Console.WriteLine("Testing Schedule API insert (RWK only): " + schedule.ToString());
                var createdSchedule = await PostAsyncReturn("Schedule", schedule);
                BaseTest.addLastId("schedule", createdSchedule.id);
                    }

        public static async Task testUpdate()
        {
            long lastId = BaseTest.getLastId("schedule");
            var scheduleView = await GetByIdAsync<ScheduleView>("Schedule", lastId);
            var schedule = new Schedule(scheduleView);


                        schedule.cron_expression = (string) BaseTest.getTestData(schedule, "VARCHAR", TestDataType.random);
                    
                        schedule.next_run_time = (DateTime) BaseTest.getTestData(schedule, "TIMESTAMP", TestDataType.random);
                    
                        schedule.last_run_time = (DateTime) BaseTest.getTestData(schedule, "TIMESTAMP", TestDataType.random);
                    
                        schedule.status = (string) BaseTest.getTestData(schedule, "VARCHAR", TestDataType.random);
                    
                Console.WriteLine("Testing Schedule API update: " + schedule.ToString());
                await PutAsync("Schedule", lastId, schedule);
                    }

        public static async Task testPut()
        {
            long lastId = BaseTest.getLastId("schedule");
            var scheduleView = await GetByIdAsync<ScheduleView>("Schedule", lastId);
            var schedule = new Schedule(scheduleView);


                        schedule.cron_expression = (string) BaseTest.getTestData(schedule, "VARCHAR", TestDataType.random);
                    
                        schedule.next_run_time = (DateTime) BaseTest.getTestData(schedule, "TIMESTAMP", TestDataType.random);
                    
                        schedule.last_run_time = (DateTime) BaseTest.getTestData(schedule, "TIMESTAMP", TestDataType.random);
                    
                        schedule.status = (string) BaseTest.getTestData(schedule, "VARCHAR", TestDataType.random);
                    
                Console.WriteLine("Testing Schedule API update: " + schedule.ToString());
                await PutAsync("Schedule", lastId, schedule);
                    }

        public static async Task testSelect()
        {
            Console.WriteLine("Testing Schedule API select (list):");
            
            try
            {
                var scheduleList = await BaseTest.GetListAsync<Schedule>("Schedule");
                
                Console.WriteLine($"Retrieved {scheduleList.Count} Schedule records");
                
                if (scheduleList.Count > 0)
                {
                    Console.WriteLine("First record: " + scheduleList[0].ToString());
                    
                    // Output all fields for each object, one per row
                    Console.WriteLine("\nDetailed Schedule records:");
                    Console.WriteLine("=" + new string('=', 50));
                    
                    for (int i = 0; i < scheduleList.Count; i++)
                    {
                        var schedule = scheduleList[i];
                        Console.WriteLine($"Record {i + 1}:");
                        Console.WriteLine($"  ID: {schedule.id}");

                        Console.WriteLine($"  cron_expression: {schedule.cron_expression}");
                                
                        Console.WriteLine($"  next_run_time: {schedule.next_run_time}");
                                
                        Console.WriteLine($"  last_run_time: {schedule.last_run_time}");
                                
                        Console.WriteLine($"  status: {schedule.status}");
                                
                        Console.WriteLine($"  is_active: {schedule.is_active}");
                                
                        Console.WriteLine($"  created_by: {schedule.created_by}");
                                
                        Console.WriteLine($"  last_updated: {schedule.last_updated}");
                                
                        Console.WriteLine($"  last_updated_by: {schedule.last_updated_by}");
                                
                        Console.WriteLine($"  version: {schedule.version}");
                                                        Console.WriteLine();
                    }
                    
                    // Store the first record for potential use in other tests
                    BaseTest.addLastId("@(Model.TableName)", scheduleList[0].id);
                }
                else
                {
                    Console.WriteLine("No Schedule records found in database");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error testing Schedule select: {ex.Message}");
                throw;
            }
        }
    }
}
