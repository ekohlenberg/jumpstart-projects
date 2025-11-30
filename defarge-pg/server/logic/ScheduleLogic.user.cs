
using System;


namespace defarge
{
    public interface IScheduleLogic
    {  
        // Generated methods
        List<Schedule> select();
        List<TBaseObject> select<TBaseObject>() where TBaseObject : BaseObject, new();
        List<TBaseObject> select<TBaseObject>(string queryName) where TBaseObject : BaseObject, new();
        List<ScheduleHistory> history(long id);
        Schedule get(long id);
        void insert(Schedule schedule);
        void update(long id, Schedule schedule);
        void put(Schedule schedule);
        void delete( long id );
        List<TBaseObject> children<TBaseObject>(long id, string childSuffix) where TBaseObject : BaseObject, new();
        //string getDomainName();
        // Add user-defined methods here
    }


    public partial class ScheduleLogic
    {
        protected ScheduleLogic()
        {
           
        }
        
    }
}

