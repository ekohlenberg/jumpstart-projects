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


                    principalorg.org_id = BaseTest.getLastId("Org");
                    
                    principalorg.principal_id = BaseTest.getLastId("Principal");
                    
                Console.WriteLine("Testing PrincipalOrg API insert: " + principalorg.ToString());
                var createdPrincipalOrg = await PostAsyncReturn("PrincipalOrg", principalorg);
                BaseTest.addLastId("principalorg", createdPrincipalOrg.id);
                    }

        public static async Task testInsertRwkOnly()
        {
            var principalorg = new PrincipalOrg();


                        principalorg.org_id = BaseTest.getLastId("Org");
                        
                        principalorg.principal_id = BaseTest.getLastId("Principal");
                        
                Console.WriteLine("Testing PrincipalOrg API insert (RWK only): " + principalorg.ToString());
                var createdPrincipalOrg = await PostAsyncReturn("PrincipalOrg", principalorg);
                BaseTest.addLastId("principalorg", createdPrincipalOrg.id);
                    }

        public static async Task testUpdate()
        {
            long lastId = BaseTest.getLastId("principalorg");
            var principalorgView = await GetByIdAsync<PrincipalOrgView>("PrincipalOrg", lastId);
            var principalorg = new PrincipalOrg(principalorgView);


                            principalorg.org_id = BaseTest.getLastId("Org");
                        
                            principalorg.principal_id = BaseTest.getLastId("Principal");
                        
                Console.WriteLine("Testing PrincipalOrg API update: " + principalorg.ToString());
                await PutAsync("PrincipalOrg", lastId, principalorg);
                    }

        public static async Task testPut()
        {
            long lastId = BaseTest.getLastId("principalorg");
            var principalorgView = await GetByIdAsync<PrincipalOrgView>("PrincipalOrg", lastId);
            var principalorg = new PrincipalOrg(principalorgView);


                            principalorg.org_id = BaseTest.getLastId("Org");
                        
                            principalorg.principal_id = BaseTest.getLastId("Principal");
                        
                Console.WriteLine("Testing PrincipalOrg API update: " + principalorg.ToString());
                await PutAsync("PrincipalOrg", lastId, principalorg);
                    }

        public static async Task testSelect()
        {
            Console.WriteLine("Testing PrincipalOrg API select (list):");
            
            try
            {
                var principalorgList = await BaseTest.GetListAsync<PrincipalOrg>("PrincipalOrg");
                
                Console.WriteLine($"Retrieved {principalorgList.Count} PrincipalOrg records");
                
                if (principalorgList.Count > 0)
                {
                    Console.WriteLine("First record: " + principalorgList[0].ToString());
                    
                    // Output all fields for each object, one per row
                    Console.WriteLine("\nDetailed PrincipalOrg records:");
                    Console.WriteLine("=" + new string('=', 50));
                    
                    for (int i = 0; i < principalorgList.Count; i++)
                    {
                        var principalorg = principalorgList[i];
                        Console.WriteLine($"Record {i + 1}:");
                        Console.WriteLine($"  ID: {principalorg.id}");

                        Console.WriteLine($"  org_id: {principalorg.org_id}");
                                
                        Console.WriteLine($"  principal_id: {principalorg.principal_id}");
                                
                        Console.WriteLine($"  is_active: {principalorg.is_active}");
                                
                        Console.WriteLine($"  created_by: {principalorg.created_by}");
                                
                        Console.WriteLine($"  last_updated: {principalorg.last_updated}");
                                
                        Console.WriteLine($"  last_updated_by: {principalorg.last_updated_by}");
                                
                        Console.WriteLine($"  version: {principalorg.version}");
                                                        Console.WriteLine();
                    }
                    
                    // Store the first record for potential use in other tests
                    BaseTest.addLastId("@(Model.TableName)", principalorgList[0].id);
                }
                else
                {
                    Console.WriteLine("No PrincipalOrg records found in database");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error testing PrincipalOrg select: {ex.Message}");
                throw;
            }
        }
    }
}
