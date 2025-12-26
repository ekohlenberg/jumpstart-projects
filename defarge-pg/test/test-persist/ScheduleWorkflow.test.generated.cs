using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using defarge;

namespace defarge
{
    public partial class ScheduleWorkflowTest : BaseTest
    {
        public static void testInsert()
        {
            var scheduleworkflow = new ScheduleWorkflow();


                    scheduleworkflow.schedule_id = BaseTest.getLastId("schedule");
                    
                    scheduleworkflow.workflow_id = BaseTest.getLastId("workflow");
                    
                Logger.Info("Testing ScheduleWorkflowLogic insert: " + scheduleworkflow.ToString());
                ScheduleWorkflowLogic.Create().insert(scheduleworkflow);
                BaseTest.addLastId("scheduleworkflow", scheduleworkflow.id);
                    }

        public static void testUpdate()
        {
            long lastId = BaseTest.getLastId("scheduleworkflow");
            var scheduleworkflowView  = ScheduleWorkflowLogic.Create().get(lastId);

            ScheduleWorkflow scheduleworkflow = new ScheduleWorkflow(scheduleworkflowView);

                            scheduleworkflow.schedule_id = BaseTest.getLastId("schedule");
                        
                            scheduleworkflow.workflow_id = BaseTest.getLastId("workflow");
                        
                Logger.Info("Testing ScheduleWorkflowLogic update: " + scheduleworkflow.ToString());
                ScheduleWorkflowLogic.Create().update(lastId, scheduleworkflow);
                    }
    }
}
