
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Reflection;
using defarge;

namespace defarge
{


    public partial class SchedulerLogic : ISchedulerLogic
    {


        public static ISchedulerLogic Create()
        {
            var scheduler = new SchedulerLogic();

            var proxy = DispatchProxy.Create<ISchedulerLogic, Proxy<ISchedulerLogic>>();
            ((Proxy<ISchedulerLogic>)proxy).Initialize();
            ((Proxy<ISchedulerLogic>)proxy).Target = scheduler;
            ((Proxy<ISchedulerLogic>)proxy).DomainObj = "Scheduler";

            return proxy;
        }

        public  List<Scheduler> select()
        {
            return select<Scheduler>();
        }

       
    
        public  List<TBaseObject> select<TBaseObject>() where TBaseObject : BaseObject, new()
        {
            Console.WriteLine("Processing SchedulerLogic select<TBaseObject> List");

            List<TBaseObject> schedulers = select<TBaseObject>("core.scheduler-select");

            
            return schedulers;
        }

        public List<TBaseObject> select<TBaseObject>(string queryName) where TBaseObject : BaseObject, new()
        {
            Console.WriteLine($"Processing SchedulerLogic select<TBaseObject> with query: {queryName}");

            List<TBaseObject> schedulers = DBPersist.ExecuteQueryByName<TBaseObject>(queryName);

            return schedulers;
        }

         public  List<SchedulerHistory> history(long id)
        {
            List<SchedulerHistory> schedulerHistory = DBPersist.ExecuteQueryByName<SchedulerHistory>("core.scheduler-get-history", new BaseObject() { { "id", id } });

            return schedulerHistory;
        }

        public List<TBaseObject> children<TBaseObject>(long id, string childSuffix) where TBaseObject : BaseObject, new()
        {
            Console.WriteLine($"Processing SchedulerLogic children<TBaseObject> for ID={id}, childSuffix={childSuffix}");

            string queryName = "core.scheduler-children-" + childSuffix;
            List<TBaseObject> children = DBPersist.ExecuteQueryByName<TBaseObject>(queryName, new BaseObject() { { "id", id } });

            return children;
        }

        public  Scheduler get(long id)
        {
            Console.WriteLine($"Processing SchedulerLogic get ID={id}");

            Scheduler scheduler = DBPersist.select<Scheduler>($"SELECT * FROM core.scheduler WHERE id = {id}").FirstOrDefault();
            

            return scheduler;
        }

        public  void insert(Scheduler scheduler)
        {
            Console.WriteLine($"Processing SchedulerLogic insert: {scheduler}");

            scheduler.is_active = 1;

            DBPersist.insert(scheduler);
        }

        public  void put(Scheduler scheduler)
        {
            Console.WriteLine($"Processing SchedulerLogic put: {scheduler}");

            scheduler.is_active = 1;

            DBPersist.put(scheduler);
        }

        public  void update(long id, Scheduler scheduler)
        {
            Console.WriteLine($"Processing SchedulerLogic update: ID = {id}\n{scheduler}");

            scheduler.id = id;
            DBPersist.update(scheduler);
        }

        public  void delete(long id)
        {
            Scheduler scheduler = get(id);
            scheduler.is_active = 0;
            DBPersist.update(scheduler);
        }
    }
}
