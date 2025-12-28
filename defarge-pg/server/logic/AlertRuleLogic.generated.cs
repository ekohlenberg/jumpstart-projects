
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Reflection;
using defarge;

namespace defarge
{


    public partial class AlertRuleLogic : IAlertRuleLogic
    {


        public static IAlertRuleLogic Create()
        {
            var alertrule = new AlertRuleLogic();

            var proxy = DispatchProxy.Create<IAlertRuleLogic, Proxy<IAlertRuleLogic>>();
            ((Proxy<IAlertRuleLogic>)proxy).Initialize();
            ((Proxy<IAlertRuleLogic>)proxy).Target = alertrule;
            ((Proxy<IAlertRuleLogic>)proxy).DomainObj = "AlertRule";

            return proxy;
        }

        public  List<AlertRule> select()
        {
            return select<AlertRule>();
        }

       
    
        public  List<TBaseObject> select<TBaseObject>() where TBaseObject : BaseObject, new()
        {
            Logger.Debug("Processing AlertRuleLogic select<TBaseObject> List");

            List<TBaseObject> alertrules = select<TBaseObject>("app.alert_rule-select");

            
            return alertrules;
        }

        public List<TBaseObject> select<TBaseObject>(string queryName) where TBaseObject : BaseObject, new()
        {
            Logger.Debug($"Processing AlertRuleLogic select<TBaseObject> with query: {queryName}");

            List<TBaseObject> alertrules = DBPersist.ExecuteQueryByName<TBaseObject>(queryName);

            return alertrules;
        }

         public  List<AlertRuleHistory> history(long id)
        {
            List<AlertRuleHistory> alertruleHistory = DBPersist.ExecuteQueryByName<AlertRuleHistory>("app.alert_rule-get-history", new BaseObject() { { "id", id } });

            return alertruleHistory;
        }

        public List<TBaseObject> children<TBaseObject>(long id, string childSuffix) where TBaseObject : BaseObject, new()
        {
            Logger.Debug($"Processing AlertRuleLogic children<TBaseObject> for ID={id}, childSuffix={childSuffix}");

            string queryName = "app.alert_rule-children-" + childSuffix;
            List<TBaseObject> children = DBPersist.ExecuteQueryByName<TBaseObject>(queryName, new BaseObject() { { "id", id } });

            return children;
        }

        public  AlertRule get(long id)
        {
            Logger.Debug($"Processing AlertRuleLogic get ID={id}");

            AlertRule alertrule = DBPersist.select<AlertRule>($"SELECT * FROM app.alert_rule WHERE id = {id}").FirstOrDefault();
            

            return alertrule;
        }

        public  void insert(AlertRule alertrule)
        {
            Logger.Debug($"Processing AlertRuleLogic insert: {alertrule}");

            alertrule.is_active = 1;

            DBPersist.insert(alertrule);
        }

        public  void put(AlertRule alertrule)
        {
            Logger.Debug($"Processing AlertRuleLogic put: {alertrule}");

            alertrule.is_active = 1;

            DBPersist.put(alertrule);
        }

        public  void update(long id, AlertRule alertrule)
        {
            Logger.Debug($"Processing AlertRuleLogic update: ID = {id}\n{alertrule}");

            alertrule.id = id;
            DBPersist.update(alertrule);
        }

        public  void delete(long id)
        {
            AlertRule alertrule = get(id);
            alertrule.is_active = 0;
            DBPersist.update(alertrule);
        }
    }
}
