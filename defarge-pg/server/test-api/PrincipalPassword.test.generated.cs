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


                    principalpassword.principal_id = BaseTest.getLastId("Principal");
                    
                    principalpassword.password_hash = Convert.ToString(BaseTest.getTestData(principalpassword, "VARCHAR", TestDataType.random));
                    
                    principalpassword.expiry = Convert.ToDateTime(BaseTest.getTestData(principalpassword, "TIMESTAMP", TestDataType.random));
                    
                    principalpassword.needs_reset = Convert.ToInt32(BaseTest.getTestData(principalpassword, "INTEGER", TestDataType.random));
                    
                Console.WriteLine("Testing PrincipalPassword API insert: " + principalpassword.ToString());
                var createdPrincipalPassword = await PostAsyncReturn("PrincipalPassword", principalpassword);
                BaseTest.addLastId("principalpassword", createdPrincipalPassword.id);
                    }

        public static async Task testInsertRwkOnly()
        {
            var principalpassword = new PrincipalPassword();


                        principalpassword.principal_id = BaseTest.getLastId("Principal");
                        
                Console.WriteLine("Testing PrincipalPassword API insert (RWK only): " + principalpassword.ToString());
                var createdPrincipalPassword = await PostAsyncReturn("PrincipalPassword", principalpassword);
                BaseTest.addLastId("principalpassword", createdPrincipalPassword.id);
                    }

        public static async Task testUpdate()
        {
            long lastId = BaseTest.getLastId("principalpassword");
            var principalpasswordView = await GetByIdAsync<PrincipalPasswordView>("PrincipalPassword", lastId);
            var principalpassword = new PrincipalPassword(principalpasswordView);


                            principalpassword.principal_id = BaseTest.getLastId("Principal");
                        
                        principalpassword.password_hash = (string) BaseTest.getTestData(principalpassword, "VARCHAR", TestDataType.random);
                    
                        principalpassword.expiry = (DateTime) BaseTest.getTestData(principalpassword, "TIMESTAMP", TestDataType.random);
                    
                        principalpassword.needs_reset = (int) BaseTest.getTestData(principalpassword, "INTEGER", TestDataType.random);
                    
                Console.WriteLine("Testing PrincipalPassword API update: " + principalpassword.ToString());
                await PutAsync("PrincipalPassword", lastId, principalpassword);
                    }

        public static async Task testPut()
        {
            long lastId = BaseTest.getLastId("principalpassword");
            var principalpasswordView = await GetByIdAsync<PrincipalPasswordView>("PrincipalPassword", lastId);
            var principalpassword = new PrincipalPassword(principalpasswordView);


                            principalpassword.principal_id = BaseTest.getLastId("Principal");
                        
                        principalpassword.password_hash = (string) BaseTest.getTestData(principalpassword, "VARCHAR", TestDataType.random);
                    
                        principalpassword.expiry = (DateTime) BaseTest.getTestData(principalpassword, "TIMESTAMP", TestDataType.random);
                    
                        principalpassword.needs_reset = (int) BaseTest.getTestData(principalpassword, "INTEGER", TestDataType.random);
                    
                Console.WriteLine("Testing PrincipalPassword API update: " + principalpassword.ToString());
                await PutAsync("PrincipalPassword", lastId, principalpassword);
                    }

        public static async Task testSelect()
        {
            Console.WriteLine("Testing PrincipalPassword API select (list):");
            
            try
            {
                var principalpasswordList = await BaseTest.GetListAsync<PrincipalPassword>("PrincipalPassword");
                
                Console.WriteLine($"Retrieved {principalpasswordList.Count} PrincipalPassword records");
                
                if (principalpasswordList.Count > 0)
                {
                    Console.WriteLine("First record: " + principalpasswordList[0].ToString());
                    
                    // Output all fields for each object, one per row
                    Console.WriteLine("\nDetailed PrincipalPassword records:");
                    Console.WriteLine("=" + new string('=', 50));
                    
                    for (int i = 0; i < principalpasswordList.Count; i++)
                    {
                        var principalpassword = principalpasswordList[i];
                        Console.WriteLine($"Record {i + 1}:");
                        Console.WriteLine($"  ID: {principalpassword.id}");

                        Console.WriteLine($"  principal_id: {principalpassword.principal_id}");
                                
                        Console.WriteLine($"  password_hash: {principalpassword.password_hash}");
                                
                        Console.WriteLine($"  expiry: {principalpassword.expiry}");
                                
                        Console.WriteLine($"  needs_reset: {principalpassword.needs_reset}");
                                
                        Console.WriteLine($"  is_active: {principalpassword.is_active}");
                                
                        Console.WriteLine($"  created_by: {principalpassword.created_by}");
                                
                        Console.WriteLine($"  last_updated: {principalpassword.last_updated}");
                                
                        Console.WriteLine($"  last_updated_by: {principalpassword.last_updated_by}");
                                
                        Console.WriteLine($"  version: {principalpassword.version}");
                                                        Console.WriteLine();
                    }
                    
                    // Store the first record for potential use in other tests
                    BaseTest.addLastId("@(Model.TableName)", principalpasswordList[0].id);
                }
                else
                {
                    Console.WriteLine("No PrincipalPassword records found in database");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error testing PrincipalPassword select: {ex.Message}");
                throw;
            }
        }
    }
}
