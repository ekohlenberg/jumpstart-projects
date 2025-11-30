
using System;


namespace defarge
{
    public interface IWorkflowProcessLogic
    {  
        // Generated methods
        List<WorkflowProcess> select();
        List<TBaseObject> select<TBaseObject>() where TBaseObject : BaseObject, new();
        List<TBaseObject> select<TBaseObject>(string queryName) where TBaseObject : BaseObject, new();
        List<WorkflowProcessHistory> history(long id);
        WorkflowProcess get(long id);
        void insert(WorkflowProcess workflowprocess);
        void update(long id, WorkflowProcess workflowprocess);
        void put(WorkflowProcess workflowprocess);
        void delete( long id );
        List<TBaseObject> children<TBaseObject>(long id, string childSuffix) where TBaseObject : BaseObject, new();
        //string getDomainName();
        // Add user-defined methods here
    }


    public partial class WorkflowProcessLogic
    {
        protected WorkflowProcessLogic()
        {
           
        }
        
    }
}

