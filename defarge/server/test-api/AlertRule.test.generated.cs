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


                    alertrule.metric_id = BaseTest.getLastId("metric");
                    
                    alertrule.name = Convert.ToString(BaseTest.getTestData(alertrule, "VARCHAR", TestDataType.random));
                    
                    alertrule.condition = Convert.ToString(BaseTest.getTestData(alertrule, "VARCHAR", TestDataType.random));
                    
                    alertrule.threshold = Convert.ToDecimal(BaseTest.getTestData(alertrule, "NUMERIC(18,4)", TestDataType.random));
                    
                    alertrule.recipients = Convert.ToString(BaseTest.getTestData(alertrule, "VARCHAR", TestDataType.random));
                    
                Console.WriteLine("Testing AlertRule API insert: " + alertrule.ToString());
                await PostAsync("AlertRule", alertrule);
                BaseTest.addLastId("alert_rule", alertrule.id);
                    }

        public static async Task testUpdate()
        {
            long lastId = BaseTest.getLastId("AlertRule");
            var alertrule = await GetByIdAsync<AlertRule>("AlertRule", lastId);


                            alertrule.metric_id = BaseTest.getLastId("metric");
                        
                        alertrule.name = (string) BaseTest.getTestData(alertrule, "VARCHAR", TestDataType.random);
                    
                        alertrule.condition = (string) BaseTest.getTestData(alertrule, "VARCHAR", TestDataType.random);
                    
                        alertrule.threshold = (object) BaseTest.getTestData(alertrule, "NUMERIC(18,4)", TestDataType.random);
                    
                        alertrule.recipients = (string) BaseTest.getTestData(alertrule, "VARCHAR", TestDataType.random);
                    
                Console.WriteLine("Testing AlertRule API update: " + alertrule.ToString());
                await PutAsync("AlertRule", lastId, alertrule);
                    }
    }
}
