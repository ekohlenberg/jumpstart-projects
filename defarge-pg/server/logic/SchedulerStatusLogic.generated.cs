
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Reflection;
using defarge;

namespace defarge
{


    public partial class SchedulerStatusLogic : ISchedulerStatusLogic
    {


        public static ISchedulerStatusLogic Create()
        {
            var schedulerstatus = new SchedulerStatusLogic();

            var proxy = DispatchProxy.Create<ISchedulerStatusLogic, Proxy<ISchedulerStatusLogic>>();
            ((Proxy<ISchedulerStatusLogic>)proxy).Initialize();
            ((Proxy<ISchedulerStatusLogic>)proxy).Target = schedulerstatus;
            ((Proxy<ISchedulerStatusLogic>)proxy).DomainObj = "SchedulerStatus";

            return proxy;
        }

        public  List<SchedulerStatus> select()
        {
            return select<SchedulerStatus>();
        }

       
    
        public  List<TBaseObject> select<TBaseObject>() where TBaseObject : BaseObject, new()
        {
            Console.WriteLine("Processing SchedulerStatusLogic select<TBaseObject> List");

            List<TBaseObject> schedulerstatuss = select<TBaseObject>("core.scheduler_status-select");

            
            return schedulerstatuss;
        }

        public List<TBaseObject> select<TBaseObject>(string queryName) where TBaseObject : BaseObject, new()
        {
            Console.WriteLine($"Processing SchedulerStatusLogic select<TBaseObject> with query: {queryName}");

            List<TBaseObject> schedulerstatuss = DBPersist.ExecuteQueryByName<TBaseObject>(queryName);

            return schedulerstatuss;
        }

         public  List<SchedulerStatusHistory> history(long id)
        {
            List<SchedulerStatusHistory> schedulerstatusHistory = DBPersist.ExecuteQueryByName<SchedulerStatusHistory>("core.scheduler_status-get-history", new BaseObject() { { "id", id } });

            return schedulerstatusHistory;
        }

        public List<TBaseObject> children<TBaseObject>(long id, string childSuffix) where TBaseObject : BaseObject, new()
        {
            Console.WriteLine($"Processing SchedulerStatusLogic children<TBaseObject> for ID={id}, childSuffix={childSuffix}");

            string queryName = "core.scheduler_status-children-" + childSuffix;
            List<TBaseObject> children = DBPersist.ExecuteQueryByName<TBaseObject>(queryName, new BaseObject() { { "id", id } });

            return children;
        }

        public  SchedulerStatus get(long id)
        {
            Console.WriteLine($"Processing SchedulerStatusLogic get ID={id}");

            SchedulerStatus schedulerstatus = DBPersist.select<SchedulerStatus>($"SELECT * FROM core.scheduler_status WHERE id = {id}").FirstOrDefault();
            

            return schedulerstatus;
        }

        public  void insert(SchedulerStatus schedulerstatus)
        {
            Console.WriteLine($"Processing SchedulerStatusLogic insert: {schedulerstatus}");

            schedulerstatus.is_active = 1;

            DBPersist.insert(schedulerstatus);
        }

        public  void put(SchedulerStatus schedulerstatus)
        {
            Console.WriteLine($"Processing SchedulerStatusLogic put: {schedulerstatus}");

            schedulerstatus.is_active = 1;

            DBPersist.put(schedulerstatus);
        }

        public  void update(long id, SchedulerStatus schedulerstatus)
        {
            Console.WriteLine($"Processing SchedulerStatusLogic update: ID = {id}\n{schedulerstatus}");

            schedulerstatus.id = id;
            DBPersist.update(schedulerstatus);
        }

        public  void delete(long id)
        {
            SchedulerStatus schedulerstatus = get(id);
            schedulerstatus.is_active = 0;
            DBPersist.update(schedulerstatus);
        }
    }
}
