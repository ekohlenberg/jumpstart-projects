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
                    
                    resource.resource_type_id = BaseTest.getLastId("resource_type");
                    
                    resource.ip_address = Convert.ToString(BaseTest.getTestData(resource, "VARCHAR", TestDataType.random));
                    
                    resource.description = Convert.ToString(BaseTest.getTestData(resource, "VARCHAR", TestDataType.random));
                    
                Console.WriteLine("Testing Resource API insert: " + resource.ToString());
                await PostAsync("Resource", resource);
                BaseTest.addLastId("resource", resource.id);
                    }

        public static async Task testUpdate()
        {
            long lastId = BaseTest.getLastId("Resource");
            var resource = await GetByIdAsync<Resource>("Resource", lastId);


                        resource.name = (string) BaseTest.getTestData(resource, "VARCHAR", TestDataType.random);
                    
                            resource.resource_type_id = BaseTest.getLastId("resource_type");
                        
                        resource.ip_address = (string) BaseTest.getTestData(resource, "VARCHAR", TestDataType.random);
                    
                        resource.description = (string) BaseTest.getTestData(resource, "VARCHAR", TestDataType.random);
                    
                Console.WriteLine("Testing Resource API update: " + resource.ToString());
                await PutAsync("Resource", lastId, resource);
                    }
    }
}
