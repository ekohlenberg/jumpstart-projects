
using System;


namespace defarge
{
    public interface IMetricLogic
    {  
        // Generated methods
        List<Metric> select();
        List<TBaseObject> select<TBaseObject>() where TBaseObject : BaseObject, new();
        List<TBaseObject> select<TBaseObject>(string queryName) where TBaseObject : BaseObject, new();
        List<MetricHistory> history(long id);
        Metric get(long id);
        void insert(Metric metric);
        void update(long id, Metric metric);
        void put(Metric metric);
        void delete( long id );
        List<TBaseObject> children<TBaseObject>(long id, string childSuffix) where TBaseObject : BaseObject, new();
        //string getDomainName();
        // Add user-defined methods here
    }


    public partial class MetricLogic
    {
        protected MetricLogic()
        {
           
        }
        
    }
}

