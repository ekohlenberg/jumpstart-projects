
using System;


namespace defarge
{
    public interface IMetricResourceMapLogic
    {  
        // Generated methods
        List<MetricResourceMap> select();
        List<TBaseObject> select<TBaseObject>() where TBaseObject : BaseObject, new();
        List<TBaseObject> select<TBaseObject>(string queryName) where TBaseObject : BaseObject, new();
        List<MetricResourceMapHistory> history(long id);
        MetricResourceMap get(long id);
        void insert(MetricResourceMap metricresourcemap);
        void update(long id, MetricResourceMap metricresourcemap);
        void put(MetricResourceMap metricresourcemap);
        void delete( long id );
        List<TBaseObject> children<TBaseObject>(long id, string childSuffix) where TBaseObject : BaseObject, new();
        //string getDomainName();
        // Add user-defined methods here
    }


    public partial class MetricResourceMapLogic
    {
        protected MetricResourceMapLogic()
        {
           
        }
        
    }
}

