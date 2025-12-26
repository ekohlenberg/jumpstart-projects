using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using defarge;

namespace defarge
{
    public partial class PrincipalPasswordTest : BaseTest
    {
        public static void testInsert()
        {
            var principalpassword = new PrincipalPassword();


                    principalpassword.principal_id = BaseTest.getLastId("principal");
                    
                    principalpassword.password_hash = Convert.ToString(BaseTest.getTestData(principalpassword, "VARCHAR", TestDataType.random));
                    
                    principalpassword.expiry = Convert.ToDateTime(BaseTest.getTestData(principalpassword, "TIMESTAMP", TestDataType.random));
                    
                    principalpassword.needs_reset = Convert.ToInt32(BaseTest.getTestData(principalpassword, "INTEGER", TestDataType.random));
                    
                Logger.Info("Testing PrincipalPasswordLogic insert: " + principalpassword.ToString());
                PrincipalPasswordLogic.Create().insert(principalpassword);
                BaseTest.addLastId("principalpassword", principalpassword.id);
                    }

        public static void testUpdate()
        {
            long lastId = BaseTest.getLastId("principalpassword");
            var principalpasswordView  = PrincipalPasswordLogic.Create().get(lastId);

            PrincipalPassword principalpassword = new PrincipalPassword(principalpasswordView);

                            principalpassword.principal_id = BaseTest.getLastId("principal");
                        
                        principalpassword.password_hash = (string) BaseTest.getTestData(principalpassword, "VARCHAR", TestDataType.random);
                    
                        principalpassword.expiry = (DateTime) BaseTest.getTestData(principalpassword, "TIMESTAMP", TestDataType.random);
                    
                        principalpassword.needs_reset = (int) BaseTest.getTestData(principalpassword, "INTEGER", TestDataType.random);
                    
                Logger.Info("Testing PrincipalPasswordLogic update: " + principalpassword.ToString());
                PrincipalPasswordLogic.Create().update(lastId, principalpassword);
                    }
    }
}
