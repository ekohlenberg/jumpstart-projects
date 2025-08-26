using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using defarge;

namespace defarge
{
    public partial class OrgTest : BaseTest
    {
        public static async Task testInsert()
        {
            var org = new Org();


                    org.name = Convert.ToString(BaseTest.getTestData(org, "VARCHAR", TestDataType.companies));
                    
                Console.WriteLine("Testing Org API insert: " + org.ToString());
                await PostAsync("Org", org);
                BaseTest.addLastId("org", org.id);
                    }

        public static async Task testUpdate()
        {
            long lastId = BaseTest.getLastId("Org");
            var org = await GetByIdAsync<Org>("Org", lastId);


                        org.name = (string) BaseTest.getTestData(org, "VARCHAR", TestDataType.companies);
                    
                Console.WriteLine("Testing Org API update: " + org.ToString());
                await PutAsync("Org", lastId, org);
                    }
    }
}
