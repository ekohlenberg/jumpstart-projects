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
                
                Logger.Info("Testing Uom");
                await UomTest.testInsert();            
                await UomTest.testUpdate();            
                
                Logger.Info("Testing ResourceType");
                await ResourceTypeTest.testInsert();            
                await ResourceTypeTest.testUpdate();            
                
                Logger.Info("Testing Org");
                await OrgTest.testInsert();            
                await OrgTest.testUpdate();            
                
                Logger.Info("Testing Metric");
                await MetricTest.testInsert();            
                await MetricTest.testUpdate();            
                
                Logger.Info("Testing Resource");
                await ResourceTest.testInsert();            
                await ResourceTest.testUpdate();            
                
                Logger.Info("Testing PrincipalOrg");
                await PrincipalOrgTest.testInsert();            
                await PrincipalOrgTest.testUpdate();            
                
                Logger.Info("Testing MetricEvent");
                await MetricEventTest.testInsert();            
                await MetricEventTest.testUpdate();            
                
                Logger.Info("Testing AlertRule");
                await AlertRuleTest.testInsert();            
                await AlertRuleTest.testUpdate();            
                
                Logger.Info("Testing MetricResourceMap");
                await MetricResourceMapTest.testInsert();            
                await MetricResourceMapTest.testUpdate();            
                
                Logger.Info("Testing Alert");
                await AlertTest.testInsert();            
                await AlertTest.testUpdate();            
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
