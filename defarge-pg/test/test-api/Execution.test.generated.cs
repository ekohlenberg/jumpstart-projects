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
                    
                    execution.workflow_process_id = BaseTest.getLastId("Process");
                    
                    execution.start_time = Convert.ToDateTime(BaseTest.getTestData(execution, "TIMESTAMP", TestDataType.random));
                    
                    execution.end_time = Convert.ToDateTime(BaseTest.getTestData(execution, "TIMESTAMP", TestDataType.random));
                    
                    execution.stdout = Convert.ToString(BaseTest.getTestData(execution, "VARCHAR", TestDataType.random));
                    
                    execution.stderr = Convert.ToString(BaseTest.getTestData(execution, "VARCHAR", TestDataType.random));
                    
                Console.WriteLine("Testing Execution API insert: " + execution.ToString());
                var createdExecution = await PostAsyncReturn("Execution", execution);
                BaseTest.addLastId("execution", createdExecution.id);
                    }

        public static async Task testInsertRwkOnly()
        {
            var execution = new Execution();


                        execution.token = Convert.ToString(BaseTest.getTestData(execution, "VARCHAR", TestDataType.random));
                        
                        execution.workflow_process_id = BaseTest.getLastId("Process");
                        
                        execution.start_time = Convert.ToDateTime(BaseTest.getTestData(execution, "TIMESTAMP", TestDataType.random));
                        
                        execution.end_time = Convert.ToDateTime(BaseTest.getTestData(execution, "TIMESTAMP", TestDataType.random));
                        
                Console.WriteLine("Testing Execution API insert (RWK only): " + execution.ToString());
                var createdExecution = await PostAsyncReturn("Execution", execution);
                BaseTest.addLastId("execution", createdExecution.id);
                    }

        public static async Task testUpdate()
        {
            long lastId = BaseTest.getLastId("execution");
            var executionView = await GetByIdAsync<ExecutionView>("Execution", lastId);
            var execution = new Execution(executionView);


                        execution.token = (string) BaseTest.getTestData(execution, "VARCHAR", TestDataType.random);
                    
                            execution.workflow_process_id = BaseTest.getLastId("Process");
                        
                        execution.start_time = (DateTime) BaseTest.getTestData(execution, "TIMESTAMP", TestDataType.random);
                    
                        execution.end_time = (DateTime) BaseTest.getTestData(execution, "TIMESTAMP", TestDataType.random);
                    
                        execution.stdout = (string) BaseTest.getTestData(execution, "VARCHAR", TestDataType.random);
                    
                        execution.stderr = (string) BaseTest.getTestData(execution, "VARCHAR", TestDataType.random);
                    
                Console.WriteLine("Testing Execution API update: " + execution.ToString());
                await PutAsync("Execution", lastId, execution);
                    }

        public static async Task testPut()
        {
            long lastId = BaseTest.getLastId("execution");
            var executionView = await GetByIdAsync<ExecutionView>("Execution", lastId);
            var execution = new Execution(executionView);


                        execution.token = (string) BaseTest.getTestData(execution, "VARCHAR", TestDataType.random);
                    
                            execution.workflow_process_id = BaseTest.getLastId("Process");
                        
                        execution.start_time = (DateTime) BaseTest.getTestData(execution, "TIMESTAMP", TestDataType.random);
                    
                        execution.end_time = (DateTime) BaseTest.getTestData(execution, "TIMESTAMP", TestDataType.random);
                    
                        execution.stdout = (string) BaseTest.getTestData(execution, "VARCHAR", TestDataType.random);
                    
                        execution.stderr = (string) BaseTest.getTestData(execution, "VARCHAR", TestDataType.random);
                    
                Console.WriteLine("Testing Execution API update: " + execution.ToString());
                await PutAsync("Execution", lastId, execution);
                    }

        public static async Task testSelect()
        {
            Console.WriteLine("Testing Execution API select (list):");
            
            try
            {
                var executionList = await BaseTest.GetListAsync<Execution>("Execution");
                
                Console.WriteLine($"Retrieved {executionList.Count} Execution records");
                
                if (executionList.Count > 0)
                {
                    Console.WriteLine("First record: " + executionList[0].ToString());
                    
                    // Output all fields for each object, one per row
                    Console.WriteLine("\nDetailed Execution records:");
                    Console.WriteLine("=" + new string('=', 50));
                    
                    for (int i = 0; i < executionList.Count; i++)
                    {
                        var execution = executionList[i];
                        Console.WriteLine($"Record {i + 1}:");
                        Console.WriteLine($"  ID: {execution.id}");

                        Console.WriteLine($"  token: {execution.token}");
                                
                        Console.WriteLine($"  workflow_process_id: {execution.workflow_process_id}");
                                
                        Console.WriteLine($"  start_time: {execution.start_time}");
                                
                        Console.WriteLine($"  end_time: {execution.end_time}");
                                
                        Console.WriteLine($"  exec_status_id: {execution.exec_status_id}");
                                
                        Console.WriteLine($"  stdout: {execution.stdout}");
                                
                        Console.WriteLine($"  stderr: {execution.stderr}");
                                
                        Console.WriteLine($"  is_active: {execution.is_active}");
                                
                        Console.WriteLine($"  created_by: {execution.created_by}");
                                
                        Console.WriteLine($"  last_updated: {execution.last_updated}");
                                
                        Console.WriteLine($"  last_updated_by: {execution.last_updated_by}");
                                
                        Console.WriteLine($"  version: {execution.version}");
                                                        Console.WriteLine();
                    }
                    
                    // Store the first record for potential use in other tests
                    BaseTest.addLastId("@(Model.TableName)", executionList[0].id);
                }
                else
                {
                    Console.WriteLine("No Execution records found in database");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error testing Execution select: {ex.Message}");
                throw;
            }
        }
    }
}
