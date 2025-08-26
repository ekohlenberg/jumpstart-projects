using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using defarge;

namespace defarge
{
    public partial class ScriptTest : BaseTest
    {
        public static async Task testInsert()
        {
            var script = new Script();


                    script.name = Convert.ToString(BaseTest.getTestData(script, "VARCHAR", TestDataType.random));
                    
                    script.source = Convert.ToString(BaseTest.getTestData(script, "VARCHAR", TestDataType.random));
                    
                Console.WriteLine("Testing Script API insert: " + script.ToString());
                await PostAsync("Script", script);
                BaseTest.addLastId("script", script.id);
                    }

        public static async Task testUpdate()
        {
            long lastId = BaseTest.getLastId("Script");
            var script = await GetByIdAsync<Script>("Script", lastId);


                        script.name = (string) BaseTest.getTestData(script, "VARCHAR", TestDataType.random);
                    
                        script.source = (string) BaseTest.getTestData(script, "VARCHAR", TestDataType.random);
                    
                Console.WriteLine("Testing Script API update: " + script.ToString());
                await PutAsync("Script", lastId, script);
                    }
    }
}
