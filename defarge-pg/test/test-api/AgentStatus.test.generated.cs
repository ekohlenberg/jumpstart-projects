using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using defarge;

namespace defarge
{
    public partial class AgentStatusTest : BaseTest
    {
        public static async Task testInsert()
        {
            var agentstatus = new AgentStatus();


                    agentstatus.name = Convert.ToString(BaseTest.getTestData(agentstatus, "VARCHAR", TestDataType.random));
                    
                Console.WriteLine("Testing AgentStatus API insert: " + agentstatus.ToString());
                var createdAgentStatus = await PostAsyncReturn("AgentStatus", agentstatus);
                BaseTest.addLastId("agentstatus", createdAgentStatus.id);
                    }

        public static async Task testInsertRwkOnly()
        {
            var agentstatus = new AgentStatus();


                        agentstatus.name = Convert.ToString(BaseTest.getTestData(agentstatus, "VARCHAR", TestDataType.random));
                        
                Console.WriteLine("Testing AgentStatus API insert (RWK only): " + agentstatus.ToString());
                var createdAgentStatus = await PostAsyncReturn("AgentStatus", agentstatus);
                BaseTest.addLastId("agentstatus", createdAgentStatus.id);
                    }

        public static async Task testUpdate()
        {
            long lastId = BaseTest.getLastId("agentstatus");
            var agentstatusView = await GetByIdAsync<AgentStatusView>("AgentStatus", lastId);
            var agentstatus = new AgentStatus(agentstatusView);


                        agentstatus.name = (string) BaseTest.getTestData(agentstatus, "VARCHAR", TestDataType.random);
                    
                Console.WriteLine("Testing AgentStatus API update: " + agentstatus.ToString());
                await PutAsync("AgentStatus", lastId, agentstatus);
                    }

        public static async Task testPut()
        {
            long lastId = BaseTest.getLastId("agentstatus");
            var agentstatusView = await GetByIdAsync<AgentStatusView>("AgentStatus", lastId);
            var agentstatus = new AgentStatus(agentstatusView);


                        agentstatus.name = (string) BaseTest.getTestData(agentstatus, "VARCHAR", TestDataType.random);
                    
                Console.WriteLine("Testing AgentStatus API update: " + agentstatus.ToString());
                await PutAsync("AgentStatus", lastId, agentstatus);
                    }

        public static async Task testSelect()
        {
            Console.WriteLine("Testing AgentStatus API select (list):");
            
            try
            {
                var agentstatusList = await BaseTest.GetListAsync<AgentStatus>("AgentStatus");
                
                Console.WriteLine($"Retrieved {agentstatusList.Count} AgentStatus records");
                
                if (agentstatusList.Count > 0)
                {
                    Console.WriteLine("First record: " + agentstatusList[0].ToString());
                    
                    // Output all fields for each object, one per row
                    Console.WriteLine("\nDetailed AgentStatus records:");
                    Console.WriteLine("=" + new string('=', 50));
                    
                    for (int i = 0; i < agentstatusList.Count; i++)
                    {
                        var agentstatus = agentstatusList[i];
                        Console.WriteLine($"Record {i + 1}:");
                        Console.WriteLine($"  ID: {agentstatus.id}");

                        Console.WriteLine($"  name: {agentstatus.name}");
                                
                        Console.WriteLine($"  is_active: {agentstatus.is_active}");
                                
                        Console.WriteLine($"  created_by: {agentstatus.created_by}");
                                
                        Console.WriteLine($"  last_updated: {agentstatus.last_updated}");
                                
                        Console.WriteLine($"  last_updated_by: {agentstatus.last_updated_by}");
                                
                        Console.WriteLine($"  version: {agentstatus.version}");
                                                        Console.WriteLine();
                    }
                    
                    // Store the first record for potential use in other tests
                    BaseTest.addLastId("@(Model.TableName)", agentstatusList[0].id);
                }
                else
                {
                    Console.WriteLine("No AgentStatus records found in database");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error testing AgentStatus select: {ex.Message}");
                throw;
            }
        }
    }
}
