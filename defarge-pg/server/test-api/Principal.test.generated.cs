using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using defarge;

namespace defarge
{
    public partial class PrincipalTest : BaseTest
    {
        public static async Task testInsert()
        {
            var principal = new Principal();


                    principal.first_name = Convert.ToString(BaseTest.getTestData(principal, "VARCHAR", TestDataType.firstnames));
                    
                    principal.last_name = Convert.ToString(BaseTest.getTestData(principal, "VARCHAR", TestDataType.lastnames));
                    
                    principal.username = Convert.ToString(BaseTest.getTestData(principal, "VARCHAR", TestDataType.os_user));
                    
                    principal.email = Convert.ToString(BaseTest.getTestData(principal, "VARCHAR", TestDataType.emailAddresses));
                    
                    principal.created_date = Convert.ToDateTime(BaseTest.getTestData(principal, "TIMESTAMP", TestDataType.random));
                    
                    principal.last_login_date = Convert.ToDateTime(BaseTest.getTestData(principal, "TIMESTAMP", TestDataType.random));
                    
                Console.WriteLine("Testing Principal API insert: " + principal.ToString());
                var createdPrincipal = await PostAsyncReturn("Principal", principal);
                BaseTest.addLastId("principal", createdPrincipal.id);
                    }

        public static async Task testInsertRwkOnly()
        {
            var principal = new Principal();


                        principal.email = Convert.ToString(BaseTest.getTestData(principal, "VARCHAR", TestDataType.emailAddresses));
                        
                Console.WriteLine("Testing Principal API insert (RWK only): " + principal.ToString());
                var createdPrincipal = await PostAsyncReturn("Principal", principal);
                BaseTest.addLastId("principal", createdPrincipal.id);
                    }

        public static async Task testUpdate()
        {
            long lastId = BaseTest.getLastId("principal");
            var principalView = await GetByIdAsync<PrincipalView>("Principal", lastId);
            var principal = new Principal(principalView);


                        principal.first_name = (string) BaseTest.getTestData(principal, "VARCHAR", TestDataType.firstnames);
                    
                        principal.last_name = (string) BaseTest.getTestData(principal, "VARCHAR", TestDataType.lastnames);
                    
                        principal.username = (string) BaseTest.getTestData(principal, "VARCHAR", TestDataType.os_user);
                    
                        principal.email = (string) BaseTest.getTestData(principal, "VARCHAR", TestDataType.emailAddresses);
                    
                        principal.created_date = (DateTime) BaseTest.getTestData(principal, "TIMESTAMP", TestDataType.random);
                    
                        principal.last_login_date = (DateTime) BaseTest.getTestData(principal, "TIMESTAMP", TestDataType.random);
                    
                Console.WriteLine("Testing Principal API update: " + principal.ToString());
                await PutAsync("Principal", lastId, principal);
                    }

        public static async Task testPut()
        {
            long lastId = BaseTest.getLastId("principal");
            var principalView = await GetByIdAsync<PrincipalView>("Principal", lastId);
            var principal = new Principal(principalView);


                        principal.first_name = (string) BaseTest.getTestData(principal, "VARCHAR", TestDataType.firstnames);
                    
                        principal.last_name = (string) BaseTest.getTestData(principal, "VARCHAR", TestDataType.lastnames);
                    
                        principal.username = (string) BaseTest.getTestData(principal, "VARCHAR", TestDataType.os_user);
                    
                        principal.email = (string) BaseTest.getTestData(principal, "VARCHAR", TestDataType.emailAddresses);
                    
                        principal.created_date = (DateTime) BaseTest.getTestData(principal, "TIMESTAMP", TestDataType.random);
                    
                        principal.last_login_date = (DateTime) BaseTest.getTestData(principal, "TIMESTAMP", TestDataType.random);
                    
                Console.WriteLine("Testing Principal API update: " + principal.ToString());
                await PutAsync("Principal", lastId, principal);
                    }

        public static async Task testSelect()
        {
            Console.WriteLine("Testing Principal API select (list):");
            
            try
            {
                var principalList = await BaseTest.GetListAsync<Principal>("Principal");
                
                Console.WriteLine($"Retrieved {principalList.Count} Principal records");
                
                if (principalList.Count > 0)
                {
                    Console.WriteLine("First record: " + principalList[0].ToString());
                    
                    // Output all fields for each object, one per row
                    Console.WriteLine("\nDetailed Principal records:");
                    Console.WriteLine("=" + new string('=', 50));
                    
                    for (int i = 0; i < principalList.Count; i++)
                    {
                        var principal = principalList[i];
                        Console.WriteLine($"Record {i + 1}:");
                        Console.WriteLine($"  ID: {principal.id}");

                        Console.WriteLine($"  first_name: {principal.first_name}");
                                
                        Console.WriteLine($"  last_name: {principal.last_name}");
                                
                        Console.WriteLine($"  username: {principal.username}");
                                
                        Console.WriteLine($"  email: {principal.email}");
                                
                        Console.WriteLine($"  created_date: {principal.created_date}");
                                
                        Console.WriteLine($"  last_login_date: {principal.last_login_date}");
                                
                        Console.WriteLine($"  is_active: {principal.is_active}");
                                
                        Console.WriteLine($"  created_by: {principal.created_by}");
                                
                        Console.WriteLine($"  last_updated: {principal.last_updated}");
                                
                        Console.WriteLine($"  last_updated_by: {principal.last_updated_by}");
                                
                        Console.WriteLine($"  version: {principal.version}");
                                                        Console.WriteLine();
                    }
                    
                    // Store the first record for potential use in other tests
                    BaseTest.addLastId("@(Model.TableName)", principalList[0].id);
                }
                else
                {
                    Console.WriteLine("No Principal records found in database");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error testing Principal select: {ex.Message}");
                throw;
            }
        }
    }
}
