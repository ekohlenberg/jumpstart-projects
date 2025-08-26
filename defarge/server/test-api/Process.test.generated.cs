using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using defarge;

namespace defarge
{
    public partial class ProcessTest : BaseTest
    {
        public static async Task testInsert()
        {
            var process = new Process();


                    process.name = Convert.ToString(BaseTest.getTestData(process, "VARCHAR", TestDataType.random));
                    
                    process.script_id = BaseTest.getLastId("script");
                    
                Console.WriteLine("Testing Process API insert: " + process.ToString());
                await PostAsync("Process", process);
                BaseTest.addLastId("process", process.id);
                    }

        public static async Task testUpdate()
        {
            long lastId = BaseTest.getLastId("Process");
            var process = await GetByIdAsync<Process>("Process", lastId);


                        process.name = (string) BaseTest.getTestData(process, "VARCHAR", TestDataType.random);
                    
                            process.script_id = BaseTest.getLastId("script");
                        
                Console.WriteLine("Testing Process API update: " + process.ToString());
                await PutAsync("Process", lastId, process);
                    }
    }
}
