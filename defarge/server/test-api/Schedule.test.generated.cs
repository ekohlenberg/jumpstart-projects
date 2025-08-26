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
                await PostAsync("Schedule", schedule);
                BaseTest.addLastId("schedule", schedule.id);
                    }

        public static async Task testUpdate()
        {
            long lastId = BaseTest.getLastId("Schedule");
            var schedule = await GetByIdAsync<Schedule>("Schedule", lastId);


                        schedule.cron_expression = (string) BaseTest.getTestData(schedule, "VARCHAR", TestDataType.random);
                    
                        schedule.next_run_time = (DateTime) BaseTest.getTestData(schedule, "TIMESTAMP", TestDataType.random);
                    
                        schedule.last_run_time = (DateTime) BaseTest.getTestData(schedule, "TIMESTAMP", TestDataType.random);
                    
                        schedule.status = (string) BaseTest.getTestData(schedule, "VARCHAR", TestDataType.random);
                    
                Console.WriteLine("Testing Schedule API update: " + schedule.ToString());
                await PutAsync("Schedule", lastId, schedule);
                    }
    }
}
