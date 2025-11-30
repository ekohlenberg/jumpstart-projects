
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Reflection;
using defarge;

namespace defarge
{


    public partial class EventServiceLogic : IEventServiceLogic
    {


        public static IEventServiceLogic Create()
        {
            var eventservice = new EventServiceLogic();

            var proxy = DispatchProxy.Create<IEventServiceLogic, Proxy<IEventServiceLogic>>();
            ((Proxy<IEventServiceLogic>)proxy).Initialize();
            ((Proxy<IEventServiceLogic>)proxy).Target = eventservice;
            ((Proxy<IEventServiceLogic>)proxy).DomainObj = "EventService";

            return proxy;
        }

        public  List<EventService> select()
        {
            return select<EventService>();
        }

       
    
        public  List<TBaseObject> select<TBaseObject>() where TBaseObject : BaseObject, new()
        {
            Console.WriteLine("Processing EventServiceLogic select<TBaseObject> List");

            List<TBaseObject> eventservices = select<TBaseObject>("core.event_service-select");

            
            return eventservices;
        }

        public List<TBaseObject> select<TBaseObject>(string queryName) where TBaseObject : BaseObject, new()
        {
            Console.WriteLine($"Processing EventServiceLogic select<TBaseObject> with query: {queryName}");

            List<TBaseObject> eventservices = DBPersist.ExecuteQueryByName<TBaseObject>(queryName);

            return eventservices;
        }

         public  List<EventServiceHistory> history(long id)
        {
            List<EventServiceHistory> eventserviceHistory = DBPersist.ExecuteQueryByName<EventServiceHistory>("core.event_service-get-history", new BaseObject() { { "id", id } });

            return eventserviceHistory;
        }

        public List<TBaseObject> children<TBaseObject>(long id, string childSuffix) where TBaseObject : BaseObject, new()
        {
            Console.WriteLine($"Processing EventServiceLogic children<TBaseObject> for ID={id}, childSuffix={childSuffix}");

            string queryName = "core.event_service-children-" + childSuffix;
            List<TBaseObject> children = DBPersist.ExecuteQueryByName<TBaseObject>(queryName, new BaseObject() { { "id", id } });

            return children;
        }

        public  EventService get(long id)
        {
            Console.WriteLine($"Processing EventServiceLogic get ID={id}");

            EventService eventservice = DBPersist.select<EventService>($"SELECT * FROM core.event_service WHERE id = {id}").FirstOrDefault();
            

            return eventservice;
        }

        public  void insert(EventService eventservice)
        {
            Console.WriteLine($"Processing EventServiceLogic insert: {eventservice}");

            eventservice.is_active = 1;

            DBPersist.insert(eventservice);
        }

        public  void put(EventService eventservice)
        {
            Console.WriteLine($"Processing EventServiceLogic put: {eventservice}");

            eventservice.is_active = 1;

            DBPersist.put(eventservice);
        }

        public  void update(long id, EventService eventservice)
        {
            Console.WriteLine($"Processing EventServiceLogic update: ID = {id}\n{eventservice}");

            eventservice.id = id;
            DBPersist.update(eventservice);
        }

        public  void delete(long id)
        {
            EventService eventservice = get(id);
            eventservice.is_active = 0;
            DBPersist.update(eventservice);
        }
    }
}
