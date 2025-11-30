using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using defarge;

namespace defarge
{
    public partial class ExecutionTest : BaseTest
    {
        public static void testInsert()
        {
            var execution = new Execution();


                    execution.token = Convert.ToString(BaseTest.getTestData(execution, "VARCHAR", TestDataType.random));
                    
                    execution.workflow_process_id = BaseTest.getLastId("process");
                    
                    execution.start_time = Convert.ToDateTime(BaseTest.getTestData(execution, "TIMESTAMP", TestDataType.random));
                    
                    execution.end_time = Convert.ToDateTime(BaseTest.getTestData(execution, "TIMESTAMP", TestDataType.random));
                    
                    execution.stdout = Convert.ToString(BaseTest.getTestData(execution, "VARCHAR", TestDataType.random));
                    
                    execution.stderr = Convert.ToString(BaseTest.getTestData(execution, "VARCHAR", TestDataType.random));
                    
                Logger.Info("Testing ExecutionLogic insert: " + execution.ToString());
                ExecutionLogic.Create().insert(execution);
                BaseTest.addLastId("execution", execution.id);
                    }

        public static void testUpdate()
        {
            long lastId = BaseTest.getLastId("execution");
            var executionView  = ExecutionLogic.Create().get(lastId);

            Execution execution = new Execution(executionView);

                        execution.token = (string) BaseTest.getTestData(execution, "VARCHAR", TestDataType.random);
                    
                            execution.workflow_process_id = BaseTest.getLastId("process");
                        
                        execution.start_time = (DateTime) BaseTest.getTestData(execution, "TIMESTAMP", TestDataType.random);
                    
                        execution.end_time = (DateTime) BaseTest.getTestData(execution, "TIMESTAMP", TestDataType.random);
                    
                        execution.stdout = (string) BaseTest.getTestData(execution, "VARCHAR", TestDataType.random);
                    
                        execution.stderr = (string) BaseTest.getTestData(execution, "VARCHAR", TestDataType.random);
                    
                Logger.Info("Testing ExecutionLogic update: " + execution.ToString());
                ExecutionLogic.Create().update(lastId, execution);
                    }
    }
}
