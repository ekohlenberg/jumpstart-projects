
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Reflection;
using defarge;

namespace defarge
{


    public partial class WorkflowProcessLogic : IWorkflowProcessLogic
    {


        public static IWorkflowProcessLogic Create()
        {
            var workflowprocess = new WorkflowProcessLogic();

            var proxy = DispatchProxy.Create<IWorkflowProcessLogic, Proxy<IWorkflowProcessLogic>>();
            ((Proxy<IWorkflowProcessLogic>)proxy).Initialize();
            ((Proxy<IWorkflowProcessLogic>)proxy).Target = workflowprocess;
            ((Proxy<IWorkflowProcessLogic>)proxy).DomainObj = "WorkflowProcess";

            return proxy;
        }

        public  List<WorkflowProcess> select()
        {
            return select<WorkflowProcess>();
        }

       
    
        public  List<TBaseObject> select<TBaseObject>() where TBaseObject : BaseObject, new()
        {
            Logger.Debug("Processing WorkflowProcessLogic select<TBaseObject> List");

            List<TBaseObject> workflowprocesss = select<TBaseObject>("core.workflow_process-select");

            
            return workflowprocesss;
        }

        public List<TBaseObject> select<TBaseObject>(string queryName) where TBaseObject : BaseObject, new()
        {
            Logger.Debug($"Processing WorkflowProcessLogic select<TBaseObject> with query: {queryName}");

            List<TBaseObject> workflowprocesss = DBPersist.ExecuteQueryByName<TBaseObject>(queryName);

            return workflowprocesss;
        }

         public  List<WorkflowProcessHistory> history(long id)
        {
            List<WorkflowProcessHistory> workflowprocessHistory = DBPersist.ExecuteQueryByName<WorkflowProcessHistory>("core.workflow_process-get-history", new BaseObject() { { "id", id } });

            return workflowprocessHistory;
        }

        public List<TBaseObject> children<TBaseObject>(long id, string childSuffix) where TBaseObject : BaseObject, new()
        {
            Logger.Debug($"Processing WorkflowProcessLogic children<TBaseObject> for ID={id}, childSuffix={childSuffix}");

            string queryName = "core.workflow_process-children-" + childSuffix;
            List<TBaseObject> children = DBPersist.ExecuteQueryByName<TBaseObject>(queryName, new BaseObject() { { "id", id } });

            return children;
        }

        public  WorkflowProcess get(long id)
        {
            Logger.Debug($"Processing WorkflowProcessLogic get ID={id}");

            WorkflowProcess workflowprocess = DBPersist.select<WorkflowProcess>($"SELECT * FROM core.workflow_process WHERE id = {id}").FirstOrDefault();
            

            return workflowprocess;
        }

        public  void insert(WorkflowProcess workflowprocess)
        {
            Logger.Debug($"Processing WorkflowProcessLogic insert: {workflowprocess}");

            workflowprocess.is_active = 1;

            DBPersist.insert(workflowprocess);
        }

        public  void put(WorkflowProcess workflowprocess)
        {
            Logger.Debug($"Processing WorkflowProcessLogic put: {workflowprocess}");

            workflowprocess.is_active = 1;

            DBPersist.put(workflowprocess);
        }

        public  void update(long id, WorkflowProcess workflowprocess)
        {
            Logger.Debug($"Processing WorkflowProcessLogic update: ID = {id}\n{workflowprocess}");

            workflowprocess.id = id;
            DBPersist.update(workflowprocess);
        }

        public  void delete(long id)
        {
            WorkflowProcess workflowprocess = get(id);
            workflowprocess.is_active = 0;
            DBPersist.update(workflowprocess);
        }
    }
}
