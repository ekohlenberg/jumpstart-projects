using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using defarge;

namespace defarge
{
    public partial class AlertTest : BaseTest
    {
        public static async Task testInsert()
        {
            var alert = new Alert();


                    alert.alert_rule_id = BaseTest.getLastId("AlertRule");
                    
                    alert.metric_event_id = BaseTest.getLastId("MetricEvent");
                    
                    alert.triggered_at = Convert.ToDateTime(BaseTest.getTestData(alert, "TIMESTAMP", TestDataType.random));
                    
                    alert.resolved_at = Convert.ToDateTime(BaseTest.getTestData(alert, "TIMESTAMP", TestDataType.random));
                    
                    alert.status = Convert.ToString(BaseTest.getTestData(alert, "VARCHAR", TestDataType.random));
                    
                Console.WriteLine("Testing Alert API insert: " + alert.ToString());
                var createdAlert = await PostAsyncReturn("Alert", alert);
                BaseTest.addLastId("alert", createdAlert.id);
                    }

        public static async Task testInsertRwkOnly()
        {
            var alert = new Alert();


                        alert.alert_rule_id = BaseTest.getLastId("AlertRule");
                        
                        alert.metric_event_id = BaseTest.getLastId("MetricEvent");
                        
                        alert.triggered_at = Convert.ToDateTime(BaseTest.getTestData(alert, "TIMESTAMP", TestDataType.random));
                        
                Console.WriteLine("Testing Alert API insert (RWK only): " + alert.ToString());
                var createdAlert = await PostAsyncReturn("Alert", alert);
                BaseTest.addLastId("alert", createdAlert.id);
                    }

        public static async Task testUpdate()
        {
            long lastId = BaseTest.getLastId("alert");
            var alertView = await GetByIdAsync<AlertView>("Alert", lastId);
            var alert = new Alert(alertView);


                            alert.alert_rule_id = BaseTest.getLastId("AlertRule");
                        
                            alert.metric_event_id = BaseTest.getLastId("MetricEvent");
                        
                        alert.triggered_at = (DateTime) BaseTest.getTestData(alert, "TIMESTAMP", TestDataType.random);
                    
                        alert.resolved_at = (DateTime) BaseTest.getTestData(alert, "TIMESTAMP", TestDataType.random);
                    
                        alert.status = (string) BaseTest.getTestData(alert, "VARCHAR", TestDataType.random);
                    
                Console.WriteLine("Testing Alert API update: " + alert.ToString());
                await PutAsync("Alert", lastId, alert);
                    }

        public static async Task testPut()
        {
            long lastId = BaseTest.getLastId("alert");
            var alertView = await GetByIdAsync<AlertView>("Alert", lastId);
            var alert = new Alert(alertView);


                            alert.alert_rule_id = BaseTest.getLastId("AlertRule");
                        
                            alert.metric_event_id = BaseTest.getLastId("MetricEvent");
                        
                        alert.triggered_at = (DateTime) BaseTest.getTestData(alert, "TIMESTAMP", TestDataType.random);
                    
                        alert.resolved_at = (DateTime) BaseTest.getTestData(alert, "TIMESTAMP", TestDataType.random);
                    
                        alert.status = (string) BaseTest.getTestData(alert, "VARCHAR", TestDataType.random);
                    
                Console.WriteLine("Testing Alert API update: " + alert.ToString());
                await PutAsync("Alert", lastId, alert);
                    }

        public static async Task testSelect()
        {
            Console.WriteLine("Testing Alert API select (list):");
            
            try
            {
                var alertList = await BaseTest.GetListAsync<Alert>("Alert");
                
                Console.WriteLine($"Retrieved {alertList.Count} Alert records");
                
                if (alertList.Count > 0)
                {
                    Console.WriteLine("First record: " + alertList[0].ToString());
                    
                    // Output all fields for each object, one per row
                    Console.WriteLine("\nDetailed Alert records:");
                    Console.WriteLine("=" + new string('=', 50));
                    
                    for (int i = 0; i < alertList.Count; i++)
                    {
                        var alert = alertList[i];
                        Console.WriteLine($"Record {i + 1}:");
                        Console.WriteLine($"  ID: {alert.id}");

                        Console.WriteLine($"  alert_rule_id: {alert.alert_rule_id}");
                                
                        Console.WriteLine($"  metric_event_id: {alert.metric_event_id}");
                                
                        Console.WriteLine($"  triggered_at: {alert.triggered_at}");
                                
                        Console.WriteLine($"  resolved_at: {alert.resolved_at}");
                                
                        Console.WriteLine($"  status: {alert.status}");
                                
                        Console.WriteLine($"  is_active: {alert.is_active}");
                                
                        Console.WriteLine($"  created_by: {alert.created_by}");
                                
                        Console.WriteLine($"  last_updated: {alert.last_updated}");
                                
                        Console.WriteLine($"  last_updated_by: {alert.last_updated_by}");
                                
                        Console.WriteLine($"  version: {alert.version}");
                                                        Console.WriteLine();
                    }
                    
                    // Store the first record for potential use in other tests
                    BaseTest.addLastId("@(Model.TableName)", alertList[0].id);
                }
                else
                {
                    Console.WriteLine("No Alert records found in database");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error testing Alert select: {ex.Message}");
                throw;
            }
        }
    }
}
