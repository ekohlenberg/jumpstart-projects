
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Reflection;
using defarge;

namespace defarge
{


    public partial class MetricResourceMapLogic : IMetricResourceMapLogic
    {


        public static IMetricResourceMapLogic Create()
        {
            var metricresourcemap = new MetricResourceMapLogic();

            var proxy = DispatchProxy.Create<IMetricResourceMapLogic, Proxy<IMetricResourceMapLogic>>();
            ((Proxy<IMetricResourceMapLogic>)proxy).Initialize();
            ((Proxy<IMetricResourceMapLogic>)proxy).Target = metricresourcemap;
            ((Proxy<IMetricResourceMapLogic>)proxy).DomainObj = "MetricResourceMap";

            return proxy;
        }

        public  List<MetricResourceMap> select()
        {
            return select<MetricResourceMap>();
        }

       
    
        public  List<TBaseObject> select<TBaseObject>() where TBaseObject : BaseObject, new()
        {
            Console.WriteLine("Processing MetricResourceMapLogic select<TBaseObject> List");

            List<TBaseObject> metricresourcemaps = select<TBaseObject>("app.metric_resource_map-select");

            
            return metricresourcemaps;
        }

        public List<TBaseObject> select<TBaseObject>(string queryName) where TBaseObject : BaseObject, new()
        {
            Console.WriteLine($"Processing MetricResourceMapLogic select<TBaseObject> with query: {queryName}");

            List<TBaseObject> metricresourcemaps = DBPersist.ExecuteQueryByName<TBaseObject>(queryName);

            return metricresourcemaps;
        }

         public  List<MetricResourceMapHistory> history(long id)
        {
            List<MetricResourceMapHistory> metricresourcemapHistory = DBPersist.ExecuteQueryByName<MetricResourceMapHistory>("app.metric_resource_map-get-history", new BaseObject() { { "id", id } });

            return metricresourcemapHistory;
        }

        public List<TBaseObject> children<TBaseObject>(long id, string childSuffix) where TBaseObject : BaseObject, new()
        {
            Console.WriteLine($"Processing MetricResourceMapLogic children<TBaseObject> for ID={id}, childSuffix={childSuffix}");

            string queryName = "app.metric_resource_map-children-" + childSuffix;
            List<TBaseObject> children = DBPersist.ExecuteQueryByName<TBaseObject>(queryName, new BaseObject() { { "id", id } });

            return children;
        }

        public  MetricResourceMap get(long id)
        {
            Console.WriteLine($"Processing MetricResourceMapLogic get ID={id}");

            MetricResourceMap metricresourcemap = DBPersist.select<MetricResourceMap>($"SELECT * FROM app.metric_resource_map WHERE id = {id}").FirstOrDefault();
            

            return metricresourcemap;
        }

        public  void insert(MetricResourceMap metricresourcemap)
        {
            Console.WriteLine($"Processing MetricResourceMapLogic insert: {metricresourcemap}");

            metricresourcemap.is_active = 1;

            DBPersist.insert(metricresourcemap);
        }

        public  void put(MetricResourceMap metricresourcemap)
        {
            Console.WriteLine($"Processing MetricResourceMapLogic put: {metricresourcemap}");

            metricresourcemap.is_active = 1;

            DBPersist.put(metricresourcemap);
        }

        public  void update(long id, MetricResourceMap metricresourcemap)
        {
            Console.WriteLine($"Processing MetricResourceMapLogic update: ID = {id}\n{metricresourcemap}");

            metricresourcemap.id = id;
            DBPersist.update(metricresourcemap);
        }

        public  void delete(long id)
        {
            MetricResourceMap metricresourcemap = get(id);
            metricresourcemap.is_active = 0;
            DBPersist.update(metricresourcemap);
        }
    }
}
