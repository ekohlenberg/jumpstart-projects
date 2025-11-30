using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using defarge;

namespace defarge
{
    public partial class ResourceTypeTest : BaseTest
    {
        public static async Task testInsert()
        {
            var resourcetype = new ResourceType();


                    resourcetype.name = Convert.ToString(BaseTest.getTestData(resourcetype, "VARCHAR", TestDataType.random));
                    
                Console.WriteLine("Testing ResourceType API insert: " + resourcetype.ToString());
                var createdResourceType = await PostAsyncReturn("ResourceType", resourcetype);
                BaseTest.addLastId("resourcetype", createdResourceType.id);
                    }

        public static async Task testInsertRwkOnly()
        {
            var resourcetype = new ResourceType();


                        resourcetype.name = Convert.ToString(BaseTest.getTestData(resourcetype, "VARCHAR", TestDataType.random));
                        
                Console.WriteLine("Testing ResourceType API insert (RWK only): " + resourcetype.ToString());
                var createdResourceType = await PostAsyncReturn("ResourceType", resourcetype);
                BaseTest.addLastId("resourcetype", createdResourceType.id);
                    }

        public static async Task testUpdate()
        {
            long lastId = BaseTest.getLastId("resourcetype");
            var resourcetypeView = await GetByIdAsync<ResourceTypeView>("ResourceType", lastId);
            var resourcetype = new ResourceType(resourcetypeView);


                        resourcetype.name = (string) BaseTest.getTestData(resourcetype, "VARCHAR", TestDataType.random);
                    
                Console.WriteLine("Testing ResourceType API update: " + resourcetype.ToString());
                await PutAsync("ResourceType", lastId, resourcetype);
                    }

        public static async Task testPut()
        {
            long lastId = BaseTest.getLastId("resourcetype");
            var resourcetypeView = await GetByIdAsync<ResourceTypeView>("ResourceType", lastId);
            var resourcetype = new ResourceType(resourcetypeView);


                        resourcetype.name = (string) BaseTest.getTestData(resourcetype, "VARCHAR", TestDataType.random);
                    
                Console.WriteLine("Testing ResourceType API update: " + resourcetype.ToString());
                await PutAsync("ResourceType", lastId, resourcetype);
                    }

        public static async Task testSelect()
        {
            Console.WriteLine("Testing ResourceType API select (list):");
            
            try
            {
                var resourcetypeList = await BaseTest.GetListAsync<ResourceType>("ResourceType");
                
                Console.WriteLine($"Retrieved {resourcetypeList.Count} ResourceType records");
                
                if (resourcetypeList.Count > 0)
                {
                    Console.WriteLine("First record: " + resourcetypeList[0].ToString());
                    
                    // Output all fields for each object, one per row
                    Console.WriteLine("\nDetailed ResourceType records:");
                    Console.WriteLine("=" + new string('=', 50));
                    
                    for (int i = 0; i < resourcetypeList.Count; i++)
                    {
                        var resourcetype = resourcetypeList[i];
                        Console.WriteLine($"Record {i + 1}:");
                        Console.WriteLine($"  ID: {resourcetype.id}");

                        Console.WriteLine($"  name: {resourcetype.name}");
                                
                        Console.WriteLine($"  is_active: {resourcetype.is_active}");
                                
                        Console.WriteLine($"  created_by: {resourcetype.created_by}");
                                
                        Console.WriteLine($"  last_updated: {resourcetype.last_updated}");
                                
                        Console.WriteLine($"  last_updated_by: {resourcetype.last_updated_by}");
                                
                        Console.WriteLine($"  version: {resourcetype.version}");
                                                        Console.WriteLine();
                    }
                    
                    // Store the first record for potential use in other tests
                    BaseTest.addLastId("@(Model.TableName)", resourcetypeList[0].id);
                }
                else
                {
                    Console.WriteLine("No ResourceType records found in database");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error testing ResourceType select: {ex.Message}");
                throw;
            }
        }
    }
}
