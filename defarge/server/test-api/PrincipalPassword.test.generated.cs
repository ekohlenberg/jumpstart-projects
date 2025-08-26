using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using defarge;

namespace defarge
{
    public partial class PrincipalPasswordTest : BaseTest
    {
        public static async Task testInsert()
        {
            var principalpassword = new PrincipalPassword();


                    principalpassword.principal_id = BaseTest.getLastId("principal");
                    
                    principalpassword.password_hash = Convert.ToString(BaseTest.getTestData(principalpassword, "VARCHAR", TestDataType.random));
                    
                    principalpassword.expiry = Convert.ToDateTime(BaseTest.getTestData(principalpassword, "TIMESTAMP", TestDataType.random));
                    
                    principalpassword.needs_reset = Convert.ToInt32(BaseTest.getTestData(principalpassword, "INTEGER", TestDataType.random));
                    
                Console.WriteLine("Testing PrincipalPassword API insert: " + principalpassword.ToString());
                await PostAsync("PrincipalPassword", principalpassword);
                BaseTest.addLastId("principal_password", principalpassword.id);
                    }

        public static async Task testUpdate()
        {
            long lastId = BaseTest.getLastId("PrincipalPassword");
            var principalpassword = await GetByIdAsync<PrincipalPassword>("PrincipalPassword", lastId);


                            principalpassword.principal_id = BaseTest.getLastId("principal");
                        
                        principalpassword.password_hash = (string) BaseTest.getTestData(principalpassword, "VARCHAR", TestDataType.random);
                    
                        principalpassword.expiry = (DateTime) BaseTest.getTestData(principalpassword, "TIMESTAMP", TestDataType.random);
                    
                        principalpassword.needs_reset = (int) BaseTest.getTestData(principalpassword, "INTEGER", TestDataType.random);
                    
                Console.WriteLine("Testing PrincipalPassword API update: " + principalpassword.ToString());
                await PutAsync("PrincipalPassword", lastId, principalpassword);
                    }
    }
}
