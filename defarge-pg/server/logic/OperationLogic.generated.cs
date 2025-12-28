
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Reflection;
using defarge;

namespace defarge
{


    public partial class OperationLogic : IOperationLogic
    {


        public static IOperationLogic Create()
        {
            var operation = new OperationLogic();

            var proxy = DispatchProxy.Create<IOperationLogic, Proxy<IOperationLogic>>();
            ((Proxy<IOperationLogic>)proxy).Initialize();
            ((Proxy<IOperationLogic>)proxy).Target = operation;
            ((Proxy<IOperationLogic>)proxy).DomainObj = "Operation";

            return proxy;
        }

        public  List<Operation> select()
        {
            return select<Operation>();
        }

       
    
        public  List<TBaseObject> select<TBaseObject>() where TBaseObject : BaseObject, new()
        {
            Logger.Debug("Processing OperationLogic select<TBaseObject> List");

            List<TBaseObject> operations = select<TBaseObject>("sec.operation-select");

            
            return operations;
        }

        public List<TBaseObject> select<TBaseObject>(string queryName) where TBaseObject : BaseObject, new()
        {
            Logger.Debug($"Processing OperationLogic select<TBaseObject> with query: {queryName}");

            List<TBaseObject> operations = DBPersist.ExecuteQueryByName<TBaseObject>(queryName);

            return operations;
        }

         public  List<OperationHistory> history(long id)
        {
            List<OperationHistory> operationHistory = DBPersist.ExecuteQueryByName<OperationHistory>("sec.operation-get-history", new BaseObject() { { "id", id } });

            return operationHistory;
        }

        public List<TBaseObject> children<TBaseObject>(long id, string childSuffix) where TBaseObject : BaseObject, new()
        {
            Logger.Debug($"Processing OperationLogic children<TBaseObject> for ID={id}, childSuffix={childSuffix}");

            string queryName = "sec.operation-children-" + childSuffix;
            List<TBaseObject> children = DBPersist.ExecuteQueryByName<TBaseObject>(queryName, new BaseObject() { { "id", id } });

            return children;
        }

        public  Operation get(long id)
        {
            Logger.Debug($"Processing OperationLogic get ID={id}");

            Operation operation = DBPersist.select<Operation>($"SELECT * FROM sec.operation WHERE id = {id}").FirstOrDefault();
            

            return operation;
        }

        public  void insert(Operation operation)
        {
            Logger.Debug($"Processing OperationLogic insert: {operation}");

            operation.is_active = 1;

            DBPersist.insert(operation);
        }

        public  void put(Operation operation)
        {
            Logger.Debug($"Processing OperationLogic put: {operation}");

            operation.is_active = 1;

            DBPersist.put(operation);
        }

        public  void update(long id, Operation operation)
        {
            Logger.Debug($"Processing OperationLogic update: ID = {id}\n{operation}");

            operation.id = id;
            DBPersist.update(operation);
        }

        public  void delete(long id)
        {
            Operation operation = get(id);
            operation.is_active = 0;
            DBPersist.update(operation);
        }
    }
}
