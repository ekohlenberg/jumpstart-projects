using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using defarge;

namespace defarge
{
    public partial class PrincipalOrgTest : BaseTest
    {
        public static async Task testInsert()
        {
            var principalorg = new PrincipalOrg();


                    principalorg.org_id = BaseTest.getLastId("org");
                    
                    principalorg.principal_id = BaseTest.getLastId("principal");
                    
                Console.WriteLine("Testing PrincipalOrg API insert: " + principalorg.ToString());
                await PostAsync("PrincipalOrg", principalorg);
                BaseTest.addLastId("principal_org", principalorg.id);
                    }

        public static async Task testUpdate()
        {
            long lastId = BaseTest.getLastId("PrincipalOrg");
            var principalorg = await GetByIdAsync<PrincipalOrg>("PrincipalOrg", lastId);


                            principalorg.org_id = BaseTest.getLastId("org");
                        
                            principalorg.principal_id = BaseTest.getLastId("principal");
                        
                Console.WriteLine("Testing PrincipalOrg API update: " + principalorg.ToString());
                await PutAsync("PrincipalOrg", lastId, principalorg);
                    }
    }
}
