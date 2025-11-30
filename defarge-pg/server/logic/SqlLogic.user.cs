
using System;


namespace defarge
{
    public interface ISqlLogic
    {  
        // Generated methods
        List<Sql> select();
        List<TBaseObject> select<TBaseObject>() where TBaseObject : BaseObject, new();
        List<TBaseObject> select<TBaseObject>(string queryName) where TBaseObject : BaseObject, new();
        List<SqlHistory> history(long id);
        Sql get(long id);
        void insert(Sql sql);
        void update(long id, Sql sql);
        void put(Sql sql);
        void delete( long id );
        List<TBaseObject> children<TBaseObject>(long id, string childSuffix) where TBaseObject : BaseObject, new();
        //string getDomainName();
        // Add user-defined methods here
    }


    public partial class SqlLogic
    {
        protected SqlLogic()
        {
           
        }
        
    }
}

