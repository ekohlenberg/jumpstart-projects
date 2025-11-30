using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using defarge;

namespace defarge
{
    public partial class SchedulerTest : BaseTest
    {
        public static void testInsert()
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
                    
                    scheduler.scheduler_status_id = BaseTest.getLastId("schedulerstatus");
                    
                Logger.Info("Testing SchedulerLogic insert: " + scheduler.ToString());
                SchedulerLogic.Create().insert(scheduler);
                BaseTest.addLastId("scheduler", scheduler.id);
                    }

        public static void testUpdate()
        {
            long lastId = BaseTest.getLastId("scheduler");
            var schedulerView  = SchedulerLogic.Create().get(lastId);

            Scheduler scheduler = new Scheduler(schedulerView);

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
                    
                            scheduler.scheduler_status_id = BaseTest.getLastId("schedulerstatus");
                        
                Logger.Info("Testing SchedulerLogic update: " + scheduler.ToString());
                SchedulerLogic.Create().update(lastId, scheduler);
                    }
    }
}
