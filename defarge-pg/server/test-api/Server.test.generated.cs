using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using defarge;

namespace defarge
{
    public partial class ServerTest : BaseTest
    {
        public static async Task testInsert()
        {
            var server = new Server();


                    server.name = Convert.ToString(BaseTest.getTestData(server, "VARCHAR", TestDataType.random));
                    
                    server.type = Convert.ToString(BaseTest.getTestData(server, "VARCHAR", TestDataType.random));
                    
                    server.address = Convert.ToString(BaseTest.getTestData(server, "VARCHAR", TestDataType.random));
                    
                    server.port = Convert.ToInt32(BaseTest.getTestData(server, "INTEGER", TestDataType.random));
                    
                    server.is_default = Convert.ToInt32(BaseTest.getTestData(server, "INTEGER", TestDataType.random));
                    
                Console.WriteLine("Testing Server API insert: " + server.ToString());
                var createdServer = await PostAsyncReturn("Server", server);
                BaseTest.addLastId("server", createdServer.id);
                    }

        public static async Task testInsertRwkOnly()
        {
            var server = new Server();


                        server.name = Convert.ToString(BaseTest.getTestData(server, "VARCHAR", TestDataType.random));
                        
                        server.type = Convert.ToString(BaseTest.getTestData(server, "VARCHAR", TestDataType.random));
                        
                        server.address = Convert.ToString(BaseTest.getTestData(server, "VARCHAR", TestDataType.random));
                        
                        server.port = Convert.ToInt32(BaseTest.getTestData(server, "INTEGER", TestDataType.random));
                        
                Console.WriteLine("Testing Server API insert (RWK only): " + server.ToString());
                var createdServer = await PostAsyncReturn("Server", server);
                BaseTest.addLastId("server", createdServer.id);
                    }

        public static async Task testUpdate()
        {
            long lastId = BaseTest.getLastId("server");
            var serverView = await GetByIdAsync<ServerView>("Server", lastId);
            var server = new Server(serverView);


                        server.name = (string) BaseTest.getTestData(server, "VARCHAR", TestDataType.random);
                    
                        server.type = (string) BaseTest.getTestData(server, "VARCHAR", TestDataType.random);
                    
                        server.address = (string) BaseTest.getTestData(server, "VARCHAR", TestDataType.random);
                    
                        server.port = (int) BaseTest.getTestData(server, "INTEGER", TestDataType.random);
                    
                        server.is_default = (int) BaseTest.getTestData(server, "INTEGER", TestDataType.random);
                    
                Console.WriteLine("Testing Server API update: " + server.ToString());
                await PutAsync("Server", lastId, server);
                    }

        public static async Task testPut()
        {
            long lastId = BaseTest.getLastId("server");
            var serverView = await GetByIdAsync<ServerView>("Server", lastId);
            var server = new Server(serverView);


                        server.name = (string) BaseTest.getTestData(server, "VARCHAR", TestDataType.random);
                    
                        server.type = (string) BaseTest.getTestData(server, "VARCHAR", TestDataType.random);
                    
                        server.address = (string) BaseTest.getTestData(server, "VARCHAR", TestDataType.random);
                    
                        server.port = (int) BaseTest.getTestData(server, "INTEGER", TestDataType.random);
                    
                        server.is_default = (int) BaseTest.getTestData(server, "INTEGER", TestDataType.random);
                    
                Console.WriteLine("Testing Server API update: " + server.ToString());
                await PutAsync("Server", lastId, server);
                    }

        public static async Task testSelect()
        {
            Console.WriteLine("Testing Server API select (list):");
            
            try
            {
                var serverList = await BaseTest.GetListAsync<Server>("Server");
                
                Console.WriteLine($"Retrieved {serverList.Count} Server records");
                
                if (serverList.Count > 0)
                {
                    Console.WriteLine("First record: " + serverList[0].ToString());
                    
                    // Output all fields for each object, one per row
                    Console.WriteLine("\nDetailed Server records:");
                    Console.WriteLine("=" + new string('=', 50));
                    
                    for (int i = 0; i < serverList.Count; i++)
                    {
                        var server = serverList[i];
                        Console.WriteLine($"Record {i + 1}:");
                        Console.WriteLine($"  ID: {server.id}");

                        Console.WriteLine($"  name: {server.name}");
                                
                        Console.WriteLine($"  type: {server.type}");
                                
                        Console.WriteLine($"  address: {server.address}");
                                
                        Console.WriteLine($"  port: {server.port}");
                                
                        Console.WriteLine($"  is_default: {server.is_default}");
                                
                        Console.WriteLine($"  is_active: {server.is_active}");
                                
                        Console.WriteLine($"  created_by: {server.created_by}");
                                
                        Console.WriteLine($"  last_updated: {server.last_updated}");
                                
                        Console.WriteLine($"  last_updated_by: {server.last_updated_by}");
                                
                        Console.WriteLine($"  version: {server.version}");
                                                        Console.WriteLine();
                    }
                    
                    // Store the first record for potential use in other tests
                    BaseTest.addLastId("@(Model.TableName)", serverList[0].id);
                }
                else
                {
                    Console.WriteLine("No Server records found in database");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error testing Server select: {ex.Message}");
                throw;
            }
        }
    }
}
