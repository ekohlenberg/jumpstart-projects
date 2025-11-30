using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace defarge
{
    class Program
    {
        static async Task Main(string[] args)
        {
            try
            {

                
                await WorkflowProcessTest.testInsertWorkflowProcess();
                await WorkflowProcessTest.testExecWorkflowProcess();
            }
            catch( Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }
		}
    }
}
