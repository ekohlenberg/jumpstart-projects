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


                    workflowprocess.workflow_id = BaseTest.getLastId("Workflow");
                    
                    workflowprocess.process_id = BaseTest.getLastId("Process");
                    
                    workflowprocess.agent_id = BaseTest.getLastId("Server");
                    
                    workflowprocess.seq = Convert.ToInt32(BaseTest.getTestData(workflowprocess, "INTEGER", TestDataType.random));
                    
                    workflowprocess.on_failure_action_id = BaseTest.getLastId("OnFailure");
                    
                Console.WriteLine("Testing WorkflowProcess API insert: " + workflowprocess.ToString());
                var createdWorkflowProcess = await PostAsyncReturn("WorkflowProcess", workflowprocess);
                BaseTest.addLastId("workflowprocess", createdWorkflowProcess.id);
                    }

        public static async Task testInsertRwkOnly()
        {
            var workflowprocess = new WorkflowProcess();


                        workflowprocess.workflow_id = BaseTest.getLastId("Workflow");
                        
                        workflowprocess.process_id = BaseTest.getLastId("Process");
                        
                Console.WriteLine("Testing WorkflowProcess API insert (RWK only): " + workflowprocess.ToString());
                var createdWorkflowProcess = await PostAsyncReturn("WorkflowProcess", workflowprocess);
                BaseTest.addLastId("workflowprocess", createdWorkflowProcess.id);
                    }

        public static async Task testUpdate()
        {
            long lastId = BaseTest.getLastId("workflowprocess");
            var workflowprocessView = await GetByIdAsync<WorkflowProcessView>("WorkflowProcess", lastId);
            var workflowprocess = new WorkflowProcess(workflowprocessView);


                            workflowprocess.workflow_id = BaseTest.getLastId("Workflow");
                        
                            workflowprocess.process_id = BaseTest.getLastId("Process");
                        
                            workflowprocess.agent_id = BaseTest.getLastId("Server");
                        
                        workflowprocess.seq = (int) BaseTest.getTestData(workflowprocess, "INTEGER", TestDataType.random);
                    
                            workflowprocess.on_failure_action_id = BaseTest.getLastId("OnFailure");
                        
                Console.WriteLine("Testing WorkflowProcess API update: " + workflowprocess.ToString());
                await PutAsync("WorkflowProcess", lastId, workflowprocess);
                    }

        public static async Task testPut()
        {
            long lastId = BaseTest.getLastId("workflowprocess");
            var workflowprocessView = await GetByIdAsync<WorkflowProcessView>("WorkflowProcess", lastId);
            var workflowprocess = new WorkflowProcess(workflowprocessView);


                            workflowprocess.workflow_id = BaseTest.getLastId("Workflow");
                        
                            workflowprocess.process_id = BaseTest.getLastId("Process");
                        
                            workflowprocess.agent_id = BaseTest.getLastId("Server");
                        
                        workflowprocess.seq = (int) BaseTest.getTestData(workflowprocess, "INTEGER", TestDataType.random);
                    
                            workflowprocess.on_failure_action_id = BaseTest.getLastId("OnFailure");
                        
                Console.WriteLine("Testing WorkflowProcess API update: " + workflowprocess.ToString());
                await PutAsync("WorkflowProcess", lastId, workflowprocess);
                    }

        public static async Task testSelect()
        {
            Console.WriteLine("Testing WorkflowProcess API select (list):");
            
            try
            {
                var workflowprocessList = await BaseTest.GetListAsync<WorkflowProcess>("WorkflowProcess");
                
                Console.WriteLine($"Retrieved {workflowprocessList.Count} WorkflowProcess records");
                
                if (workflowprocessList.Count > 0)
                {
                    Console.WriteLine("First record: " + workflowprocessList[0].ToString());
                    
                    // Output all fields for each object, one per row
                    Console.WriteLine("\nDetailed WorkflowProcess records:");
                    Console.WriteLine("=" + new string('=', 50));
                    
                    for (int i = 0; i < workflowprocessList.Count; i++)
                    {
                        var workflowprocess = workflowprocessList[i];
                        Console.WriteLine($"Record {i + 1}:");
                        Console.WriteLine($"  ID: {workflowprocess.id}");

                        Console.WriteLine($"  workflow_id: {workflowprocess.workflow_id}");
                                
                        Console.WriteLine($"  process_id: {workflowprocess.process_id}");
                                
                        Console.WriteLine($"  agent_id: {workflowprocess.agent_id}");
                                
                        Console.WriteLine($"  seq: {workflowprocess.seq}");
                                
                        Console.WriteLine($"  on_failure_action_id: {workflowprocess.on_failure_action_id}");
                                
                        Console.WriteLine($"  is_active: {workflowprocess.is_active}");
                                
                        Console.WriteLine($"  created_by: {workflowprocess.created_by}");
                                
                        Console.WriteLine($"  last_updated: {workflowprocess.last_updated}");
                                
                        Console.WriteLine($"  last_updated_by: {workflowprocess.last_updated_by}");
                                
                        Console.WriteLine($"  version: {workflowprocess.version}");
                                                        Console.WriteLine();
                    }
                    
                    // Store the first record for potential use in other tests
                    BaseTest.addLastId("@(Model.TableName)", workflowprocessList[0].id);
                }
                else
                {
                    Console.WriteLine("No WorkflowProcess records found in database");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error testing WorkflowProcess select: {ex.Message}");
                throw;
            }
        }
    }
}
