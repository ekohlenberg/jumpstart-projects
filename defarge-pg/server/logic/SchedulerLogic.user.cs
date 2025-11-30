
using System;


namespace defarge
{
    public interface ISchedulerLogic
    {  
        // Generated methods
        List<Scheduler> select();
        List<TBaseObject> select<TBaseObject>() where TBaseObject : BaseObject, new();
        List<TBaseObject> select<TBaseObject>(string queryName) where TBaseObject : BaseObject, new();
        List<SchedulerHistory> history(long id);
        Scheduler get(long id);
        void insert(Scheduler scheduler);
        void update(long id, Scheduler scheduler);
        void put(Scheduler scheduler);
        void delete( long id );
        List<TBaseObject> children<TBaseObject>(long id, string childSuffix) where TBaseObject : BaseObject, new();
        //string getDomainName();
        // Add user-defined methods here
    }


    public partial class SchedulerLogic
    {
        protected SchedulerLogic()
        {
           
        }
        
    }
}

