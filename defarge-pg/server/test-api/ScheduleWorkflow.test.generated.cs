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


                    scheduleworkflow.schedule_id = BaseTest.getLastId("Schedule");
                    
                    scheduleworkflow.workflow_id = BaseTest.getLastId("Workflow");
                    
                Console.WriteLine("Testing ScheduleWorkflow API insert: " + scheduleworkflow.ToString());
                var createdScheduleWorkflow = await PostAsyncReturn("ScheduleWorkflow", scheduleworkflow);
                BaseTest.addLastId("scheduleworkflow", createdScheduleWorkflow.id);
                    }

        public static async Task testInsertRwkOnly()
        {
            var scheduleworkflow = new ScheduleWorkflow();


                Console.WriteLine("Testing ScheduleWorkflow API insert (RWK only): " + scheduleworkflow.ToString());
                var createdScheduleWorkflow = await PostAsyncReturn("ScheduleWorkflow", scheduleworkflow);
                BaseTest.addLastId("scheduleworkflow", createdScheduleWorkflow.id);
                    }

        public static async Task testUpdate()
        {
            long lastId = BaseTest.getLastId("scheduleworkflow");
            var scheduleworkflowView = await GetByIdAsync<ScheduleWorkflowView>("ScheduleWorkflow", lastId);
            var scheduleworkflow = new ScheduleWorkflow(scheduleworkflowView);


                            scheduleworkflow.schedule_id = BaseTest.getLastId("Schedule");
                        
                            scheduleworkflow.workflow_id = BaseTest.getLastId("Workflow");
                        
                Console.WriteLine("Testing ScheduleWorkflow API update: " + scheduleworkflow.ToString());
                await PutAsync("ScheduleWorkflow", lastId, scheduleworkflow);
                    }

        public static async Task testPut()
        {
            long lastId = BaseTest.getLastId("scheduleworkflow");
            var scheduleworkflowView = await GetByIdAsync<ScheduleWorkflowView>("ScheduleWorkflow", lastId);
            var scheduleworkflow = new ScheduleWorkflow(scheduleworkflowView);


                            scheduleworkflow.schedule_id = BaseTest.getLastId("Schedule");
                        
                            scheduleworkflow.workflow_id = BaseTest.getLastId("Workflow");
                        
                Console.WriteLine("Testing ScheduleWorkflow API update: " + scheduleworkflow.ToString());
                await PutAsync("ScheduleWorkflow", lastId, scheduleworkflow);
                    }

        public static async Task testSelect()
        {
            Console.WriteLine("Testing ScheduleWorkflow API select (list):");
            
            try
            {
                var scheduleworkflowList = await BaseTest.GetListAsync<ScheduleWorkflow>("ScheduleWorkflow");
                
                Console.WriteLine($"Retrieved {scheduleworkflowList.Count} ScheduleWorkflow records");
                
                if (scheduleworkflowList.Count > 0)
                {
                    Console.WriteLine("First record: " + scheduleworkflowList[0].ToString());
                    
                    // Output all fields for each object, one per row
                    Console.WriteLine("\nDetailed ScheduleWorkflow records:");
                    Console.WriteLine("=" + new string('=', 50));
                    
                    for (int i = 0; i < scheduleworkflowList.Count; i++)
                    {
                        var scheduleworkflow = scheduleworkflowList[i];
                        Console.WriteLine($"Record {i + 1}:");
                        Console.WriteLine($"  ID: {scheduleworkflow.id}");

                        Console.WriteLine($"  schedule_id: {scheduleworkflow.schedule_id}");
                                
                        Console.WriteLine($"  workflow_id: {scheduleworkflow.workflow_id}");
                                
                        Console.WriteLine($"  is_active: {scheduleworkflow.is_active}");
                                
                        Console.WriteLine($"  created_by: {scheduleworkflow.created_by}");
                                
                        Console.WriteLine($"  last_updated: {scheduleworkflow.last_updated}");
                                
                        Console.WriteLine($"  last_updated_by: {scheduleworkflow.last_updated_by}");
                                
                        Console.WriteLine($"  version: {scheduleworkflow.version}");
                                                        Console.WriteLine();
                    }
                    
                    // Store the first record for potential use in other tests
                    BaseTest.addLastId("@(Model.TableName)", scheduleworkflowList[0].id);
                }
                else
                {
                    Console.WriteLine("No ScheduleWorkflow records found in database");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error testing ScheduleWorkflow select: {ex.Message}");
                throw;
            }
        }
    }
}
