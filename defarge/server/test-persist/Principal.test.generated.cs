using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using defarge;

namespace defarge
{
    public partial class PrincipalTest : BaseTest
    {
        public static void testInsert()
        {
            var principal = new Principal();


                    principal.first_name = Convert.ToString(BaseTest.getTestData(principal, "VARCHAR", TestDataType.firstnames));
                    
                    principal.last_name = Convert.ToString(BaseTest.getTestData(principal, "VARCHAR", TestDataType.lastnames));
                    
                    principal.username = Convert.ToString(BaseTest.getTestData(principal, "VARCHAR", TestDataType.os_user));
                    
                    principal.email = Convert.ToString(BaseTest.getTestData(principal, "VARCHAR", TestDataType.emailAddresses));
                    
                    principal.created_date = Convert.ToDateTime(BaseTest.getTestData(principal, "TIMESTAMP", TestDataType.random));
                    
                    principal.last_login_date = Convert.ToDateTime(BaseTest.getTestData(principal, "TIMESTAMP", TestDataType.random));
                    
                Console.WriteLine("Testing PrincipalLogic insert: " + principal.ToString());
                PrincipalLogic.Create().insert(principal);
                BaseTest.addLastId("principal", principal.id);
                    }

        public static void testUpdate()
        {
            long lastId = BaseTest.getLastId("Principal");
            var principal = PrincipalLogic.Create().get(lastId);


                        principal.first_name = (string) BaseTest.getTestData(principal, "VARCHAR", TestDataType.firstnames);
                    
                        principal.last_name = (string) BaseTest.getTestData(principal, "VARCHAR", TestDataType.lastnames);
                    
                        principal.username = (string) BaseTest.getTestData(principal, "VARCHAR", TestDataType.os_user);
                    
                        principal.email = (string) BaseTest.getTestData(principal, "VARCHAR", TestDataType.emailAddresses);
                    
                        principal.created_date = (DateTime) BaseTest.getTestData(principal, "TIMESTAMP", TestDataType.random);
                    
                        principal.last_login_date = (DateTime) BaseTest.getTestData(principal, "TIMESTAMP", TestDataType.random);
                    
                Console.WriteLine("Testing PrincipalLogic update: " + principal.ToString());
                PrincipalLogic.Create().update(lastId, principal);
                    }
    }
}
