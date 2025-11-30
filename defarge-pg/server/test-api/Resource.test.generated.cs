using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using defarge;

namespace defarge
{
    public partial class ResourceTest : BaseTest
    {
        public static async Task testInsert()
        {
            var resource = new Resource();


                    resource.name = Convert.ToString(BaseTest.getTestData(resource, "VARCHAR", TestDataType.random));
                    
                    resource.resource_type_id = BaseTest.getLastId("ResourceType");
                    
                    resource.internal_org_id = BaseTest.getLastId("Org");
                    
                    resource.external_org_id = BaseTest.getLastId("Org");
                    
                    resource.ip_address = Convert.ToString(BaseTest.getTestData(resource, "VARCHAR", TestDataType.random));
                    
                    resource.description = Convert.ToString(BaseTest.getTestData(resource, "VARCHAR", TestDataType.random));
                    
                Console.WriteLine("Testing Resource API insert: " + resource.ToString());
                var createdResource = await PostAsyncReturn("Resource", resource);
                BaseTest.addLastId("resource", createdResource.id);
                    }

        public static async Task testInsertRwkOnly()
        {
            var resource = new Resource();


                        resource.name = Convert.ToString(BaseTest.getTestData(resource, "VARCHAR", TestDataType.random));
                        
                        resource.resource_type_id = BaseTest.getLastId("ResourceType");
                        
                        resource.internal_org_id = BaseTest.getLastId("Org");
                        
                        resource.external_org_id = BaseTest.getLastId("Org");
                        
                Console.WriteLine("Testing Resource API insert (RWK only): " + resource.ToString());
                var createdResource = await PostAsyncReturn("Resource", resource);
                BaseTest.addLastId("resource", createdResource.id);
                    }

        public static async Task testUpdate()
        {
            long lastId = BaseTest.getLastId("resource");
            var resourceView = await GetByIdAsync<ResourceView>("Resource", lastId);
            var resource = new Resource(resourceView);


                        resource.name = (string) BaseTest.getTestData(resource, "VARCHAR", TestDataType.random);
                    
                            resource.resource_type_id = BaseTest.getLastId("ResourceType");
                        
                            resource.internal_org_id = BaseTest.getLastId("Org");
                        
                            resource.external_org_id = BaseTest.getLastId("Org");
                        
                        resource.ip_address = (string) BaseTest.getTestData(resource, "VARCHAR", TestDataType.random);
                    
                        resource.description = (string) BaseTest.getTestData(resource, "VARCHAR", TestDataType.random);
                    
                Console.WriteLine("Testing Resource API update: " + resource.ToString());
                await PutAsync("Resource", lastId, resource);
                    }

        public static async Task testPut()
        {
            long lastId = BaseTest.getLastId("resource");
            var resourceView = await GetByIdAsync<ResourceView>("Resource", lastId);
            var resource = new Resource(resourceView);


                        resource.name = (string) BaseTest.getTestData(resource, "VARCHAR", TestDataType.random);
                    
                            resource.resource_type_id = BaseTest.getLastId("ResourceType");
                        
                            resource.internal_org_id = BaseTest.getLastId("Org");
                        
                            resource.external_org_id = BaseTest.getLastId("Org");
                        
                        resource.ip_address = (string) BaseTest.getTestData(resource, "VARCHAR", TestDataType.random);
                    
                        resource.description = (string) BaseTest.getTestData(resource, "VARCHAR", TestDataType.random);
                    
                Console.WriteLine("Testing Resource API update: " + resource.ToString());
                await PutAsync("Resource", lastId, resource);
                    }

        public static async Task testSelect()
        {
            Console.WriteLine("Testing Resource API select (list):");
            
            try
            {
                var resourceList = await BaseTest.GetListAsync<Resource>("Resource");
                
                Console.WriteLine($"Retrieved {resourceList.Count} Resource records");
                
                if (resourceList.Count > 0)
                {
                    Console.WriteLine("First record: " + resourceList[0].ToString());
                    
                    // Output all fields for each object, one per row
                    Console.WriteLine("\nDetailed Resource records:");
                    Console.WriteLine("=" + new string('=', 50));
                    
                    for (int i = 0; i < resourceList.Count; i++)
                    {
                        var resource = resourceList[i];
                        Console.WriteLine($"Record {i + 1}:");
                        Console.WriteLine($"  ID: {resource.id}");

                        Console.WriteLine($"  name: {resource.name}");
                                
                        Console.WriteLine($"  resource_type_id: {resource.resource_type_id}");
                                
                        Console.WriteLine($"  internal_org_id: {resource.internal_org_id}");
                                
                        Console.WriteLine($"  external_org_id: {resource.external_org_id}");
                                
                        Console.WriteLine($"  ip_address: {resource.ip_address}");
                                
                        Console.WriteLine($"  description: {resource.description}");
                                
                        Console.WriteLine($"  is_active: {resource.is_active}");
                                
                        Console.WriteLine($"  created_by: {resource.created_by}");
                                
                        Console.WriteLine($"  last_updated: {resource.last_updated}");
                                
                        Console.WriteLine($"  last_updated_by: {resource.last_updated_by}");
                                
                        Console.WriteLine($"  version: {resource.version}");
                                                        Console.WriteLine();
                    }
                    
                    // Store the first record for potential use in other tests
                    BaseTest.addLastId("@(Model.TableName)", resourceList[0].id);
                }
                else
                {
                    Console.WriteLine("No Resource records found in database");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error testing Resource select: {ex.Message}");
                throw;
            }
        }
    }
}
