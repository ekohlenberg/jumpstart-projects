using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using defarge;

namespace defarge
{
    public partial class WorkflowProcessTest : BaseTest
    {
        public static void testInsert()
        {
            var workflowprocess = new WorkflowProcess();


                    workflowprocess.workflow_id = BaseTest.getLastId("workflow");
                    
                    workflowprocess.process_id = BaseTest.getLastId("process");
                    
                    workflowprocess.agent_id = BaseTest.getLastId("server");
                    
                    workflowprocess.seq = Convert.ToInt32(BaseTest.getTestData(workflowprocess, "INTEGER", TestDataType.random));
                    
                    workflowprocess.on_failure_action_id = BaseTest.getLastId("onfailure");
                    
                Logger.Info("Testing WorkflowProcessLogic insert: " + workflowprocess.ToString());
                WorkflowProcessLogic.Create().insert(workflowprocess);
                BaseTest.addLastId("workflowprocess", workflowprocess.id);
                    }

        public static void testUpdate()
        {
            long lastId = BaseTest.getLastId("workflowprocess");
            var workflowprocessView  = WorkflowProcessLogic.Create().get(lastId);

            WorkflowProcess workflowprocess = new WorkflowProcess(workflowprocessView);

                            workflowprocess.workflow_id = BaseTest.getLastId("workflow");
                        
                            workflowprocess.process_id = BaseTest.getLastId("process");
                        
                            workflowprocess.agent_id = BaseTest.getLastId("server");
                        
                        workflowprocess.seq = (int) BaseTest.getTestData(workflowprocess, "INTEGER", TestDataType.random);
                    
                            workflowprocess.on_failure_action_id = BaseTest.getLastId("onfailure");
                        
                Logger.Info("Testing WorkflowProcessLogic update: " + workflowprocess.ToString());
                WorkflowProcessLogic.Create().update(lastId, workflowprocess);
                    }
    }
}
