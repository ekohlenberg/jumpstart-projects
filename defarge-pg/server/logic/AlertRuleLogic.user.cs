
using System;


namespace defarge
{
    public interface IAlertRuleLogic
    {  
        // Generated methods
        List<AlertRule> select();
        List<TBaseObject> select<TBaseObject>() where TBaseObject : BaseObject, new();
        List<TBaseObject> select<TBaseObject>(string queryName) where TBaseObject : BaseObject, new();
        List<AlertRuleHistory> history(long id);
        AlertRule get(long id);
        void insert(AlertRule alertrule);
        void update(long id, AlertRule alertrule);
        void put(AlertRule alertrule);
        void delete( long id );
        List<TBaseObject> children<TBaseObject>(long id, string childSuffix) where TBaseObject : BaseObject, new();
        //string getDomainName();
        // Add user-defined methods here
    }


    public partial class AlertRuleLogic
    {
        protected AlertRuleLogic()
        {
           
        }
        
    }
}

