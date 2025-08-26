using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using defarge;

namespace defarge
{
    public partial class PrincipalOrgTest : BaseTest
    {
        public static void testInsert()
        {
            var principalorg = new PrincipalOrg();


                    principalorg.org_id = BaseTest.getLastId("org");
                    
                    principalorg.principal_id = BaseTest.getLastId("principal");
                    
                Console.WriteLine("Testing PrincipalOrgLogic insert: " + principalorg.ToString());
                PrincipalOrgLogic.Create().insert(principalorg);
                BaseTest.addLastId("principal_org", principalorg.id);
                    }

        public static void testUpdate()
        {
            long lastId = BaseTest.getLastId("PrincipalOrg");
            var principalorg = PrincipalOrgLogic.Create().get(lastId);


                            principalorg.org_id = BaseTest.getLastId("org");
                        
                            principalorg.principal_id = BaseTest.getLastId("principal");
                        
                Console.WriteLine("Testing PrincipalOrgLogic update: " + principalorg.ToString());
                PrincipalOrgLogic.Create().update(lastId, principalorg);
                    }
    }
}
