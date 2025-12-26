using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace defarge
{
    class Program
    {
        static async Task Main(string[] args)
        {
            try
            {

                // Get admin role
                var opRoles = await BaseTest.GetListAsync<OpRole>("OpRole");
                var adminRole = opRoles.Find(role => role.name == "Administrator");
                BaseTest.addLastId("op_role", adminRole.id);

                // Get current principal
                var principals = await BaseTest.GetListAsync<Principal>("Principal");
                var currentPrincipal = principals.Find(principal => principal.username == Environment.UserName);

                if (currentPrincipal == null)
                {
                    await PrincipalTest.testInsert();
                    long principalId = BaseTest.getLastId("Principal");
                    await OpRoleMemberTest.testInsert();
                }
                else
                {
                    BaseTest.addLastId("principal", currentPrincipal.id);

                    var opRoleMembers = await BaseTest.GetListAsync<OpRoleMember>("OpRoleMember");
                    var adminRoleMembership = opRoleMembers.Find(membership => membership.principal_id == currentPrincipal.id && membership.op_role_id == adminRole.id);

                    if (adminRoleMembership == null)
                    {
                        await OpRoleMemberTest.testInsert();
                    }
                }


                Logger.Info("Testing Category");
                await CategoryTest.testInsert();            
                await CategoryTest.testUpdate();    
                 await CategoryTest.testInsert();            
                await CategoryTest.testUpdate();     
                await CategoryTest.testSelect(); 
                await CategoryTest.testInsertRwkOnly();
                await CategoryTest.testSelect();           
                
                Logger.Info("Testing Uom");
                await UomTest.testInsert();            
                await UomTest.testUpdate();    
                 await UomTest.testInsert();            
                await UomTest.testUpdate();     
                await UomTest.testSelect(); 
                await UomTest.testInsertRwkOnly();
                await UomTest.testSelect();           
                
                Logger.Info("Testing ResourceType");
                await ResourceTypeTest.testInsert();            
                await ResourceTypeTest.testUpdate();    
                 await ResourceTypeTest.testInsert();            
                await ResourceTypeTest.testUpdate();     
                await ResourceTypeTest.testSelect(); 
                await ResourceTypeTest.testInsertRwkOnly();
                await ResourceTypeTest.testSelect();           
                
                Logger.Info("Testing Org");
                await OrgTest.testInsert();            
                await OrgTest.testUpdate();    
                 await OrgTest.testInsert();            
                await OrgTest.testUpdate();     
                await OrgTest.testSelect(); 
                await OrgTest.testInsertRwkOnly();
                await OrgTest.testSelect();           
                
                Logger.Info("Testing Metric");
                await MetricTest.testInsert();            
                await MetricTest.testUpdate();    
                 await MetricTest.testInsert();            
                await MetricTest.testUpdate();     
                await MetricTest.testSelect(); 
                await MetricTest.testInsertRwkOnly();
                await MetricTest.testSelect();           
                
                Logger.Info("Testing Resource");
                await ResourceTest.testInsert();            
                await ResourceTest.testUpdate();    
                 await ResourceTest.testInsert();            
                await ResourceTest.testUpdate();     
                await ResourceTest.testSelect(); 
                await ResourceTest.testInsertRwkOnly();
                await ResourceTest.testSelect();           
                
                Logger.Info("Testing PrincipalOrg");
                await PrincipalOrgTest.testInsert();            
                await PrincipalOrgTest.testUpdate();    
                 await PrincipalOrgTest.testInsert();            
                await PrincipalOrgTest.testUpdate();     
                await PrincipalOrgTest.testSelect(); 
                await PrincipalOrgTest.testInsertRwkOnly();
                await PrincipalOrgTest.testSelect();           
                
                Logger.Info("Testing MetricEvent");
                await MetricEventTest.testInsert();            
                await MetricEventTest.testUpdate();    
                 await MetricEventTest.testInsert();            
                await MetricEventTest.testUpdate();     
                await MetricEventTest.testSelect(); 
                await MetricEventTest.testInsertRwkOnly();
                await MetricEventTest.testSelect();           
                
                Logger.Info("Testing AlertRule");
                await AlertRuleTest.testInsert();            
                await AlertRuleTest.testUpdate();    
                 await AlertRuleTest.testInsert();            
                await AlertRuleTest.testUpdate();     
                await AlertRuleTest.testSelect(); 
                await AlertRuleTest.testInsertRwkOnly();
                await AlertRuleTest.testSelect();           
                
                Logger.Info("Testing MetricResourceMap");
                await MetricResourceMapTest.testInsert();            
                await MetricResourceMapTest.testUpdate();    
                 await MetricResourceMapTest.testInsert();            
                await MetricResourceMapTest.testUpdate();     
                await MetricResourceMapTest.testSelect(); 
                await MetricResourceMapTest.testInsertRwkOnly();
                await MetricResourceMapTest.testSelect();           
                
                Logger.Info("Testing Alert");
                await AlertTest.testInsert();            
                await AlertTest.testUpdate();    
                 await AlertTest.testInsert();            
                await AlertTest.testUpdate();     
                await AlertTest.testSelect(); 
                await AlertTest.testInsertRwkOnly();
                await AlertTest.testSelect();           
                            }
            catch( Exception x)
            {
                Logger.Error("Error executing test: ", x);
                Console.WriteLine(x.Message);
                Console.WriteLine(x.StackTrace);

                if (x.InnerException != null)
                {
                    x = x.InnerException;
                    Console.WriteLine(x.Message);
                    Console.WriteLine(x.StackTrace);
                }	
            }
		}
    }
}
