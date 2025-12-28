
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Reflection;
using defarge;

namespace defarge
{


    public partial class ExecutionLogic : IExecutionLogic
    {


        public static IExecutionLogic Create()
        {
            var execution = new ExecutionLogic();

            var proxy = DispatchProxy.Create<IExecutionLogic, Proxy<IExecutionLogic>>();
            ((Proxy<IExecutionLogic>)proxy).Initialize();
            ((Proxy<IExecutionLogic>)proxy).Target = execution;
            ((Proxy<IExecutionLogic>)proxy).DomainObj = "Execution";

            return proxy;
        }

        public  List<Execution> select()
        {
            return select<Execution>();
        }

       
    
        public  List<TBaseObject> select<TBaseObject>() where TBaseObject : BaseObject, new()
        {
            Logger.Debug("Processing ExecutionLogic select<TBaseObject> List");

            List<TBaseObject> executions = select<TBaseObject>("core.execution-select");

            
            return executions;
        }

        public List<TBaseObject> select<TBaseObject>(string queryName) where TBaseObject : BaseObject, new()
        {
            Logger.Debug($"Processing ExecutionLogic select<TBaseObject> with query: {queryName}");

            List<TBaseObject> executions = DBPersist.ExecuteQueryByName<TBaseObject>(queryName);

            return executions;
        }

         public  List<ExecutionHistory> history(long id)
        {
            List<ExecutionHistory> executionHistory = DBPersist.ExecuteQueryByName<ExecutionHistory>("core.execution-get-history", new BaseObject() { { "id", id } });

            return executionHistory;
        }

        public List<TBaseObject> children<TBaseObject>(long id, string childSuffix) where TBaseObject : BaseObject, new()
        {
            Logger.Debug($"Processing ExecutionLogic children<TBaseObject> for ID={id}, childSuffix={childSuffix}");

            string queryName = "core.execution-children-" + childSuffix;
            List<TBaseObject> children = DBPersist.ExecuteQueryByName<TBaseObject>(queryName, new BaseObject() { { "id", id } });

            return children;
        }

        public  Execution get(long id)
        {
            Logger.Debug($"Processing ExecutionLogic get ID={id}");

            Execution execution = DBPersist.select<Execution>($"SELECT * FROM core.execution WHERE id = {id}").FirstOrDefault();
            

            return execution;
        }

        public  void insert(Execution execution)
        {
            Logger.Debug($"Processing ExecutionLogic insert: {execution}");

            execution.is_active = 1;

            DBPersist.insert(execution);
        }

        public  void put(Execution execution)
        {
            Logger.Debug($"Processing ExecutionLogic put: {execution}");

            execution.is_active = 1;

            DBPersist.put(execution);
        }

        public  void update(long id, Execution execution)
        {
            Logger.Debug($"Processing ExecutionLogic update: ID = {id}\n{execution}");

            execution.id = id;
            DBPersist.update(execution);
        }

        public  void delete(long id)
        {
            Execution execution = get(id);
            execution.is_active = 0;
            DBPersist.update(execution);
        }
    }
}
