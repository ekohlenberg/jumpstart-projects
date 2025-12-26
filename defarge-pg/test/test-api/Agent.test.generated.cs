using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using defarge;

namespace defarge
{
    public partial class AgentTest : BaseTest
    {
        public static async Task testInsert()
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
                    
                    agent.agent_status_id = BaseTest.getLastId("AgentStatus");
                    
                Console.WriteLine("Testing Agent API insert: " + agent.ToString());
                var createdAgent = await PostAsyncReturn("Agent", agent);
                BaseTest.addLastId("agent", createdAgent.id);
                    }

        public static async Task testInsertRwkOnly()
        {
            var agent = new Agent();


                        agent.hostname = Convert.ToString(BaseTest.getTestData(agent, "VARCHAR", TestDataType.random));
                        
                        agent.ip_address = Convert.ToString(BaseTest.getTestData(agent, "VARCHAR", TestDataType.random));
                        
                        agent.port = Convert.ToInt32(BaseTest.getTestData(agent, "INTEGER", TestDataType.random));
                        
                Console.WriteLine("Testing Agent API insert (RWK only): " + agent.ToString());
                var createdAgent = await PostAsyncReturn("Agent", agent);
                BaseTest.addLastId("agent", createdAgent.id);
                    }

        public static async Task testUpdate()
        {
            long lastId = BaseTest.getLastId("agent");
            var agentView = await GetByIdAsync<AgentView>("Agent", lastId);
            var agent = new Agent(agentView);


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
                    
                            agent.agent_status_id = BaseTest.getLastId("AgentStatus");
                        
                Console.WriteLine("Testing Agent API update: " + agent.ToString());
                await PutAsync("Agent", lastId, agent);
                    }

        public static async Task testPut()
        {
            long lastId = BaseTest.getLastId("agent");
            var agentView = await GetByIdAsync<AgentView>("Agent", lastId);
            var agent = new Agent(agentView);


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
                    
                            agent.agent_status_id = BaseTest.getLastId("AgentStatus");
                        
                Console.WriteLine("Testing Agent API update: " + agent.ToString());
                await PutAsync("Agent", lastId, agent);
                    }

        public static async Task testSelect()
        {
            Console.WriteLine("Testing Agent API select (list):");
            
            try
            {
                var agentList = await BaseTest.GetListAsync<Agent>("Agent");
                
                Console.WriteLine($"Retrieved {agentList.Count} Agent records");
                
                if (agentList.Count > 0)
                {
                    Console.WriteLine("First record: " + agentList[0].ToString());
                    
                    // Output all fields for each object, one per row
                    Console.WriteLine("\nDetailed Agent records:");
                    Console.WriteLine("=" + new string('=', 50));
                    
                    for (int i = 0; i < agentList.Count; i++)
                    {
                        var agent = agentList[i];
                        Console.WriteLine($"Record {i + 1}:");
                        Console.WriteLine($"  ID: {agent.id}");

                        Console.WriteLine($"  hostname: {agent.hostname}");
                                
                        Console.WriteLine($"  ip_address: {agent.ip_address}");
                                
                        Console.WriteLine($"  port: {agent.port}");
                                
                        Console.WriteLine($"  username: {agent.username}");
                                
                        Console.WriteLine($"  url: {agent.url}");
                                
                        Console.WriteLine($"  user_domain: {agent.user_domain}");
                                
                        Console.WriteLine($"  os_name: {agent.os_name}");
                                
                        Console.WriteLine($"  os_version: {agent.os_version}");
                                
                        Console.WriteLine($"  architecture: {agent.architecture}");
                                
                        Console.WriteLine($"  registered_at: {agent.registered_at}");
                                
                        Console.WriteLine($"  agent_status_id: {agent.agent_status_id}");
                                
                        Console.WriteLine($"  is_active: {agent.is_active}");
                                
                        Console.WriteLine($"  created_by: {agent.created_by}");
                                
                        Console.WriteLine($"  last_updated: {agent.last_updated}");
                                
                        Console.WriteLine($"  last_updated_by: {agent.last_updated_by}");
                                
                        Console.WriteLine($"  version: {agent.version}");
                                                        Console.WriteLine();
                    }
                    
                    // Store the first record for potential use in other tests
                    BaseTest.addLastId("@(Model.TableName)", agentList[0].id);
                }
                else
                {
                    Console.WriteLine("No Agent records found in database");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error testing Agent select: {ex.Message}");
                throw;
            }
        }
    }
}
