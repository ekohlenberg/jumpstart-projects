
using System;


namespace defarge
{
    public interface IMetricEventLogic
    {  
        // Generated methods
        List<MetricEvent> select();
        List<TBaseObject> select<TBaseObject>() where TBaseObject : BaseObject, new();
        List<TBaseObject> select<TBaseObject>(string queryName) where TBaseObject : BaseObject, new();
        List<MetricEventHistory> history(long id);
        MetricEvent get(long id);
        void insert(MetricEvent metricevent);
        void update(long id, MetricEvent metricevent);
        void put(MetricEvent metricevent);
        void delete( long id );
        List<TBaseObject> children<TBaseObject>(long id, string childSuffix) where TBaseObject : BaseObject, new();
        //string getDomainName();
        // Add user-defined methods here
    }


    public partial class MetricEventLogic
    {
        protected MetricEventLogic()
        {
           
        }
        
    }
}

