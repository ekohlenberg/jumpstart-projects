using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using defarge;

namespace defarge
{
    public partial class OpRoleMemberTest : BaseTest
    {
        public static async Task testInsert()
        {
            var oprolemember = new OpRoleMember();


                    oprolemember.principal_id = BaseTest.getLastId("principal");
                    
                    oprolemember.op_role_id = BaseTest.getLastId("op_role");
                    
                Console.WriteLine("Testing OpRoleMember API insert: " + oprolemember.ToString());
                await PostAsync("OpRoleMember", oprolemember);
                BaseTest.addLastId("op_role_member", oprolemember.id);
                    }

        public static async Task testUpdate()
        {
            long lastId = BaseTest.getLastId("OpRoleMember");
            var oprolemember = await GetByIdAsync<OpRoleMember>("OpRoleMember", lastId);


                            oprolemember.principal_id = BaseTest.getLastId("principal");
                        
                            oprolemember.op_role_id = BaseTest.getLastId("op_role");
                        
                Console.WriteLine("Testing OpRoleMember API update: " + oprolemember.ToString());
                await PutAsync("OpRoleMember", lastId, oprolemember);
                    }
    }
}
