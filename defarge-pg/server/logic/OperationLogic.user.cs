
using System;


namespace defarge
{
    public interface IOperationLogic
    {  
        // Generated methods
        List<Operation> select();
        List<TBaseObject> select<TBaseObject>() where TBaseObject : BaseObject, new();
        List<TBaseObject> select<TBaseObject>(string queryName) where TBaseObject : BaseObject, new();
        List<OperationHistory> history(long id);
        Operation get(long id);
        void insert(Operation operation);
        void update(long id, Operation operation);
        void put(Operation operation);
        void delete( long id );
        List<TBaseObject> children<TBaseObject>(long id, string childSuffix) where TBaseObject : BaseObject, new();
        //string getDomainName();
        // Add user-defined methods here
    }


    public partial class OperationLogic
    {
        protected OperationLogic()
        {
           
        }
        
    }
}

