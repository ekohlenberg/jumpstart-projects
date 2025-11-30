using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using defarge;

namespace defarge
{
    public partial class WorkflowTest : BaseTest
    {
        public static async Task testInsert()
        {
            var workflow = new Workflow();


                    workflow.parent_workflow_id = BaseTest.getLastId("Workflow");
                    
                    workflow.name = Convert.ToString(BaseTest.getTestData(workflow, "VARCHAR", TestDataType.random));
                    
                    workflow.description = Convert.ToString(BaseTest.getTestData(workflow, "VARCHAR", TestDataType.random));
                    
                Console.WriteLine("Testing Workflow API insert: " + workflow.ToString());
                var createdWorkflow = await PostAsyncReturn("Workflow", workflow);
                BaseTest.addLastId("workflow", createdWorkflow.id);
                    }

        public static async Task testInsertRwkOnly()
        {
            var workflow = new Workflow();


                        workflow.parent_workflow_id = BaseTest.getLastId("Workflow");
                        
                        workflow.name = Convert.ToString(BaseTest.getTestData(workflow, "VARCHAR", TestDataType.random));
                        
                Console.WriteLine("Testing Workflow API insert (RWK only): " + workflow.ToString());
                var createdWorkflow = await PostAsyncReturn("Workflow", workflow);
                BaseTest.addLastId("workflow", createdWorkflow.id);
                    }

        public static async Task testUpdate()
        {
            long lastId = BaseTest.getLastId("workflow");
            var workflowView = await GetByIdAsync<WorkflowView>("Workflow", lastId);
            var workflow = new Workflow(workflowView);


                            workflow.parent_workflow_id = BaseTest.getLastId("Workflow");
                        
                        workflow.name = (string) BaseTest.getTestData(workflow, "VARCHAR", TestDataType.random);
                    
                        workflow.description = (string) BaseTest.getTestData(workflow, "VARCHAR", TestDataType.random);
                    
                Console.WriteLine("Testing Workflow API update: " + workflow.ToString());
                await PutAsync("Workflow", lastId, workflow);
                    }

        public static async Task testPut()
        {
            long lastId = BaseTest.getLastId("workflow");
            var workflowView = await GetByIdAsync<WorkflowView>("Workflow", lastId);
            var workflow = new Workflow(workflowView);


                            workflow.parent_workflow_id = BaseTest.getLastId("Workflow");
                        
                        workflow.name = (string) BaseTest.getTestData(workflow, "VARCHAR", TestDataType.random);
                    
                        workflow.description = (string) BaseTest.getTestData(workflow, "VARCHAR", TestDataType.random);
                    
                Console.WriteLine("Testing Workflow API update: " + workflow.ToString());
                await PutAsync("Workflow", lastId, workflow);
                    }

        public static async Task testSelect()
        {
            Console.WriteLine("Testing Workflow API select (list):");
            
            try
            {
                var workflowList = await BaseTest.GetListAsync<Workflow>("Workflow");
                
                Console.WriteLine($"Retrieved {workflowList.Count} Workflow records");
                
                if (workflowList.Count > 0)
                {
                    Console.WriteLine("First record: " + workflowList[0].ToString());
                    
                    // Output all fields for each object, one per row
                    Console.WriteLine("\nDetailed Workflow records:");
                    Console.WriteLine("=" + new string('=', 50));
                    
                    for (int i = 0; i < workflowList.Count; i++)
                    {
                        var workflow = workflowList[i];
                        Console.WriteLine($"Record {i + 1}:");
                        Console.WriteLine($"  ID: {workflow.id}");

                        Console.WriteLine($"  parent_workflow_id: {workflow.parent_workflow_id}");
                                
                        Console.WriteLine($"  name: {workflow.name}");
                                
                        Console.WriteLine($"  description: {workflow.description}");
                                
                        Console.WriteLine($"  is_active: {workflow.is_active}");
                                
                        Console.WriteLine($"  created_by: {workflow.created_by}");
                                
                        Console.WriteLine($"  last_updated: {workflow.last_updated}");
                                
                        Console.WriteLine($"  last_updated_by: {workflow.last_updated_by}");
                                
                        Console.WriteLine($"  version: {workflow.version}");
                                                        Console.WriteLine();
                    }
                    
                    // Store the first record for potential use in other tests
                    BaseTest.addLastId("@(Model.TableName)", workflowList[0].id);
                }
                else
                {
                    Console.WriteLine("No Workflow records found in database");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error testing Workflow select: {ex.Message}");
                throw;
            }
        }
    }
}
