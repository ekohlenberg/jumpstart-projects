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
                await PostAsync("ResourceType", resourcetype);
                BaseTest.addLastId("resource_type", resourcetype.id);
                    }

        public static async Task testUpdate()
        {
            long lastId = BaseTest.getLastId("ResourceType");
            var resourcetype = await GetByIdAsync<ResourceType>("ResourceType", lastId);


                        resourcetype.name = (string) BaseTest.getTestData(resourcetype, "VARCHAR", TestDataType.random);
                    
                Console.WriteLine("Testing ResourceType API update: " + resourcetype.ToString());
                await PutAsync("ResourceType", lastId, resourcetype);
                    }
    }
}
