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


                    workflow.parent_workflow_id = BaseTest.getLastId("workflow");
                    
                    workflow.name = Convert.ToString(BaseTest.getTestData(workflow, "VARCHAR", TestDataType.random));
                    
                    workflow.description = Convert.ToString(BaseTest.getTestData(workflow, "VARCHAR", TestDataType.random));
                    
                Console.WriteLine("Testing Workflow API insert: " + workflow.ToString());
                await PostAsync("Workflow", workflow);
                BaseTest.addLastId("workflow", workflow.id);
                    }

        public static async Task testUpdate()
        {
            long lastId = BaseTest.getLastId("Workflow");
            var workflow = await GetByIdAsync<Workflow>("Workflow", lastId);


                            workflow.parent_workflow_id = BaseTest.getLastId("workflow");
                        
                        workflow.name = (string) BaseTest.getTestData(workflow, "VARCHAR", TestDataType.random);
                    
                        workflow.description = (string) BaseTest.getTestData(workflow, "VARCHAR", TestDataType.random);
                    
                Console.WriteLine("Testing Workflow API update: " + workflow.ToString());
                await PutAsync("Workflow", lastId, workflow);
                    }
    }
}
