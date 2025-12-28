
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Reflection;
using defarge;

namespace defarge
{


    public partial class MetricLogic : IMetricLogic
    {


        public static IMetricLogic Create()
        {
            var metric = new MetricLogic();

            var proxy = DispatchProxy.Create<IMetricLogic, Proxy<IMetricLogic>>();
            ((Proxy<IMetricLogic>)proxy).Initialize();
            ((Proxy<IMetricLogic>)proxy).Target = metric;
            ((Proxy<IMetricLogic>)proxy).DomainObj = "Metric";

            return proxy;
        }

        public  List<Metric> select()
        {
            return select<Metric>();
        }

       
    
        public  List<TBaseObject> select<TBaseObject>() where TBaseObject : BaseObject, new()
        {
            Logger.Debug("Processing MetricLogic select<TBaseObject> List");

            List<TBaseObject> metrics = select<TBaseObject>("app.metric-select");

            
            return metrics;
        }

        public List<TBaseObject> select<TBaseObject>(string queryName) where TBaseObject : BaseObject, new()
        {
            Logger.Debug($"Processing MetricLogic select<TBaseObject> with query: {queryName}");

            List<TBaseObject> metrics = DBPersist.ExecuteQueryByName<TBaseObject>(queryName);

            return metrics;
        }

         public  List<MetricHistory> history(long id)
        {
            List<MetricHistory> metricHistory = DBPersist.ExecuteQueryByName<MetricHistory>("app.metric-get-history", new BaseObject() { { "id", id } });

            return metricHistory;
        }

        public List<TBaseObject> children<TBaseObject>(long id, string childSuffix) where TBaseObject : BaseObject, new()
        {
            Logger.Debug($"Processing MetricLogic children<TBaseObject> for ID={id}, childSuffix={childSuffix}");

            string queryName = "app.metric-children-" + childSuffix;
            List<TBaseObject> children = DBPersist.ExecuteQueryByName<TBaseObject>(queryName, new BaseObject() { { "id", id } });

            return children;
        }

        public  Metric get(long id)
        {
            Logger.Debug($"Processing MetricLogic get ID={id}");

            Metric metric = DBPersist.select<Metric>($"SELECT * FROM app.metric WHERE id = {id}").FirstOrDefault();
            

            return metric;
        }

        public  void insert(Metric metric)
        {
            Logger.Debug($"Processing MetricLogic insert: {metric}");

            metric.is_active = 1;

            DBPersist.insert(metric);
        }

        public  void put(Metric metric)
        {
            Logger.Debug($"Processing MetricLogic put: {metric}");

            metric.is_active = 1;

            DBPersist.put(metric);
        }

        public  void update(long id, Metric metric)
        {
            Logger.Debug($"Processing MetricLogic update: ID = {id}\n{metric}");

            metric.id = id;
            DBPersist.update(metric);
        }

        public  void delete(long id)
        {
            Metric metric = get(id);
            metric.is_active = 0;
            DBPersist.update(metric);
        }
    }
}
