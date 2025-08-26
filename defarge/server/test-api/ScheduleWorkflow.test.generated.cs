using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using defarge;

namespace defarge
{
    public partial class ScheduleWorkflowTest : BaseTest
    {
        public static async Task testInsert()
        {
            var scheduleworkflow = new ScheduleWorkflow();


                    scheduleworkflow.schedule_id = BaseTest.getLastId("schedule");
                    
                    scheduleworkflow.workflow_id = BaseTest.getLastId("workflow");
                    
                Console.WriteLine("Testing ScheduleWorkflow API insert: " + scheduleworkflow.ToString());
                await PostAsync("ScheduleWorkflow", scheduleworkflow);
                BaseTest.addLastId("schedule_workflow", scheduleworkflow.id);
                    }

        public static async Task testUpdate()
        {
            long lastId = BaseTest.getLastId("ScheduleWorkflow");
            var scheduleworkflow = await GetByIdAsync<ScheduleWorkflow>("ScheduleWorkflow", lastId);


                            scheduleworkflow.schedule_id = BaseTest.getLastId("schedule");
                        
                            scheduleworkflow.workflow_id = BaseTest.getLastId("workflow");
                        
                Console.WriteLine("Testing ScheduleWorkflow API update: " + scheduleworkflow.ToString());
                await PutAsync("ScheduleWorkflow", lastId, scheduleworkflow);
                    }
    }
}
