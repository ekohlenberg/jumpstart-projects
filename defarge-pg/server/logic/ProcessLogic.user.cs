
using System;


namespace defarge
{
    public interface IProcessLogic
    {  
        // Generated methods
        List<Process> select();
        List<TBaseObject> select<TBaseObject>() where TBaseObject : BaseObject, new();
        List<TBaseObject> select<TBaseObject>(string queryName) where TBaseObject : BaseObject, new();
        List<ProcessHistory> history(long id);
        Process get(long id);
        void insert(Process process);
        void update(long id, Process process);
        void put(Process process);
        void delete( long id );
        List<TBaseObject> children<TBaseObject>(long id, string childSuffix) where TBaseObject : BaseObject, new();
        //string getDomainName();
        // Add user-defined methods here
    }


    public partial class ProcessLogic
    {
        protected ProcessLogic()
        {
           
        }
        
    }
}

