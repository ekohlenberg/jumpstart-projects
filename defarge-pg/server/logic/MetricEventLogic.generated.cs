
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Reflection;
using defarge;

namespace defarge
{


    public partial class MetricEventLogic : IMetricEventLogic
    {


        public static IMetricEventLogic Create()
        {
            var metricevent = new MetricEventLogic();

            var proxy = DispatchProxy.Create<IMetricEventLogic, Proxy<IMetricEventLogic>>();
            ((Proxy<IMetricEventLogic>)proxy).Initialize();
            ((Proxy<IMetricEventLogic>)proxy).Target = metricevent;
            ((Proxy<IMetricEventLogic>)proxy).DomainObj = "MetricEvent";

            return proxy;
        }

        public  List<MetricEvent> select()
        {
            return select<MetricEvent>();
        }

       
    
        public  List<TBaseObject> select<TBaseObject>() where TBaseObject : BaseObject, new()
        {
            Logger.Debug("Processing MetricEventLogic select<TBaseObject> List");

            List<TBaseObject> metricevents = select<TBaseObject>("app.metric_event-select");

            
            return metricevents;
        }

        public List<TBaseObject> select<TBaseObject>(string queryName) where TBaseObject : BaseObject, new()
        {
            Logger.Debug($"Processing MetricEventLogic select<TBaseObject> with query: {queryName}");

            List<TBaseObject> metricevents = DBPersist.ExecuteQueryByName<TBaseObject>(queryName);

            return metricevents;
        }

         public  List<MetricEventHistory> history(long id)
        {
            List<MetricEventHistory> metriceventHistory = DBPersist.ExecuteQueryByName<MetricEventHistory>("app.metric_event-get-history", new BaseObject() { { "id", id } });

            return metriceventHistory;
        }

        public List<TBaseObject> children<TBaseObject>(long id, string childSuffix) where TBaseObject : BaseObject, new()
        {
            Logger.Debug($"Processing MetricEventLogic children<TBaseObject> for ID={id}, childSuffix={childSuffix}");

            string queryName = "app.metric_event-children-" + childSuffix;
            List<TBaseObject> children = DBPersist.ExecuteQueryByName<TBaseObject>(queryName, new BaseObject() { { "id", id } });

            return children;
        }

        public  MetricEvent get(long id)
        {
            Logger.Debug($"Processing MetricEventLogic get ID={id}");

            MetricEvent metricevent = DBPersist.select<MetricEvent>($"SELECT * FROM app.metric_event WHERE id = {id}").FirstOrDefault();
            

            return metricevent;
        }

        public  void insert(MetricEvent metricevent)
        {
            Logger.Debug($"Processing MetricEventLogic insert: {metricevent}");

            metricevent.is_active = 1;

            DBPersist.insert(metricevent);
        }

        public  void put(MetricEvent metricevent)
        {
            Logger.Debug($"Processing MetricEventLogic put: {metricevent}");

            metricevent.is_active = 1;

            DBPersist.put(metricevent);
        }

        public  void update(long id, MetricEvent metricevent)
        {
            Logger.Debug($"Processing MetricEventLogic update: ID = {id}\n{metricevent}");

            metricevent.id = id;
            DBPersist.update(metricevent);
        }

        public  void delete(long id)
        {
            MetricEvent metricevent = get(id);
            metricevent.is_active = 0;
            DBPersist.update(metricevent);
        }
    }
}
