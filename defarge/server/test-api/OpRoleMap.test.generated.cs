using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using defarge;

namespace defarge
{
    public partial class OpRoleMapTest : BaseTest
    {
        public static async Task testInsert()
        {
            var oprolemap = new OpRoleMap();


                    oprolemap.op_id = BaseTest.getLastId("operation");
                    
                    oprolemap.op_role_id = BaseTest.getLastId("op_role");
                    
                Console.WriteLine("Testing OpRoleMap API insert: " + oprolemap.ToString());
                await PostAsync("OpRoleMap", oprolemap);
                BaseTest.addLastId("op_role_map", oprolemap.id);
                    }

        public static async Task testUpdate()
        {
            long lastId = BaseTest.getLastId("OpRoleMap");
            var oprolemap = await GetByIdAsync<OpRoleMap>("OpRoleMap", lastId);


                            oprolemap.op_id = BaseTest.getLastId("operation");
                        
                            oprolemap.op_role_id = BaseTest.getLastId("op_role");
                        
                Console.WriteLine("Testing OpRoleMap API update: " + oprolemap.ToString());
                await PutAsync("OpRoleMap", lastId, oprolemap);
                    }
    }
}
