
using System;


namespace defarge
{
    public interface IAlertLogic
    {  
        // Generated methods
        List<Alert> select();
        List<TBaseObject> select<TBaseObject>() where TBaseObject : BaseObject, new();
        List<TBaseObject> select<TBaseObject>(string queryName) where TBaseObject : BaseObject, new();
        List<AlertHistory> history(long id);
        Alert get(long id);
        void insert(Alert alert);
        void update(long id, Alert alert);
        void put(Alert alert);
        void delete( long id );
        List<TBaseObject> children<TBaseObject>(long id, string childSuffix) where TBaseObject : BaseObject, new();
        //string getDomainName();
        // Add user-defined methods here
    }


    public partial class AlertLogic
    {
        protected AlertLogic()
        {
           
        }
        
    }
}

