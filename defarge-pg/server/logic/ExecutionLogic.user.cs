
using System;


namespace defarge
{
    public interface IExecutionLogic
    {  
        // Generated methods
        List<Execution> select();
        List<TBaseObject> select<TBaseObject>() where TBaseObject : BaseObject, new();
        List<TBaseObject> select<TBaseObject>(string queryName) where TBaseObject : BaseObject, new();
        List<ExecutionHistory> history(long id);
        Execution get(long id);
        void insert(Execution execution);
        void update(long id, Execution execution);
        void put(Execution execution);
        void delete( long id );
        List<TBaseObject> children<TBaseObject>(long id, string childSuffix) where TBaseObject : BaseObject, new();
        //string getDomainName();
        // Add user-defined methods here
    }


    public partial class ExecutionLogic
    {
        protected ExecutionLogic()
        {
           
        }
        
    }
}

