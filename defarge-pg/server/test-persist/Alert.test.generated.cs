using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using defarge;

namespace defarge
{
    public partial class AlertTest : BaseTest
    {
        public static void testInsert()
        {
            var alert = new Alert();


                    alert.alert_rule_id = BaseTest.getLastId("alertrule");
                    
                    alert.metric_event_id = BaseTest.getLastId("metricevent");
                    
                    alert.triggered_at = Convert.ToDateTime(BaseTest.getTestData(alert, "TIMESTAMP", TestDataType.random));
                    
                    alert.resolved_at = Convert.ToDateTime(BaseTest.getTestData(alert, "TIMESTAMP", TestDataType.random));
                    
                    alert.status = Convert.ToString(BaseTest.getTestData(alert, "VARCHAR", TestDataType.random));
                    
                Logger.Info("Testing AlertLogic insert: " + alert.ToString());
                AlertLogic.Create().insert(alert);
                BaseTest.addLastId("alert", alert.id);
                    }

        public static void testUpdate()
        {
            long lastId = BaseTest.getLastId("alert");
            var alertView  = AlertLogic.Create().get(lastId);

            Alert alert = new Alert(alertView);

                            alert.alert_rule_id = BaseTest.getLastId("alertrule");
                        
                            alert.metric_event_id = BaseTest.getLastId("metricevent");
                        
                        alert.triggered_at = (DateTime) BaseTest.getTestData(alert, "TIMESTAMP", TestDataType.random);
                    
                        alert.resolved_at = (DateTime) BaseTest.getTestData(alert, "TIMESTAMP", TestDataType.random);
                    
                        alert.status = (string) BaseTest.getTestData(alert, "VARCHAR", TestDataType.random);
                    
                Logger.Info("Testing AlertLogic update: " + alert.ToString());
                AlertLogic.Create().update(lastId, alert);
                    }
    }
}
