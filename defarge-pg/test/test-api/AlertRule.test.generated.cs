using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using defarge;

namespace defarge
{
    public partial class AlertRuleTest : BaseTest
    {
        public static async Task testInsert()
        {
            var alertrule = new AlertRule();


                    alertrule.metric_id = BaseTest.getLastId("Metric");
                    
                    alertrule.name = Convert.ToString(BaseTest.getTestData(alertrule, "VARCHAR", TestDataType.random));
                    
                    alertrule.condition = Convert.ToString(BaseTest.getTestData(alertrule, "VARCHAR", TestDataType.random));
                    
                    alertrule.threshold = Convert.ToDecimal(BaseTest.getTestData(alertrule, "NUMERIC(18,4)", TestDataType.random));
                    
                    alertrule.recipients = Convert.ToString(BaseTest.getTestData(alertrule, "VARCHAR", TestDataType.random));
                    
                Console.WriteLine("Testing AlertRule API insert: " + alertrule.ToString());
                var createdAlertRule = await PostAsyncReturn("AlertRule", alertrule);
                BaseTest.addLastId("alertrule", createdAlertRule.id);
                    }

        public static async Task testInsertRwkOnly()
        {
            var alertrule = new AlertRule();


                        alertrule.metric_id = BaseTest.getLastId("Metric");
                        
                        alertrule.name = Convert.ToString(BaseTest.getTestData(alertrule, "VARCHAR", TestDataType.random));
                        
                        alertrule.condition = Convert.ToString(BaseTest.getTestData(alertrule, "VARCHAR", TestDataType.random));
                        
                Console.WriteLine("Testing AlertRule API insert (RWK only): " + alertrule.ToString());
                var createdAlertRule = await PostAsyncReturn("AlertRule", alertrule);
                BaseTest.addLastId("alertrule", createdAlertRule.id);
                    }

        public static async Task testUpdate()
        {
            long lastId = BaseTest.getLastId("alertrule");
            var alertruleView = await GetByIdAsync<AlertRuleView>("AlertRule", lastId);
            var alertrule = new AlertRule(alertruleView);


                            alertrule.metric_id = BaseTest.getLastId("Metric");
                        
                        alertrule.name = (string) BaseTest.getTestData(alertrule, "VARCHAR", TestDataType.random);
                    
                        alertrule.condition = (string) BaseTest.getTestData(alertrule, "VARCHAR", TestDataType.random);
                    
                        alertrule.threshold = (decimal) BaseTest.getTestData(alertrule, "NUMERIC(18,4)", TestDataType.random);
                    
                        alertrule.recipients = (string) BaseTest.getTestData(alertrule, "VARCHAR", TestDataType.random);
                    
                Console.WriteLine("Testing AlertRule API update: " + alertrule.ToString());
                await PutAsync("AlertRule", lastId, alertrule);
                    }

        public static async Task testPut()
        {
            long lastId = BaseTest.getLastId("alertrule");
            var alertruleView = await GetByIdAsync<AlertRuleView>("AlertRule", lastId);
            var alertrule = new AlertRule(alertruleView);


                            alertrule.metric_id = BaseTest.getLastId("Metric");
                        
                        alertrule.name = (string) BaseTest.getTestData(alertrule, "VARCHAR", TestDataType.random);
                    
                        alertrule.condition = (string) BaseTest.getTestData(alertrule, "VARCHAR", TestDataType.random);
                    
                        alertrule.threshold = (decimal) BaseTest.getTestData(alertrule, "NUMERIC(18,4)", TestDataType.random);
                    
                        alertrule.recipients = (string) BaseTest.getTestData(alertrule, "VARCHAR", TestDataType.random);
                    
                Console.WriteLine("Testing AlertRule API update: " + alertrule.ToString());
                await PutAsync("AlertRule", lastId, alertrule);
                    }

        public static async Task testSelect()
        {
            Console.WriteLine("Testing AlertRule API select (list):");
            
            try
            {
                var alertruleList = await BaseTest.GetListAsync<AlertRule>("AlertRule");
                
                Console.WriteLine($"Retrieved {alertruleList.Count} AlertRule records");
                
                if (alertruleList.Count > 0)
                {
                    Console.WriteLine("First record: " + alertruleList[0].ToString());
                    
                    // Output all fields for each object, one per row
                    Console.WriteLine("\nDetailed AlertRule records:");
                    Console.WriteLine("=" + new string('=', 50));
                    
                    for (int i = 0; i < alertruleList.Count; i++)
                    {
                        var alertrule = alertruleList[i];
                        Console.WriteLine($"Record {i + 1}:");
                        Console.WriteLine($"  ID: {alertrule.id}");

                        Console.WriteLine($"  metric_id: {alertrule.metric_id}");
                                
                        Console.WriteLine($"  name: {alertrule.name}");
                                
                        Console.WriteLine($"  condition: {alertrule.condition}");
                                
                        Console.WriteLine($"  threshold: {alertrule.threshold}");
                                
                        Console.WriteLine($"  recipients: {alertrule.recipients}");
                                
                        Console.WriteLine($"  is_active: {alertrule.is_active}");
                                
                        Console.WriteLine($"  created_by: {alertrule.created_by}");
                                
                        Console.WriteLine($"  last_updated: {alertrule.last_updated}");
                                
                        Console.WriteLine($"  last_updated_by: {alertrule.last_updated_by}");
                                
                        Console.WriteLine($"  version: {alertrule.version}");
                                                        Console.WriteLine();
                    }
                    
                    // Store the first record for potential use in other tests
                    BaseTest.addLastId("@(Model.TableName)", alertruleList[0].id);
                }
                else
                {
                    Console.WriteLine("No AlertRule records found in database");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error testing AlertRule select: {ex.Message}");
                throw;
            }
        }
    }
}
