
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Reflection;
using defarge;

namespace defarge
{


    public partial class WorkflowLogic : IWorkflowLogic
    {


        public static IWorkflowLogic Create()
        {
            var workflow = new WorkflowLogic();

            var proxy = DispatchProxy.Create<IWorkflowLogic, Proxy<IWorkflowLogic>>();
            ((Proxy<IWorkflowLogic>)proxy).Initialize();
            ((Proxy<IWorkflowLogic>)proxy).Target = workflow;
            ((Proxy<IWorkflowLogic>)proxy).DomainObj = "Workflow";

            return proxy;
        }

        public  List<Workflow> select()
        {
            return select<Workflow>();
        }

       
    
        public  List<TBaseObject> select<TBaseObject>() where TBaseObject : BaseObject, new()
        {
            Console.WriteLine("Processing WorkflowLogic select<TBaseObject> List");

            List<TBaseObject> workflows = select<TBaseObject>("core.workflow-select");

            
            return workflows;
        }

        public List<TBaseObject> select<TBaseObject>(string queryName) where TBaseObject : BaseObject, new()
        {
            Console.WriteLine($"Processing WorkflowLogic select<TBaseObject> with query: {queryName}");

            List<TBaseObject> workflows = DBPersist.ExecuteQueryByName<TBaseObject>(queryName);

            return workflows;
        }

         public  List<WorkflowHistory> history(long id)
        {
            List<WorkflowHistory> workflowHistory = DBPersist.ExecuteQueryByName<WorkflowHistory>("core.workflow-get-history", new BaseObject() { { "id", id } });

            return workflowHistory;
        }

        public List<TBaseObject> children<TBaseObject>(long id, string childSuffix) where TBaseObject : BaseObject, new()
        {
            Console.WriteLine($"Processing WorkflowLogic children<TBaseObject> for ID={id}, childSuffix={childSuffix}");

            string queryName = "core.workflow-children-" + childSuffix;
            List<TBaseObject> children = DBPersist.ExecuteQueryByName<TBaseObject>(queryName, new BaseObject() { { "id", id } });

            return children;
        }

        public  Workflow get(long id)
        {
            Console.WriteLine($"Processing WorkflowLogic get ID={id}");

            Workflow workflow = DBPersist.select<Workflow>($"SELECT * FROM core.workflow WHERE id = {id}").FirstOrDefault();
            

            return workflow;
        }

        public  void insert(Workflow workflow)
        {
            Console.WriteLine($"Processing WorkflowLogic insert: {workflow}");

            workflow.is_active = 1;

            DBPersist.insert(workflow);
        }

        public  void put(Workflow workflow)
        {
            Console.WriteLine($"Processing WorkflowLogic put: {workflow}");

            workflow.is_active = 1;

            DBPersist.put(workflow);
        }

        public  void update(long id, Workflow workflow)
        {
            Console.WriteLine($"Processing WorkflowLogic update: ID = {id}\n{workflow}");

            workflow.id = id;
            DBPersist.update(workflow);
        }

        public  void delete(long id)
        {
            Workflow workflow = get(id);
            workflow.is_active = 0;
            DBPersist.update(workflow);
        }
    }
}
