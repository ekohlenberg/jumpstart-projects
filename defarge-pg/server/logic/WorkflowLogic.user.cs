
using System;


namespace defarge
{
    public interface IWorkflowLogic
    {  
        // Generated methods
        List<Workflow> select();
        List<TBaseObject> select<TBaseObject>() where TBaseObject : BaseObject, new();
        List<TBaseObject> select<TBaseObject>(string queryName) where TBaseObject : BaseObject, new();
        List<WorkflowHistory> history(long id);
        Workflow get(long id);
        void insert(Workflow workflow);
        void update(long id, Workflow workflow);
        void put(Workflow workflow);
        void delete( long id );
        List<TBaseObject> children<TBaseObject>(long id, string childSuffix) where TBaseObject : BaseObject, new();
        //string getDomainName();
        // Add user-defined methods here
    }


    public partial class WorkflowLogic
    {
        protected WorkflowLogic()
        {
           
        }
        
    }
}

