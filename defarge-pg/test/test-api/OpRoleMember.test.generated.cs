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


                    oprolemember.principal_id = BaseTest.getLastId("Principal");
                    
                    oprolemember.op_role_id = BaseTest.getLastId("OpRole");
                    
                Console.WriteLine("Testing OpRoleMember API insert: " + oprolemember.ToString());
                var createdOpRoleMember = await PostAsyncReturn("OpRoleMember", oprolemember);
                BaseTest.addLastId("oprolemember", createdOpRoleMember.id);
                    }

        public static async Task testInsertRwkOnly()
        {
            var oprolemember = new OpRoleMember();


                        oprolemember.principal_id = BaseTest.getLastId("Principal");
                        
                        oprolemember.op_role_id = BaseTest.getLastId("OpRole");
                        
                Console.WriteLine("Testing OpRoleMember API insert (RWK only): " + oprolemember.ToString());
                var createdOpRoleMember = await PostAsyncReturn("OpRoleMember", oprolemember);
                BaseTest.addLastId("oprolemember", createdOpRoleMember.id);
                    }

        public static async Task testUpdate()
        {
            long lastId = BaseTest.getLastId("oprolemember");
            var oprolememberView = await GetByIdAsync<OpRoleMemberView>("OpRoleMember", lastId);
            var oprolemember = new OpRoleMember(oprolememberView);


                            oprolemember.principal_id = BaseTest.getLastId("Principal");
                        
                            oprolemember.op_role_id = BaseTest.getLastId("OpRole");
                        
                Console.WriteLine("Testing OpRoleMember API update: " + oprolemember.ToString());
                await PutAsync("OpRoleMember", lastId, oprolemember);
                    }

        public static async Task testPut()
        {
            long lastId = BaseTest.getLastId("oprolemember");
            var oprolememberView = await GetByIdAsync<OpRoleMemberView>("OpRoleMember", lastId);
            var oprolemember = new OpRoleMember(oprolememberView);


                            oprolemember.principal_id = BaseTest.getLastId("Principal");
                        
                            oprolemember.op_role_id = BaseTest.getLastId("OpRole");
                        
                Console.WriteLine("Testing OpRoleMember API update: " + oprolemember.ToString());
                await PutAsync("OpRoleMember", lastId, oprolemember);
                    }

        public static async Task testSelect()
        {
            Console.WriteLine("Testing OpRoleMember API select (list):");
            
            try
            {
                var oprolememberList = await BaseTest.GetListAsync<OpRoleMember>("OpRoleMember");
                
                Console.WriteLine($"Retrieved {oprolememberList.Count} OpRoleMember records");
                
                if (oprolememberList.Count > 0)
                {
                    Console.WriteLine("First record: " + oprolememberList[0].ToString());
                    
                    // Output all fields for each object, one per row
                    Console.WriteLine("\nDetailed OpRoleMember records:");
                    Console.WriteLine("=" + new string('=', 50));
                    
                    for (int i = 0; i < oprolememberList.Count; i++)
                    {
                        var oprolemember = oprolememberList[i];
                        Console.WriteLine($"Record {i + 1}:");
                        Console.WriteLine($"  ID: {oprolemember.id}");

                        Console.WriteLine($"  principal_id: {oprolemember.principal_id}");
                                
                        Console.WriteLine($"  op_role_id: {oprolemember.op_role_id}");
                                
                        Console.WriteLine($"  is_active: {oprolemember.is_active}");
                                
                        Console.WriteLine($"  created_by: {oprolemember.created_by}");
                                
                        Console.WriteLine($"  last_updated: {oprolemember.last_updated}");
                                
                        Console.WriteLine($"  last_updated_by: {oprolemember.last_updated_by}");
                                
                        Console.WriteLine($"  version: {oprolemember.version}");
                                                        Console.WriteLine();
                    }
                    
                    // Store the first record for potential use in other tests
                    BaseTest.addLastId("@(Model.TableName)", oprolememberList[0].id);
                }
                else
                {
                    Console.WriteLine("No OpRoleMember records found in database");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error testing OpRoleMember select: {ex.Message}");
                throw;
            }
        }
    }
}
