
using System;


namespace defarge
{
    public interface IExecStatusLogic
    {  
        // Generated methods
        List<ExecStatus> select();
        List<TBaseObject> select<TBaseObject>() where TBaseObject : BaseObject, new();
        List<TBaseObject> select<TBaseObject>(string queryName) where TBaseObject : BaseObject, new();
        List<ExecStatusHistory> history(long id);
        ExecStatus get(long id);
        void insert(ExecStatus execstatus);
        void update(long id, ExecStatus execstatus);
        void put(ExecStatus execstatus);
        void delete( long id );
        List<TBaseObject> children<TBaseObject>(long id, string childSuffix) where TBaseObject : BaseObject, new();
        //string getDomainName();
        // Add user-defined methods here
    }


    public partial class ExecStatusLogic
    {
        protected ExecStatusLogic()
        {
           
        }
        
    }
}

