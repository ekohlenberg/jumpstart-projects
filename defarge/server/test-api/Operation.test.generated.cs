using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using defarge;

namespace defarge
{
    public partial class OperationTest : BaseTest
    {
        public static async Task testInsert()
        {
            var operation = new Operation();


                    operation.objectname = Convert.ToString(BaseTest.getTestData(operation, "VARCHAR", TestDataType.random));
                    
                    operation.methodname = Convert.ToString(BaseTest.getTestData(operation, "VARCHAR", TestDataType.random));
                    
                Console.WriteLine("Testing Operation API insert: " + operation.ToString());
                await PostAsync("Operation", operation);
                BaseTest.addLastId("operation", operation.id);
                    }

        public static async Task testUpdate()
        {
            long lastId = BaseTest.getLastId("Operation");
            var operation = await GetByIdAsync<Operation>("Operation", lastId);


                        operation.objectname = (string) BaseTest.getTestData(operation, "VARCHAR", TestDataType.random);
                    
                        operation.methodname = (string) BaseTest.getTestData(operation, "VARCHAR", TestDataType.random);
                    
                Console.WriteLine("Testing Operation API update: " + operation.ToString());
                await PutAsync("Operation", lastId, operation);
                    }
    }
}
