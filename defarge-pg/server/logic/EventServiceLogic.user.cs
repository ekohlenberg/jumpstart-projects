
using System;


namespace defarge
{
    public interface IEventServiceLogic
    {  
        // Generated methods
        List<EventService> select();
        List<TBaseObject> select<TBaseObject>() where TBaseObject : BaseObject, new();
        List<TBaseObject> select<TBaseObject>(string queryName) where TBaseObject : BaseObject, new();
        List<EventServiceHistory> history(long id);
        EventService get(long id);
        void insert(EventService eventservice);
        void update(long id, EventService eventservice);
        void put(EventService eventservice);
        void delete( long id );
        List<TBaseObject> children<TBaseObject>(long id, string childSuffix) where TBaseObject : BaseObject, new();
        //string getDomainName();
        // Add user-defined methods here
    }


    public partial class EventServiceLogic
    {
        protected EventServiceLogic()
        {
           
        }
        
    }
}

