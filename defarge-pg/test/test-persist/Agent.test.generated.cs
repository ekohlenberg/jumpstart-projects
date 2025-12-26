using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using defarge;

namespace defarge
{
    public partial class AgentTest : BaseTest
    {
        public static void testInsert()
        {
            var agent = new Agent();


                    agent.hostname = Convert.ToString(BaseTest.getTestData(agent, "VARCHAR", TestDataType.random));
                    
                    agent.ip_address = Convert.ToString(BaseTest.getTestData(agent, "VARCHAR", TestDataType.random));
                    
                    agent.port = Convert.ToInt32(BaseTest.getTestData(agent, "INTEGER", TestDataType.random));
                    
                    agent.username = Convert.ToString(BaseTest.getTestData(agent, "VARCHAR", TestDataType.random));
                    
                    agent.url = Convert.ToString(BaseTest.getTestData(agent, "VARCHAR", TestDataType.random));
                    
                    agent.user_domain = Convert.ToString(BaseTest.getTestData(agent, "VARCHAR", TestDataType.random));
                    
                    agent.os_name = Convert.ToString(BaseTest.getTestData(agent, "VARCHAR", TestDataType.random));
                    
                    agent.os_version = Convert.ToString(BaseTest.getTestData(agent, "VARCHAR", TestDataType.random));
                    
                    agent.architecture = Convert.ToString(BaseTest.getTestData(agent, "VARCHAR", TestDataType.random));
                    
                    agent.registered_at = Convert.ToDateTime(BaseTest.getTestData(agent, "TIMESTAMP", TestDataType.random));
                    
                    agent.agent_status_id = BaseTest.getLastId("agentstatus");
                    
                Logger.Info("Testing AgentLogic insert: " + agent.ToString());
                AgentLogic.Create().insert(agent);
                BaseTest.addLastId("agent", agent.id);
                    }

        public static void testUpdate()
        {
            long lastId = BaseTest.getLastId("agent");
            var agentView  = AgentLogic.Create().get(lastId);

            Agent agent = new Agent(agentView);

                        agent.hostname = (string) BaseTest.getTestData(agent, "VARCHAR", TestDataType.random);
                    
                        agent.ip_address = (string) BaseTest.getTestData(agent, "VARCHAR", TestDataType.random);
                    
                        agent.port = (int) BaseTest.getTestData(agent, "INTEGER", TestDataType.random);
                    
                        agent.username = (string) BaseTest.getTestData(agent, "VARCHAR", TestDataType.random);
                    
                        agent.url = (string) BaseTest.getTestData(agent, "VARCHAR", TestDataType.random);
                    
                        agent.user_domain = (string) BaseTest.getTestData(agent, "VARCHAR", TestDataType.random);
                    
                        agent.os_name = (string) BaseTest.getTestData(agent, "VARCHAR", TestDataType.random);
                    
                        agent.os_version = (string) BaseTest.getTestData(agent, "VARCHAR", TestDataType.random);
                    
                        agent.architecture = (string) BaseTest.getTestData(agent, "VARCHAR", TestDataType.random);
                    
                        agent.registered_at = (DateTime) BaseTest.getTestData(agent, "TIMESTAMP", TestDataType.random);
                    
                            agent.agent_status_id = BaseTest.getLastId("agentstatus");
                        
                Logger.Info("Testing AgentLogic update: " + agent.ToString());
                AgentLogic.Create().update(lastId, agent);
                    }
    }
}
