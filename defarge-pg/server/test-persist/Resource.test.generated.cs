using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using defarge;

namespace defarge
{
    public partial class ResourceTest : BaseTest
    {
        public static void testInsert()
        {
            var resource = new Resource();


                    resource.name = Convert.ToString(BaseTest.getTestData(resource, "VARCHAR", TestDataType.random));
                    
                    resource.resource_type_id = BaseTest.getLastId("resourcetype");
                    
                    resource.internal_org_id = BaseTest.getLastId("org");
                    
                    resource.external_org_id = BaseTest.getLastId("org");
                    
                    resource.ip_address = Convert.ToString(BaseTest.getTestData(resource, "VARCHAR", TestDataType.random));
                    
                    resource.description = Convert.ToString(BaseTest.getTestData(resource, "VARCHAR", TestDataType.random));
                    
                Logger.Info("Testing ResourceLogic insert: " + resource.ToString());
                ResourceLogic.Create().insert(resource);
                BaseTest.addLastId("resource", resource.id);
                    }

        public static void testUpdate()
        {
            long lastId = BaseTest.getLastId("resource");
            var resourceView  = ResourceLogic.Create().get(lastId);

            Resource resource = new Resource(resourceView);

                        resource.name = (string) BaseTest.getTestData(resource, "VARCHAR", TestDataType.random);
                    
                            resource.resource_type_id = BaseTest.getLastId("resourcetype");
                        
                            resource.internal_org_id = BaseTest.getLastId("org");
                        
                            resource.external_org_id = BaseTest.getLastId("org");
                        
                        resource.ip_address = (string) BaseTest.getTestData(resource, "VARCHAR", TestDataType.random);
                    
                        resource.description = (string) BaseTest.getTestData(resource, "VARCHAR", TestDataType.random);
                    
                Logger.Info("Testing ResourceLogic update: " + resource.ToString());
                ResourceLogic.Create().update(lastId, resource);
                    }
    }
}
