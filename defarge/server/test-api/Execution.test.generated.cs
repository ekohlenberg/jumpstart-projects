using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using defarge;

namespace defarge
{
    public partial class ExecutionTest : BaseTest
    {
        public static async Task testInsert()
        {
            var execution = new Execution();


                    execution.token = Convert.ToString(BaseTest.getTestData(execution, "VARCHAR", TestDataType.random));
                    
                    execution.process_id = BaseTest.getLastId("process");
                    
                    execution.start_time = Convert.ToDateTime(BaseTest.getTestData(execution, "TIMESTAMP", TestDataType.random));
                    
                    execution.end_time = Convert.ToDateTime(BaseTest.getTestData(execution, "TIMESTAMP", TestDataType.random));
                    
                    execution.status = Convert.ToString(BaseTest.getTestData(execution, "VARCHAR", TestDataType.random));
                    
                    execution.log_output = Convert.ToString(BaseTest.getTestData(execution, "VARCHAR", TestDataType.random));
                    
                Console.WriteLine("Testing Execution API insert: " + execution.ToString());
                await PostAsync("Execution", execution);
                BaseTest.addLastId("execution", execution.id);
                    }

        public static async Task testUpdate()
        {
            long lastId = BaseTest.getLastId("Execution");
            var execution = await GetByIdAsync<Execution>("Execution", lastId);


                        execution.token = (string) BaseTest.getTestData(execution, "VARCHAR", TestDataType.random);
                    
                            execution.process_id = BaseTest.getLastId("process");
                        
                        execution.start_time = (DateTime) BaseTest.getTestData(execution, "TIMESTAMP", TestDataType.random);
                    
                        execution.end_time = (DateTime) BaseTest.getTestData(execution, "TIMESTAMP", TestDataType.random);
                    
                        execution.status = (string) BaseTest.getTestData(execution, "VARCHAR", TestDataType.random);
                    
                        execution.log_output = (string) BaseTest.getTestData(execution, "VARCHAR", TestDataType.random);
                    
                Console.WriteLine("Testing Execution API update: " + execution.ToString());
                await PutAsync("Execution", lastId, execution);
                    }
    }
}
