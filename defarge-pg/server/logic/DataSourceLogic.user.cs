
using System;


namespace defarge
{
    public interface IDataSourceLogic
    {  
        // Generated methods
        List<DataSource> select();
        List<TBaseObject> select<TBaseObject>() where TBaseObject : BaseObject, new();
        List<TBaseObject> select<TBaseObject>(string queryName) where TBaseObject : BaseObject, new();
        List<DataSourceHistory> history(long id);
        DataSource get(long id);
        void insert(DataSource datasource);
        void update(long id, DataSource datasource);
        void put(DataSource datasource);
        void delete( long id );
        List<TBaseObject> children<TBaseObject>(long id, string childSuffix) where TBaseObject : BaseObject, new();
        //string getDomainName();
        // Add user-defined methods here
    }


    public partial class DataSourceLogic
    {
        protected DataSourceLogic()
        {
           
        }
        
    }
}

