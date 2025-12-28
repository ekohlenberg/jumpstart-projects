
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Reflection;
using defarge;

namespace defarge
{


    public partial class ScheduleLogic : IScheduleLogic
    {


        public static IScheduleLogic Create()
        {
            var schedule = new ScheduleLogic();

            var proxy = DispatchProxy.Create<IScheduleLogic, Proxy<IScheduleLogic>>();
            ((Proxy<IScheduleLogic>)proxy).Initialize();
            ((Proxy<IScheduleLogic>)proxy).Target = schedule;
            ((Proxy<IScheduleLogic>)proxy).DomainObj = "Schedule";

            return proxy;
        }

        public  List<Schedule> select()
        {
            return select<Schedule>();
        }

       
    
        public  List<TBaseObject> select<TBaseObject>() where TBaseObject : BaseObject, new()
        {
            Logger.Debug("Processing ScheduleLogic select<TBaseObject> List");

            List<TBaseObject> schedules = select<TBaseObject>("core.schedule-select");

            
            return schedules;
        }

        public List<TBaseObject> select<TBaseObject>(string queryName) where TBaseObject : BaseObject, new()
        {
            Logger.Debug($"Processing ScheduleLogic select<TBaseObject> with query: {queryName}");

            List<TBaseObject> schedules = DBPersist.ExecuteQueryByName<TBaseObject>(queryName);

            return schedules;
        }

         public  List<ScheduleHistory> history(long id)
        {
            List<ScheduleHistory> scheduleHistory = DBPersist.ExecuteQueryByName<ScheduleHistory>("core.schedule-get-history", new BaseObject() { { "id", id } });

            return scheduleHistory;
        }

        public List<TBaseObject> children<TBaseObject>(long id, string childSuffix) where TBaseObject : BaseObject, new()
        {
            Logger.Debug($"Processing ScheduleLogic children<TBaseObject> for ID={id}, childSuffix={childSuffix}");

            string queryName = "core.schedule-children-" + childSuffix;
            List<TBaseObject> children = DBPersist.ExecuteQueryByName<TBaseObject>(queryName, new BaseObject() { { "id", id } });

            return children;
        }

        public  Schedule get(long id)
        {
            Logger.Debug($"Processing ScheduleLogic get ID={id}");

            Schedule schedule = DBPersist.select<Schedule>($"SELECT * FROM core.schedule WHERE id = {id}").FirstOrDefault();
            

            return schedule;
        }

        public  void insert(Schedule schedule)
        {
            Logger.Debug($"Processing ScheduleLogic insert: {schedule}");

            schedule.is_active = 1;

            DBPersist.insert(schedule);
        }

        public  void put(Schedule schedule)
        {
            Logger.Debug($"Processing ScheduleLogic put: {schedule}");

            schedule.is_active = 1;

            DBPersist.put(schedule);
        }

        public  void update(long id, Schedule schedule)
        {
            Logger.Debug($"Processing ScheduleLogic update: ID = {id}\n{schedule}");

            schedule.id = id;
            DBPersist.update(schedule);
        }

        public  void delete(long id)
        {
            Schedule schedule = get(id);
            schedule.is_active = 0;
            DBPersist.update(schedule);
        }
    }
}
