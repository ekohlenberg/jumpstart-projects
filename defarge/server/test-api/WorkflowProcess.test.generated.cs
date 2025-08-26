using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using defarge;

namespace defarge
{
    public partial class WorkflowProcessTest : BaseTest
    {
        public static async Task testInsert()
        {
            var workflowprocess = new WorkflowProcess();


                    workflowprocess.workflow_id = BaseTest.getLastId("workflow");
                    
                    workflowprocess.process_id = BaseTest.getLastId("process");
                    
                    workflowprocess.execution_sequence = Convert.ToInt32(BaseTest.getTestData(workflowprocess, "INTEGER", TestDataType.random));
                    
                    workflowprocess.server_id = BaseTest.getLastId("server");
                    
                Console.WriteLine("Testing WorkflowProcess API insert: " + workflowprocess.ToString());
                await PostAsync("WorkflowProcess", workflowprocess);
                BaseTest.addLastId("workflow_process", workflowprocess.id);
                    }

        public static async Task testUpdate()
        {
            long lastId = BaseTest.getLastId("WorkflowProcess");
            var workflowprocess = await GetByIdAsync<WorkflowProcess>("WorkflowProcess", lastId);


                            workflowprocess.workflow_id = BaseTest.getLastId("workflow");
                        
                            workflowprocess.process_id = BaseTest.getLastId("process");
                        
                        workflowprocess.execution_sequence = (int) BaseTest.getTestData(workflowprocess, "INTEGER", TestDataType.random);
                    
                            workflowprocess.server_id = BaseTest.getLastId("server");
                        
                Console.WriteLine("Testing WorkflowProcess API update: " + workflowprocess.ToString());
                await PutAsync("WorkflowProcess", lastId, workflowprocess);
                    }
    }
}
