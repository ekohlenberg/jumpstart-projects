
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Reflection;
using defarge;

namespace defarge
{


    public partial class DataSourceLogic : IDataSourceLogic
    {


        public static IDataSourceLogic Create()
        {
            var datasource = new DataSourceLogic();

            var proxy = DispatchProxy.Create<IDataSourceLogic, Proxy<IDataSourceLogic>>();
            ((Proxy<IDataSourceLogic>)proxy).Initialize();
            ((Proxy<IDataSourceLogic>)proxy).Target = datasource;
            ((Proxy<IDataSourceLogic>)proxy).DomainObj = "DataSource";

            return proxy;
        }

        public  List<DataSource> select()
        {
            return select<DataSource>();
        }

       
    
        public  List<TBaseObject> select<TBaseObject>() where TBaseObject : BaseObject, new()
        {
            Console.WriteLine("Processing DataSourceLogic select<TBaseObject> List");

            List<TBaseObject> datasources = select<TBaseObject>("core.data_source-select");

            
            return datasources;
        }

        public List<TBaseObject> select<TBaseObject>(string queryName) where TBaseObject : BaseObject, new()
        {
            Console.WriteLine($"Processing DataSourceLogic select<TBaseObject> with query: {queryName}");

            List<TBaseObject> datasources = DBPersist.ExecuteQueryByName<TBaseObject>(queryName);

            return datasources;
        }

         public  List<DataSourceHistory> history(long id)
        {
            List<DataSourceHistory> datasourceHistory = DBPersist.ExecuteQueryByName<DataSourceHistory>("core.data_source-get-history", new BaseObject() { { "id", id } });

            return datasourceHistory;
        }

        public List<TBaseObject> children<TBaseObject>(long id, string childSuffix) where TBaseObject : BaseObject, new()
        {
            Console.WriteLine($"Processing DataSourceLogic children<TBaseObject> for ID={id}, childSuffix={childSuffix}");

            string queryName = "core.data_source-children-" + childSuffix;
            List<TBaseObject> children = DBPersist.ExecuteQueryByName<TBaseObject>(queryName, new BaseObject() { { "id", id } });

            return children;
        }

        public  DataSource get(long id)
        {
            Console.WriteLine($"Processing DataSourceLogic get ID={id}");

            DataSource datasource = DBPersist.select<DataSource>($"SELECT * FROM core.data_source WHERE id = {id}").FirstOrDefault();
            

            return datasource;
        }

        public  void insert(DataSource datasource)
        {
            Console.WriteLine($"Processing DataSourceLogic insert: {datasource}");

            datasource.is_active = 1;

            DBPersist.insert(datasource);
        }

        public  void put(DataSource datasource)
        {
            Console.WriteLine($"Processing DataSourceLogic put: {datasource}");

            datasource.is_active = 1;

            DBPersist.put(datasource);
        }

        public  void update(long id, DataSource datasource)
        {
            Console.WriteLine($"Processing DataSourceLogic update: ID = {id}\n{datasource}");

            datasource.id = id;
            DBPersist.update(datasource);
        }

        public  void delete(long id)
        {
            DataSource datasource = get(id);
            datasource.is_active = 0;
            DBPersist.update(datasource);
        }
    }
}
