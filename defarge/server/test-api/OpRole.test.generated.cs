using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using defarge;

namespace defarge
{
    public partial class OpRoleTest : BaseTest
    {
        public static async Task testInsert()
        {
            var oprole = new OpRole();


                    oprole.name = Convert.ToString(BaseTest.getTestData(oprole, "VARCHAR", TestDataType.random));
                    
                Console.WriteLine("Testing OpRole API insert: " + oprole.ToString());
                await PostAsync("OpRole", oprole);
                BaseTest.addLastId("op_role", oprole.id);
                    }

        public static async Task testUpdate()
        {
            long lastId = BaseTest.getLastId("OpRole");
            var oprole = await GetByIdAsync<OpRole>("OpRole", lastId);


                        oprole.name = (string) BaseTest.getTestData(oprole, "VARCHAR", TestDataType.random);
                    
                Console.WriteLine("Testing OpRole API update: " + oprole.ToString());
                await PutAsync("OpRole", lastId, oprole);
                    }
    }
}
