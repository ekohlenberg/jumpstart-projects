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


                    alert.alert_rule_id = BaseTest.getLastId("alert_rule");
                    
                    alert.metric_event_id = BaseTest.getLastId("metric_event");
                    
                    alert.triggered_at = Convert.ToDateTime(BaseTest.getTestData(alert, "TIMESTAMP", TestDataType.random));
                    
                    alert.resolved_at = Convert.ToDateTime(BaseTest.getTestData(alert, "TIMESTAMP", TestDataType.random));
                    
                    alert.status = Convert.ToString(BaseTest.getTestData(alert, "VARCHAR", TestDataType.random));
                    
                Console.WriteLine("Testing Alert API insert: " + alert.ToString());
                await PostAsync("Alert", alert);
                BaseTest.addLastId("alert", alert.id);
                    }

        public static async Task testUpdate()
        {
            long lastId = BaseTest.getLastId("Alert");
            var alert = await GetByIdAsync<Alert>("Alert", lastId);


                            alert.alert_rule_id = BaseTest.getLastId("alert_rule");
                        
                            alert.metric_event_id = BaseTest.getLastId("metric_event");
                        
                        alert.triggered_at = (DateTime) BaseTest.getTestData(alert, "TIMESTAMP", TestDataType.random);
                    
                        alert.resolved_at = (DateTime) BaseTest.getTestData(alert, "TIMESTAMP", TestDataType.random);
                    
                        alert.status = (string) BaseTest.getTestData(alert, "VARCHAR", TestDataType.random);
                    
                Console.WriteLine("Testing Alert API update: " + alert.ToString());
                await PutAsync("Alert", lastId, alert);
                    }
    }
}
