
using System;


namespace defarge
{
    public interface ISchedulerStatusLogic
    {  
        // Generated methods
        List<SchedulerStatus> select();
        List<TBaseObject> select<TBaseObject>() where TBaseObject : BaseObject, new();
        List<TBaseObject> select<TBaseObject>(string queryName) where TBaseObject : BaseObject, new();
        List<SchedulerStatusHistory> history(long id);
        SchedulerStatus get(long id);
        void insert(SchedulerStatus schedulerstatus);
        void update(long id, SchedulerStatus schedulerstatus);
        void put(SchedulerStatus schedulerstatus);
        void delete( long id );
        List<TBaseObject> children<TBaseObject>(long id, string childSuffix) where TBaseObject : BaseObject, new();
        //string getDomainName();
        // Add user-defined methods here
    }


    public partial class SchedulerStatusLogic
    {
        protected SchedulerStatusLogic()
        {
           
        }
        
    }
}

