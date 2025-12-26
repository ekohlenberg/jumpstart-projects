using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using defarge;

namespace defarge
{
    public partial class SchedulerStatusTest : BaseTest
    {
        public static void testInsert()
        {
            var schedulerstatus = new SchedulerStatus();


                    schedulerstatus.name = Convert.ToString(BaseTest.getTestData(schedulerstatus, "VARCHAR", TestDataType.random));
                    
                Logger.Info("Testing SchedulerStatusLogic insert: " + schedulerstatus.ToString());
                SchedulerStatusLogic.Create().insert(schedulerstatus);
                BaseTest.addLastId("schedulerstatus", schedulerstatus.id);
                    }

        public static void testUpdate()
        {
            long lastId = BaseTest.getLastId("schedulerstatus");
            var schedulerstatusView  = SchedulerStatusLogic.Create().get(lastId);

            SchedulerStatus schedulerstatus = new SchedulerStatus(schedulerstatusView);

                        schedulerstatus.name = (string) BaseTest.getTestData(schedulerstatus, "VARCHAR", TestDataType.random);
                    
                Logger.Info("Testing SchedulerStatusLogic update: " + schedulerstatus.ToString());
                SchedulerStatusLogic.Create().update(lastId, schedulerstatus);
                    }
    }
}
