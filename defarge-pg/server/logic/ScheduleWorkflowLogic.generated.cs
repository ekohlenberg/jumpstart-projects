
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Reflection;
using defarge;

namespace defarge
{


    public partial class ScheduleWorkflowLogic : IScheduleWorkflowLogic
    {


        public static IScheduleWorkflowLogic Create()
        {
            var scheduleworkflow = new ScheduleWorkflowLogic();

            var proxy = DispatchProxy.Create<IScheduleWorkflowLogic, Proxy<IScheduleWorkflowLogic>>();
            ((Proxy<IScheduleWorkflowLogic>)proxy).Initialize();
            ((Proxy<IScheduleWorkflowLogic>)proxy).Target = scheduleworkflow;
            ((Proxy<IScheduleWorkflowLogic>)proxy).DomainObj = "ScheduleWorkflow";

            return proxy;
        }

        public  List<ScheduleWorkflow> select()
        {
            return select<ScheduleWorkflow>();
        }

       
    
        public  List<TBaseObject> select<TBaseObject>() where TBaseObject : BaseObject, new()
        {
            Console.WriteLine("Processing ScheduleWorkflowLogic select<TBaseObject> List");

            List<TBaseObject> scheduleworkflows = select<TBaseObject>("core.schedule_workflow-select");

            
            return scheduleworkflows;
        }

        public List<TBaseObject> select<TBaseObject>(string queryName) where TBaseObject : BaseObject, new()
        {
            Console.WriteLine($"Processing ScheduleWorkflowLogic select<TBaseObject> with query: {queryName}");

            List<TBaseObject> scheduleworkflows = DBPersist.ExecuteQueryByName<TBaseObject>(queryName);

            return scheduleworkflows;
        }

         public  List<ScheduleWorkflowHistory> history(long id)
        {
            List<ScheduleWorkflowHistory> scheduleworkflowHistory = DBPersist.ExecuteQueryByName<ScheduleWorkflowHistory>("core.schedule_workflow-get-history", new BaseObject() { { "id", id } });

            return scheduleworkflowHistory;
        }

        public List<TBaseObject> children<TBaseObject>(long id, string childSuffix) where TBaseObject : BaseObject, new()
        {
            Console.WriteLine($"Processing ScheduleWorkflowLogic children<TBaseObject> for ID={id}, childSuffix={childSuffix}");

            string queryName = "core.schedule_workflow-children-" + childSuffix;
            List<TBaseObject> children = DBPersist.ExecuteQueryByName<TBaseObject>(queryName, new BaseObject() { { "id", id } });

            return children;
        }

        public  ScheduleWorkflow get(long id)
        {
            Console.WriteLine($"Processing ScheduleWorkflowLogic get ID={id}");

            ScheduleWorkflow scheduleworkflow = DBPersist.select<ScheduleWorkflow>($"SELECT * FROM core.schedule_workflow WHERE id = {id}").FirstOrDefault();
            

            return scheduleworkflow;
        }

        public  void insert(ScheduleWorkflow scheduleworkflow)
        {
            Console.WriteLine($"Processing ScheduleWorkflowLogic insert: {scheduleworkflow}");

            scheduleworkflow.is_active = 1;

            DBPersist.insert(scheduleworkflow);
        }

        public  void put(ScheduleWorkflow scheduleworkflow)
        {
            Console.WriteLine($"Processing ScheduleWorkflowLogic put: {scheduleworkflow}");

            scheduleworkflow.is_active = 1;

            DBPersist.put(scheduleworkflow);
        }

        public  void update(long id, ScheduleWorkflow scheduleworkflow)
        {
            Console.WriteLine($"Processing ScheduleWorkflowLogic update: ID = {id}\n{scheduleworkflow}");

            scheduleworkflow.id = id;
            DBPersist.update(scheduleworkflow);
        }

        public  void delete(long id)
        {
            ScheduleWorkflow scheduleworkflow = get(id);
            scheduleworkflow.is_active = 0;
            DBPersist.update(scheduleworkflow);
        }
    }
}
