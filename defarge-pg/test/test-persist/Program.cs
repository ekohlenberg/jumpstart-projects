using System;
using System.Collections.Generic;



namespace defarge
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                
                List<OpRole> opRoles = OpRoleLogic.Create().select();
                var adminRole = opRoles.Find(role => role.name == "Administrator");

                BaseTest.addLastId("op_role", adminRole.id);

                List<Principal> principals = PrincipalLogic.Create().select();
var currentPrincipal = principals.Find(principal => principal.username == Environment.UserName);

                if (currentPrincipal == null)
                {
                    PrincipalTest.testInsert();  
                    long principalId = BaseTest.getLastId("Principal");
                    OpRoleMemberTest.testInsert();
                }
                else
                {
                    BaseTest.addLastId("principal", currentPrincipal.id);

                    List<OpRoleMember> opRoleMembers = OpRoleMemberLogic.Create().select();
                    var adminRoleMembership = opRoleMembers.Find(membership => membership.principal_id == currentPrincipal.id && membership.op_role_id == adminRole.id);

                    if (adminRoleMembership == null)
                    {
                        OpRoleMemberTest.testInsert();
                    }
                }
                


                Logger.Info("Testing Category");
                CategoryTest.testInsert();            
                CategoryTest.testUpdate(); 
                CategoryTest.testInsert();            
                CategoryTest.testUpdate();            
                
                Logger.Info("Testing Uom");
                UomTest.testInsert();            
                UomTest.testUpdate(); 
                UomTest.testInsert();            
                UomTest.testUpdate();            
                
                Logger.Info("Testing ResourceType");
                ResourceTypeTest.testInsert();            
                ResourceTypeTest.testUpdate(); 
                ResourceTypeTest.testInsert();            
                ResourceTypeTest.testUpdate();            
                
                Logger.Info("Testing Org");
                OrgTest.testInsert();            
                OrgTest.testUpdate(); 
                OrgTest.testInsert();            
                OrgTest.testUpdate();            
                
                Logger.Info("Testing Metric");
                MetricTest.testInsert();            
                MetricTest.testUpdate(); 
                MetricTest.testInsert();            
                MetricTest.testUpdate();            
                
                Logger.Info("Testing Resource");
                ResourceTest.testInsert();            
                ResourceTest.testUpdate(); 
                ResourceTest.testInsert();            
                ResourceTest.testUpdate();            
                
                Logger.Info("Testing PrincipalOrg");
                PrincipalOrgTest.testInsert();            
                PrincipalOrgTest.testUpdate(); 
                PrincipalOrgTest.testInsert();            
                PrincipalOrgTest.testUpdate();            
                
                Logger.Info("Testing MetricEvent");
                MetricEventTest.testInsert();            
                MetricEventTest.testUpdate(); 
                MetricEventTest.testInsert();            
                MetricEventTest.testUpdate();            
                
                Logger.Info("Testing AlertRule");
                AlertRuleTest.testInsert();            
                AlertRuleTest.testUpdate(); 
                AlertRuleTest.testInsert();            
                AlertRuleTest.testUpdate();            
                
                Logger.Info("Testing MetricResourceMap");
                MetricResourceMapTest.testInsert();            
                MetricResourceMapTest.testUpdate(); 
                MetricResourceMapTest.testInsert();            
                MetricResourceMapTest.testUpdate();            
                
                Logger.Info("Testing Alert");
                AlertTest.testInsert();            
                AlertTest.testUpdate(); 
                AlertTest.testInsert();            
                AlertTest.testUpdate();            
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
