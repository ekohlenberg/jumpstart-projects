
using System;


namespace defarge
{
    public interface IScheduleWorkflowLogic
    {  
        // Generated methods
        List<ScheduleWorkflow> select();
        List<TBaseObject> select<TBaseObject>() where TBaseObject : BaseObject, new();
        List<TBaseObject> select<TBaseObject>(string queryName) where TBaseObject : BaseObject, new();
        List<ScheduleWorkflowHistory> history(long id);
        ScheduleWorkflow get(long id);
        void insert(ScheduleWorkflow scheduleworkflow);
        void update(long id, ScheduleWorkflow scheduleworkflow);
        void put(ScheduleWorkflow scheduleworkflow);
        void delete( long id );
        List<TBaseObject> children<TBaseObject>(long id, string childSuffix) where TBaseObject : BaseObject, new();
        //string getDomainName();
        // Add user-defined methods here
    }


    public partial class ScheduleWorkflowLogic
    {
        protected ScheduleWorkflowLogic()
        {
           
        }
        
    }
}

